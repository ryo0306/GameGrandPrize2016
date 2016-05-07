using UnityEngine;
using System.Collections;

/// <summary>
/// inputなど処理をするクラス
/// </summary>
public class SelectStage : MonoBehaviour
{
    [SerializeField, Tooltip("風の情報")]
    private GameObject _wind = null;
    [SerializeField, Tooltip("シーン管理のマネージャー")]
    private GameObject _sceneManager = null;
  

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    void Input()
    {
        if (_wind.GetComponent<MikeInput>().nowVolume >= 0.7f)
        {
            _sceneManager.GetComponent<SceneManager>().CanPlay = false;
        }
        //何かしらのアニメーションの後にSceneEndを呼び出して終わり
    }
}
