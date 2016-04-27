using UnityEngine;
using System.Collections;

public class SelectStage : MonoBehaviour
{

    //範囲制限は未実装

    [SerializeField, Tooltip("ステージの画像の親")]
    GameObject _stagePhoto = null;
    [SerializeField, Tooltip("ステージの画像1")]
    GameObject _stagePhoto1 = null;
    [SerializeField, Tooltip("ステージの画像2")]
    GameObject _stagePhoto2 = null;
    [SerializeField, Tooltip("ステージの画像3")]
    GameObject _stagePhoto3 = null;

    public bool _silide;              //現在スライドしているかどうか

    private float _slideTime;         //Easing用の時間

    private float _startPos;          //初期位置

    public float _range;              //どれだけ移動させるか

    private float _direction;         //どっちの方向に移動させるか

    //※最初はfloat型でやっていたがうまく代入ができなかったので
    //Vector3型にしてやってみた
    Vector3 _changePos;               //代入用


    //Easing関数
    private float EasingCircInOut(float t, float b, float e)
    {
        if ((t /= 0.5f) < 1) return -(e - b) / 2 * (Mathf.Sqrt(1 - t * t) - 1) + b;
        t -= 2;
        return (e - b) / 2 * (Mathf.Sqrt(1 - t * t) + 1) + b;
    }

    void Start()
    {
        _startPos = _stagePhoto.transform.position.x;
        _slideTime = 0.0f;
    }

    void Update()
    {
        Slideing();
    }



    private void Slideing()
    {
        if (_silide)
        {
            _slideTime += 0.01f;

            
            _changePos.x = EasingCircInOut(_startPos, _startPos + _range * _direction, _slideTime);
            //Vector3型によって無駄が出ている
            _changePos.y = _stagePhoto.transform.position.y;
            _changePos.z = _stagePhoto.transform.position.z;


             _stagePhoto.transform.position = _changePos;

            //_slide仕切ったら開始位置を更新
            if (_slideTime >= 1.0f)
            {
                _startPos = _stagePhoto.transform.position.x;
                _silide = false;
                _slideTime = 0.0f;
            }
        }
    }



    public void PushRightButton()
    {
        if (!_silide)
        {
            _silide = true;
            _direction = -1;
        }
    }

    public void PushLeftButton()
    {
        if (!_silide)
        {
            _silide = true;
            _direction = 1;
        }
    }

}
