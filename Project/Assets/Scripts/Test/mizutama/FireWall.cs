using UnityEngine;
using System.Collections;

public class FireWall : MonoBehaviour
{
    [SerializeField, Tooltip("マイクの情報")]
    private GameObject _mike = null;

    [SerializeField, Tooltip("火の本体,")]
    GameObject _fire = null;

    [SerializeField, Range(1, 5), Tooltip("何回でで火が消えるか")]
    int _maxTouthCount = 1;

    
    private int _touthCount = 0;                   //何回消したか

    [SerializeField, Range(1f, 10f), Tooltip("何秒間火を消すかの最大時間")]
    float _maxWaitTimeOfReturn = 1f;

    [SerializeField, Range(0.0f, 1.0f), Tooltip("次の消化までの時間")]
    public float _maxinterval = 0.0f;

    private float _interval = 0.0f;
        
    private float _waitTimeOfReturn = 0.0f;        // 火が消えている時間


    void Update()
    {
        if (_mike.GetComponent<MikeInput>().nowVolume >= 0.7f)
        {
            _interval += Time.deltaTime;
            Debug.Log(_interval);
        }
        
        CountWaitTimeOfReturn();

        if (_interval < _maxinterval) return;
        _interval = 0.0f;
        DeleteFire();
        
        
    }

    //復活する時間を測る
    private void CountWaitTimeOfReturn()
    {
        if (_fire.activeInHierarchy) return;
        _waitTimeOfReturn += Time.deltaTime;

        if (_waitTimeOfReturn < _maxWaitTimeOfReturn) return;
        ReBorn();
    }

    //復活
    private void ReBorn()
    {
        _fire.SetActive(true);
        _touthCount = 0;
        _waitTimeOfReturn = 0.0f;
    }


    //何回かタッチしたら消える
    private void DeleteFire()
    {
        if (!_fire.activeInHierarchy) return;
        ++_touthCount;

        if (_touthCount < _maxTouthCount) return;
        _fire.SetActive(false);
    }
}
