using UnityEngine;
using System.Collections;

public class FireWall : MonoBehaviour
{

    [SerializeField, Tooltip("火の本体,")]
    GameObject _fire = null;

    [SerializeField, Range(1, 5), Tooltip("何回でで火が消えるか")]
    int _maxTouthCount = 1;
    private int _touthCount = 0;

    [SerializeField, Range(1f, 10f), Tooltip("何秒間火を消すかの最大時間")]
    float _maxWaitTimeOfReturn = 1f;
    // 火が消えている時間
    private float _waitTimeOfReturn = 0.0f;

    void Start()
    {

    }

    void FixedUpdate()
    {
        DeleteFire();
        CountWaitTimeOfReturn();
    }
    private void CountWaitTimeOfReturn()
    {
        if (_fire.activeInHierarchy) return;
        _waitTimeOfReturn += Time.deltaTime;

        if (_waitTimeOfReturn < _maxWaitTimeOfReturn) return;
        ReBorn();
    }

    private void ReBorn()
    {
        _fire.SetActive(true);
        _touthCount = 0;
        _waitTimeOfReturn = 0.0f;
    }

    private void DeleteFire()
    {
        if (!_fire.activeInHierarchy) return;
        ++_touthCount;

        if (_touthCount > 0) return;
        _fire.SetActive(false);
    }
}
