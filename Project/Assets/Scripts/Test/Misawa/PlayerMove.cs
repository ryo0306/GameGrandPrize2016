using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
作成日:2016/04/15
作成者:三澤裕樹
*/
public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("配置するノード")]
    private GameObject _node = null;

    [SerializeField, Tooltip("ノードを置く位置を表示するマーカー")]
    private GameObject _marker = null;

    [SerializeField, Range(1, 10), Tooltip("ノードを置く間隔")]
    private int _nodeSetTiming = 1;

    [SerializeField, Range(0.1f, 5.0f), Tooltip("移動速度")]
    private float _speed = 0.5f;

    [SerializeField,Tooltip("登録されたオブジェクトより右に行くとゴール")]
    private GameObject _goalLine = null;

    //まだ到達していないノードのlist
    private List<Vector3> _nodePosition = new List<Vector3>();
    
    private int _updateCount = 0;

    //復帰地点を保存
    private Vector3 _respawnPosition = Vector3.zero;

    //到達していないノードの数
    private int _listLength = 0;

    private int _nextNodeID = 0;

    //一つ前のノードの位置
    private Vector3 _startPosition = Vector3.zero;

    //移動先のノードの位置
    private Vector3 _targetPosition = Vector3.zero;

    //移動先のノードがセットされているか
    private bool _isSetTarget = false;

    private float _rate = 0;

    //ゴールしているか
    private bool _isGoal = false;

    //
    private List<GameObject> clones = new List<GameObject>();
    
    //最初のノードの位置をプレイヤーの初期位置に設定する
    void Start()
    {
        _respawnPosition = transform.position;
        _startPosition = _respawnPosition;
    }

    void FixedUpdate()
    {
        _updateCount++;

        //今のリストの長さを調べる
        _listLength = _nodePosition.Count;
        
        if (_updateCount == _nodeSetTiming)
        {
            if (Input.GetMouseButton(0))
            {
                //今のマーカーの位置にノードを配置
                _nodePosition.Add(_marker.transform.position);

                //DEBUG:確認用に点を置いていく
                clones.Add(Instantiate(_node, _nodePosition[_listLength], Quaternion.identity) as GameObject);
            }

            if (_listLength > 0)
            {
                _startPosition = transform.position;

                SetTarget();
            }

            _updateCount = 0;
            Debug.Log(_listLength);
        }


        if (_isSetTarget)
        {
            //ノード間の距離
            float dis = Vector3.Distance(_startPosition, _targetPosition);
            //前のノードとプレイヤーの距離
            float diff = Vector3.Distance(gameObject.transform.position, _startPosition);

            _rate = (diff + _speed / 10) / dis;

            transform.position = Vector3.Lerp(_startPosition, _targetPosition, _rate);
        }
        else
        {
            transform.position += new Vector3(_speed / 10f, -0.05f, 0);
        }


        if (_listLength >= 1)
        {
            if(_isSetTarget == false)
            {
                //移動前の位置を記憶
                _startPosition = transform.position;

                SetTarget();
            }

            if (_rate > 1 && _isSetTarget)
            {
                //移動前の位置を記憶
                _startPosition = transform.position;

                if (_nodePosition.Count >= 1)
                {
                    //前のノードを消去
                    _nodePosition.RemoveAt(_nextNodeID);
                }

                while (_nodePosition.Count >= 1)
                {
                    //次のノードが自機より後ろにあったら消す
                    if (_nodePosition[0].x < this.transform.position.x)
                    {
                        _nodePosition.RemoveAt(0);
                    }

                    //後ろじゃなければループを抜ける
                    else break;
                }

                if (_nodePosition.Count >= 1)
                {
                    SetTarget();
                }

                else _isSetTarget = false;
            }
        }

        //ゴールオブジェクトより奥に行っていたらフラグをtrue
        if(_goalLine.transform.position.x < transform.position.x)
        {
            _isGoal = true;
        }

        //DEBUG:ゴールしていたらコンソールに文字表示
        if (_isGoal)
        {
            Debug.Log("GOAL");
        }
    }

    float CalcAngle()
    {
        float dx = _nodePosition[_nextNodeID].x - this.transform.position.x;
        float dy = _nodePosition[_nextNodeID].y - this.transform.position.y;
        return Mathf.Abs(Mathf.Atan2(dy, dx) / Mathf.PI);
    }

    int CheckNearNodeID()
    {
        int _id = 0;

        float _distance = 1000;

        for(int i = 0; i < _nodePosition.Count; i++)
        {
            float dis = Vector3.Distance(this.transform.position, _nodePosition[i]);
            if(_distance > dis)
            {
                _distance = dis;
                _id = i;
            }
        }

        return _id;
    }

    void SetTarget()
    {
        _nextNodeID = CheckNearNodeID();
        //進行方向±45度の範囲内にあるノードをターゲットにセットする
        if (CalcAngle() < 0.25f)
        {
            //移動先の位置を記憶
            _targetPosition = _nodePosition[_nextNodeID];

            _rate = 0;

            _isSetTarget = true;
        }
//        else
//        {
//            //範囲外のノードは消去
//            _nodePosition.RemoveAt(_nextNodeID);
//        }
    }

    void OnTriggerEnter(Collider col)
    {
        //ぶつかったオブジェクトがチェックポイントだったらリスポーン場所を更新
        if (col.gameObject.tag == "CheckPoint")
        {
            _respawnPosition = col.transform.position;
        }
        //チェックポイント以外のとき
        else if(col.gameObject.tag != "Node")
        {
            //今登録されているノードをリセット
            while (_nodePosition.Count > 0)
            {
                _nodePosition.RemoveAt(0);
            }

            _rate = 0;

            _isSetTarget = false;

            //リスポーン地点に移動
            transform.position = _respawnPosition;

            foreach (var clone in clones)
            {
                Destroy(clone);
            }
        }
    }
}