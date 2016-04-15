using UnityEngine;
using System.Collections;

public class TestPlayAudio : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        FindObjectOfType<AudioManager>().PlayBGM("Slash",true);
    }
}
