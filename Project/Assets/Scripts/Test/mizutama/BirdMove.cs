using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour
{

    [SerializeField, Range(1, 50), Tooltip("移動速度,")]
    float _speed = 0.0f;


    void Update()
    {
        transform.position -= new Vector3(_speed * Time.deltaTime, 0, 0);
    }
}
