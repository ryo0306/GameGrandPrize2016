using UnityEngine;
using System.Collections;

public class NextSceneSample : MonoBehaviour
{

    private GameObject _dataManager = null;

    int _retryCount = 0;
// Use this for initialization
void Start () {
        if ((_dataManager = GameObject.Find("DataManager")) == null)
        {
            Debug.Log("DataManagerが見つかりません");
        }
        else
        {
            _retryCount = _dataManager.GetComponent<Score>().GetCount();
            Destroy(_dataManager);
        }
        Debug.Log(_retryCount);
    }

    // Update is called once per frame
    void Update () {
    }
}