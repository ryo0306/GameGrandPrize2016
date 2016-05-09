using UnityEngine;
using System.Collections;

/// <summary>
/// inputなど処理をするクラス
/// </summary>
public class SelectStage : MonoBehaviour
{
    [SerializeField, Tooltip("マイクの情報")]
    private GameObject _mike = null;
    [SerializeField, Tooltip("シーン管理のマネージャー")]
    private GameObject _titleRoot = null;
  

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    void Input()
    {
        if (_mike.GetComponent<MikeInput>().nowVolume >= 0.7f)
        {
            _titleRoot.GetComponent<TitleRoot>().OperationPossible = false;
        }
    }
}
