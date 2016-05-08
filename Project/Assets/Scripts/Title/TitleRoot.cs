using UnityEngine;
using System.Collections;


/// <summary>
/// 5/7 今井作成
/// シーンの終了や操作できるかなど
/// シーン全体のフラグを管理
/// </summary>
public class TitleRoot : MonoBehaviour
{
    [SerializeField, Tooltip("Sceneがおわるかどうか")]
    public bool _sceneEnd = false;

    [SerializeField, Tooltip("操作できるかどうか")]
    public bool _operationPossible = true;


    //Scene移行するときに全ての処理をしないようにする。
    private bool _isEnd = false;

    /// <summary>
    /// 操作できるかどうか
    /// </summary>
    public bool CanPlay
    {
        get { return _operationPossible; }

        set { _operationPossible = value; }
    }

    void Update()
    {
        if (!_sceneEnd) return;
        if (_isEnd == true) return;
        SceneChanger.Instance.LoadLevel("StageSelect", 1.0f);
        Debug.Log("Hit");
        _isEnd = true;
    }
    /// <summary>
    /// シーンがおわったかどうか
    /// </summary>
    public void SceneEnd()
    {
        _sceneEnd = true;
    }
}
