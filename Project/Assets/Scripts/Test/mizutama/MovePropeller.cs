using UnityEngine;
using System.Collections;

public class MovePropeller : MonoBehaviour
{
    [SerializeField, Tooltip("マイクの情報")]
    private GameObject _mike = null;

    [SerializeField, Range(0.0f, 5.0f), Tooltip("回転の最高速度,")]
    float _maxRotateSpeed = 0.5f;

    [SerializeField, Range(0.0f, 3.0f), Tooltip("回転の最低速度")]
    float _minRotateSpeed = 0.0f;

   
    private float _rotateSpeed = 0.0f;          //回転速度

    [SerializeField, Range(0.0f, 10.0f), Tooltip("何秒ごとに加速するか")]
    float _maxWaitTimeOfAcceleration = 0.0f;

    private float _waitTimeOfAcceleration = 0.0f;

    [SerializeField, Range(1, 10), Tooltip("何回減速したら最低速度になるか")]
    int _maxtouthCount = 1;
    
    private int _touthCount = 0;               //減速できる回数

    [SerializeField, Range(0.0f, 1.0f), Tooltip("次減速できるまでの時間")]
    public float _maxInterval = 0.0f;

    private float _interval = 0.0f;

    void Start()
    {
        _rotateSpeed = _maxRotateSpeed;
    }

    void FixedUpdate()
    {

        if (_mike.GetComponent<MikeInput>().nowVolume >= 0.7f)
        {
            _interval += Time.deltaTime;
            Debug.Log(_interval);
        }

        if (_interval >= _maxInterval)
        {
            Debug.Log("reset");
            _interval = 0.0f;
            DeleyRotate();
        }

        CountAccelerationTime();
        transform.Rotate(new Vector3(0, 0, _rotateSpeed * Time.deltaTime * 100));

        
    }

    //一定時間たったら加速する処理
    private void CountAccelerationTime()
    {
        _waitTimeOfAcceleration += Time.deltaTime;

        if (_waitTimeOfAcceleration < _maxWaitTimeOfAcceleration) return;
        _waitTimeOfAcceleration = 0.0f;

        if (_rotateSpeed > _maxRotateSpeed) return;
        _rotateSpeed += (_maxRotateSpeed - _minRotateSpeed) / _maxtouthCount;

        if (_touthCount < 0) return;
        --_touthCount;
    }



    //吹いたら動きが遅くなる
    private void DeleyRotate()
    {
        
        if (_touthCount >= _maxtouthCount) return;
        ++_touthCount;
        _rotateSpeed -= (_maxRotateSpeed - _minRotateSpeed) / _maxtouthCount;
    }
}
