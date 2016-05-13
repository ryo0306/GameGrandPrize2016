using UnityEngine;
using System.Collections;

//スコア保存用のクラス
//DataManagerが次シーンに移動してもオブジェクトが残るのでアタッチされてるこのスクリプトのデータも残る
//データを見たいときはFindでDataManagerを探してから使ってください
//使わなくなったら明示的にDestroyしてください
/*
使用例:
    private GameObject _dataManager = null;

    if((_dataManager = GameObject.Find("DataManager")) == null)
       {
           Debug.Log("DataManagerが見つかりません");
       }
    
    _dataManager.GetComponent<Score>().AddCount();
*/

public class Score : MonoBehaviour
{

    static GameObject _instance = null;

    void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //リトライ回数
    private static int _retryCount = 0;

	// Use this for initialization
	void Start () {
        _retryCount = 0;
    }

    public void Reset(){
        _retryCount = 0;
    }

    public void AddCount()
    {
        _retryCount++;
    }

    public int GetCount()
    {
        return _retryCount;
    }
}
