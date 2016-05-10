using UnityEngine;
using System.Collections;

/// <summary>
/// inputなど処理をするクラス
/// </summary>
public class SelectStage : MonoBehaviour
{
    [SerializeField, Tooltip("マイクの情報")]

    private GameObject _mike = null;

    private bool _isEnd = false;

    void Start()
    {
       
    }

    void Update()
    {


        IsEnd();
    }

    void IsEnd()
    {
        if (_mike.GetComponent<MikeInput>().nowVolume < 0.7f) return;
        if (_isEnd == true) return;
            SceneChanger.Instance.LoadLevel("Title", 1.0f);
        _isEnd = true;
    }

}
