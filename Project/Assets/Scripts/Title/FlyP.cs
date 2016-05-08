using UnityEngine;
using System.Collections;

public class FlyP : MonoBehaviour {

    [SerializeField, Tooltip("風の情報")]
    private GameObject _wind = null;

    [SerializeField, Tooltip("シーン全体のマネージャー")]
    private GameObject _sceneManager =  null;

    
    [SerializeField, Range(0.00f, 1.00f), Tooltip("Easingする速さ")]
    public float _timeSpeed = 0.0f;

    private float _easeTime = 0.0f;

    [SerializeField, Tooltip("飛んでいく目的地")]
    public Vector2 _destination;

    private bool _start = false;

    Vector3 _startPosition;
    Vector3 _destinationPosition;

	void Start () {
        _startPosition = transform.position;
        _destinationPosition =new Vector3(_destination.x, _destination.y, transform.position.z);
	}
	

	void FixedUpdate() {

        Input();
        if (_start)
        {
            _easeTime += _timeSpeed * Time.deltaTime * 30;
            transform.position = Vector3.Lerp(_startPosition, _destinationPosition, _easeTime);

            if (_easeTime >= 1.0f)
            {
                _sceneManager.GetComponent<TitleRoot>().SceneEnd();
            }
        }
	}

    public void Input(){
        if (_wind.GetComponent<MikeInput>().nowVolume >= 0.7f)
        {
            _start = true;
            _sceneManager.GetComponent<TitleRoot>().CanPlay = false;
        }
    }
}
