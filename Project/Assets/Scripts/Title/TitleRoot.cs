using UnityEngine;
using System.Collections;


/// <summary>
/// 5/7 今井作成
/// シーンの終了や操作できるかなど
/// シーン全体のフラグを管理
/// </summary>
public class TitleRoot : MonoBehaviour {


    [SerializeField, Tooltip("Sceneがおわるかどうか")]
    public bool _sceneEnd = false;

    [SerializeField, Tooltip("操作できるかどうか")]
    public bool _operationPossible = true;

    void Start () {
	
	}
	

	void Update () {
	
        if(_sceneEnd)
        {
            //ここでシーン切り替え
        }
	}

    /// <summary>
    /// 操作できるかどうか
    /// </summary>
    public bool CanPlay
    {
        get{ return _operationPossible; }

        set{ _operationPossible = value; }
    }
    /// <summary>
    /// シーンがおわったかどうか
    /// </summary>
    public void SceneEnd()
    {
        _sceneEnd = true;
    }
}
