using UnityEngine;
using System.Collections;

public class FlyP : MonoBehaviour {

    [SerializeField, Tooltip("マイクの情報")]
    private GameObject _mike = null;

    [SerializeField, Tooltip("TitleRoot")]
    private GameObject _titleRoot =  null;

    
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
        _destinationPosition = new Vector3(_destination.x, _destination.y, transform.position.z);
	}
	

	void FixedUpdate() {

        Input();
        if (_start)
        {
            _easeTime +=  Time.deltaTime;
            transform.position = Vector3.Lerp(_startPosition, _destinationPosition, _easeTime);

            if (_easeTime >= 1.0f)
            {
                _titleRoot.GetComponent<TitleRoot>().SceneEnd = true;
            }
        }
	}

    public void Input(){
        if (_mike.GetComponent<MikeInput>().nowVolume >= 0.7f)
        {
            _start = true;
            _titleRoot.GetComponent<TitleRoot>().OperationPossible = false;
        }
    }
}
