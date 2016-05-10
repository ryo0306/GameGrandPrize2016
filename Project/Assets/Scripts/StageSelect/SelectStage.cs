using UnityEngine;
using System.Collections;

/// <summary>
/// inputなど処理をするクラス
/// </summary>
public class SelectStage : MonoBehaviour
{
    [SerializeField, Tooltip("マイクの情報")]
    private GameObject _mike = null;

  

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

        }
    }
}
