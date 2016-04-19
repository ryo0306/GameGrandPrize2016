using UnityEngine;
using System.Collections;
/// <summary>
/// 4 / 19
/// 野本
/// 作業開始
/// </summary>
public class ChangeWindSpeedRate : MonoBehaviour
{
    [SerializeField,Range(0.0f,50.0f),Tooltip("移動速度")]
    float _moveSpeed = 5f;
    [SerializeField, Range(0.0f, 5.0f), Tooltip("進行方向に対してMinus方向の加速度")]
    float _minusMoveSpeed = 0.3f;

    void Update()
    {

    }

    void  FixedUpdate()
    {
        _moveSpeed += (GetComponent<MikeInput>().GetAveragedVolume() - _minusMoveSpeed);
        if (_moveSpeed < 0f) _moveSpeed = 0f;
        else if (_moveSpeed > 10f) _moveSpeed = 10f;
        transform.localPosition += new Vector3(_moveSpeed * Time.deltaTime,0,0);
    }
}
