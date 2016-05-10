using UnityEngine;
using System.Collections;

/// <summary>
/// inputなど処理をするクラス
/// </summary>
public class SelectStage : MonoBehaviour
{
    [SerializeField, Tooltip("マイクの情報")]
    private GameObject _mike = null;

    [SerializeField, Tooltip("ステージの番号取得")]
    private GameObject _stageNum = null;

    [SerializeField, Tooltip("StagePhotoの情報")]
    private GameObject _stagePhotoStatus = null;


    private bool _isEnd = false;

    private int _nowStageNum = 1;

  

    [SerializeField, Tooltip("ステージの数")]
    //TODO:余裕があったらオブジェクトの数を数えるようにする
    public int _maxStageNum = 3;

    void Start()
    {
        _nowStageNum = _stageNum.GetComponent<StageStatus>().SelectGameNum;
        Debug.Log(_nowStageNum);
    }

    void Update()
    {
        IsEnd();
    }

    public void PushLeftButton()
    {
        if (_stagePhotoStatus.GetComponent<StagePhotoStatus>().Slide) return;
        _nowStageNum++;
        if (_nowStageNum > _maxStageNum)
            _nowStageNum = 1;
        _stageNum.GetComponent<StageStatus>().SelectGameNum = _nowStageNum;
        Debug.Log(_nowStageNum);
    }

    public void PushRightButton()
    {
        if (_stagePhotoStatus.GetComponent<StagePhotoStatus>().Slide) return;
        _nowStageNum--;
        if (_nowStageNum < 1)
            _nowStageNum = _maxStageNum;
        _stageNum.GetComponent<StageStatus>().SelectGameNum = _nowStageNum;
        Debug.Log(_nowStageNum);
    }


    public void IsEnd()
    {
        if (_mike.GetComponent<MikeInput>().nowVolume < 0.7f) return;
        if (_isEnd == true) return;
        //    SceneChanger.Instance.LoadLevel("Title", 1.0f);
        //_isEnd = true;
    }

}
