using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene移行するときにFadeをいれます。
/// 
/// よび方：FadeManager.Instance.LoadLevel("移動するScene名",掛ける秒数);
/// </summary>


public class SceneChanger : MonoBehaviour
{
    //fadeさせるためのTexture
    private Texture2D _fadeTexture;

    //Alpha値
    private float _fadeAlpha = 0.0f;

    //fadeしているか
    private bool _isFading = false;

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

        _fadeTexture = new Texture2D(32, 32, TextureFormat.RGB24, false);
        _fadeTexture.ReadPixels(new Rect(0, 0, 32, 32), 0, 0, false);
        _fadeTexture.SetPixel(0, 0, Color.white);
        _fadeTexture.Apply();
    }

    public void LoadLevel(string scene, float interval)
    {
        StartCoroutine(TransScene(scene, interval));
    }

    private IEnumerator TransScene(string scene, float interval)
    {
        //暗くなる処理
        _isFading = true;
        float _time = 0;
        while (_time <= interval)
        {
            _fadeAlpha = Mathf.Lerp(0f, 1f, _time / interval);
            _time += Time.deltaTime;
            yield return 0;
        }

        //シーン切替
        SceneManager.LoadScene(scene);

        //明るくなる処理
        _time = 0;
        while (_time <= interval)
        {
            _fadeAlpha = Mathf.Lerp(1f, 0f, _time / interval);
            _time += Time.deltaTime;
            yield return 0;
        }

        _isFading = false;
    }

}


