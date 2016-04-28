using UnityEngine;
using System.Collections;

public class Message : MonoBehaviour {

    [SerializeField, Range(0.00f, 0.10f), Tooltip("変化する速さ")]
    public float _changeSpeed;

    private float _alpha;

	
	void Start () {
        _alpha = 1.0f;
	}
	
	
	void Update () {
        if (_alpha > 1.0f)
            _changeSpeed = -_changeSpeed;

        if (_alpha < 0.0f)
            _changeSpeed = -_changeSpeed;

        _alpha -= _changeSpeed;


        this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, _alpha);
	}
}
