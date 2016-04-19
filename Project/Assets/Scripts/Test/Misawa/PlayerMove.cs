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

    [SerializeField, Range(1.0f, 5.0f), Tooltip("移動速度")]
    private float _speed = 1;

    //まだ到達していないノードのlist
    private List<Vector3> _nodePosition = new List<Vector3>();
    
    private int _UpdateCount = 0;

    //到達していないノードの数
    private int _listLength = 0;

    //一つ前のノードの位置
    private Vector3 _startPosition;

    //移動先のノードの位置
    private Vector3 _targetPosition;

    //移動先のノードがセットされているか
    bool _isSetTarget = false;

    float rate = 0;
    
    //最初のノードの位置をプレイヤーの初期位置に設定する
    void Start()
    {
        _startPosition = transform.position;
    }
    
    void FixedUpdate()
    {
        _UpdateCount++;

        //今のリストの長さを調べる
        _listLength = _nodePosition.Count;

        
        if (_UpdateCount == _nodeSetTiming)
        {
            if (Input.GetMouseButton(0))
            {
                //今のマーカーの位置にノードを配置
                _nodePosition.Add(_marker.transform.position);
                
                //DEBUG:確認用に点を置いていく
                Instantiate(_node, _nodePosition[_listLength], Quaternion.identity);
            }

            _UpdateCount = 0;
        }



        if (_isSetTarget)
        {
            //ノード間の距離
            float dis = Vector3.Distance(_startPosition, _targetPosition);
            //前のノードとプレイヤーの距離
            float diff = Vector3.Distance(gameObject.transform.position, _startPosition);

            rate = (diff + _speed / 10) / dis;

            transform.position = Vector3.Lerp(_startPosition, _targetPosition, rate);
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

            if (rate > 1)
            {
                //移動前の位置を記憶
                _startPosition = transform.position;

                //前のノードを消去
                _nodePosition.RemoveAt(0);

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
    }

    float CalcAngle()
    {
        float dx = _nodePosition[0].x - this.transform.position.x;
        float dy = _nodePosition[0].y - this.transform.position.y;
        return Mathf.Abs(Mathf.Atan2(dy, dx) / Mathf.PI);
    }
    void SetTarget()
    {
        float dis = Vector3.Distance(this.transform.position, _nodePosition[0]);

        //進行方向±45度の範囲内にあるノードをターゲットにセットする
        if (CalcAngle() < 0.25f)
        {
            //移動先の位置を記憶
            _targetPosition = _nodePosition[0];

            rate = 0;

            _isSetTarget = true;
        }

        Debug.Log(CalcAngle() +"," +dis);
    }
}