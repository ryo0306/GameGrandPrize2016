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
    void Start()
    {
       
        GetComponent<AudioSource>().clip = Microphone.Start(null, true, 999, 44100);  // マイクからのAudio-InをAudioSourceに流す
       
        GetComponent<AudioSource>().loop = true;                                      // ループ再生にしておく

                                          
        GetComponent<AudioSource>().volume = 0.01f;                                   // MuteにするとVolを返さないので0.01にする

        while (!(Microphone.GetPosition("") > 0)) { }                                 // マイクが取れるまで待つ。空文字でデフォルトのマイクを探してくれる
        GetComponent<AudioSource>().Play();                                           // 再生する
    }

    void Update()
    {
        float vol = GetAveragedVolume();
        Debug.Log(vol);
    }

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        GetComponent<AudioSource>().GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a *  256.0f;
    }
}
