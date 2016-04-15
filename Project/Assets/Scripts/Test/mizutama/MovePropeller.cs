using UnityEngine;
using System.Collections;

public class MovePropeller : MonoBehaviour
{
    [SerializeField, Range(0.0f, 3.0f), Tooltip("回転の最高速度,")]
    float _maxRotateSpeed = 0.5f;

    [SerializeField, Range(0.0f, 3.0f), Tooltip("回転の最低速度")]
    float _minRotateSpeed = 0.0f;

    //回転速度
    private float _rotateSpeed = 0.0f;

    [SerializeField, Range(0.0f, 10.0f), Tooltip("何秒で復活するか,")]
    float _maxWaitTimeOfReturn = 1.0f;

    //復活する時間
    private float _waitTimeOfReturn = 0.0f;

    [SerializeField, Range(1, 50), Tooltip("何回タッチしたら最低速度になるか,")]
    int _maxtouthCount = 1;

    //タッチの回数
    private int _touthCount = 0;

    //初期状態の時にタッチしたかどうか
    private bool _firstTouth;


    void Start()
    {
        _rotateSpeed = _maxRotateSpeed;
    }

    void FixedUpdate()
    {
        DeleyRotate();
        CountReBornTime();
        transform.Rotate(new Vector3(0, 0, _rotateSpeed * Time.deltaTime * 100));

    }

    //復活時間を測定
    private void CountReBornTime()
    {
        if (!_firstTouth) return;
        _waitTimeOfReturn += Time.deltaTime;

        if (_waitTimeOfReturn < _maxWaitTimeOfReturn) return;
        ReBorn();
    }

    //復活
    private void ReBorn()
    {
        _waitTimeOfReturn = 0;
        _rotateSpeed = _maxRotateSpeed;
        _firstTouth = false;
        _touthCount = 0;
    }

    //タッチしたら動きが遅くなる
    private void DeleyRotate()
    {
        if(!_firstTouth)
        _firstTouth = true;

        if (_touthCount > _maxtouthCount) return;
        ++_touthCount;


        //規定のタッチしたら最低速度になるように処理
        if (!_firstTouth) return;
        if (_touthCount > _maxtouthCount) return;
        _rotateSpeed -= (_maxRotateSpeed - _minRotateSpeed) / _maxtouthCount;

    }
}
