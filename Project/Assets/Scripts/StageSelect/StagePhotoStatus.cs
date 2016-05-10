using UnityEngine;
using System.Collections;

public class StagePhotoStatus : MonoBehaviour {

    public bool _slide = false;

    //スライドする方向
    private float _direction = 1.0f;

    public float _easeTime = 0.0f;

    void Start () {
	
	}
	
	
	void Update () {
        if (!_slide) return;
        _easeTime += 0.01f*Time.deltaTime *100;

        if (_easeTime < 1.0f) return;
        _slide = false;
	}

    public void PushRightButton()
    {
        if (_slide) return;
        _easeTime = 0.0f;
        _slide = true;
        _direction = 1.0f;
    }


    public void PushLeftButton()
    {
        if (_slide) return;
        _easeTime = 0.0f;
        _slide = true;
        _direction = -1.0f;
    }

    public bool Slide
    {
        get { return _slide; }
        set { _slide = value; }
    }

    public float Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public float EaseTime
    {
        get { return _easeTime; }
        set { _easeTime = value; }
    }
}
