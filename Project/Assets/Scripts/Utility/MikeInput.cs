using UnityEngine;
using System.Collections;

/// <summary>
/// 4 /15 野本　変更開始
/// 
/// 
/// マイク入力を受け取るクラス(Test)
/// Webコードを参考にしている
/// 
/// </summary>

public class MikeInput : MonoBehaviour
{
    private float _nowVol = 0f;

    public float nowVolume
    {
        get { return _nowVol; }
        //Setは外で使うことはないが、もしもの時に０にするために用意している
        set { _nowVol = value; }
    }

    void Start()
    {

        GetComponent<AudioSource>().clip = Microphone.Start(null, true, 999, 44100);  // マイクからのAudio-InをAudioSourceに流す

        GetComponent<AudioSource>().loop = true;                                      // ループ再生にしておく


        GetComponent<AudioSource>().volume = 0.01f;                                   // MuteにするとVolを返さないので0.01にする

        while (!(Microphone.GetPosition("") > 0)) { }                                 // マイクが取れるまで待つ。空文字でデフォルトのマイクを探してくれる
        GetComponent<AudioSource>().Play();                                           // 再生する
    }


    //Fixedのほうがいいのか質問する
    void Update()
    {
        _nowVol = GetAveragedVolume();
    }

    public float GetAveragedVolume()
    {
        float[] data = new float[256];
        float soundSize = 0;
        GetComponent<AudioSource>().GetOutputData(data, 0);
        foreach (float s in data)
        {
            soundSize += Mathf.Abs(s);
        }
        //Max値は１に設定
        if (soundSize > 1f) soundSize = 1.0f;
        else if (soundSize < 0.1f) soundSize = 0.0f;
        return soundSize * 3f;
    }
}
