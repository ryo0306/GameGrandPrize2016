using UnityEngine;
using System.Collections;

public class FireWall : MonoBehaviour
{

    [SerializeField, Tooltip("火の本体,")]
    GameObject _fire = null;

    [SerializeField, Range(1, 5), Tooltip("何回でで火が消えるか")]
    int _maxTouthCount = 1;

    
    private int _touthCount = 0;                   // 何回叩いたか

    [SerializeField, Range(1f, 10f), Tooltip("何秒間火を消すかの最大時間")]
    float _maxWaitTimeOfReturn = 1f;

    
    private float _waitTimeOfReturn = 0.0f;        // 火が消えている時間


    void Update()
    {
        //あたり判定（レイキャスト）
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (!Physics.Raycast(ray, out hit)) return;
            if (hit.collider.gameObject.name != transform.name) return;
            DeleteFire();
        }
        CountWaitTimeOfReturn();
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
