using UnityEngine;
using System.Collections;

public class GateDown : MonoBehaviour {
    
    [SerializeField, Tooltip("スイッチの本体")]
    private GameObject _windMill = null;

    // upと同じにしたいので親に持たせるべき？
    [SerializeField, Range(0.0f, 1.0f), Tooltip("開く速度")]
    float _openSpeed = 0.01f;
    [SerializeField, Tooltip("どこまで開くか（Inspectorは親との差）")]
    public float _maxPosition = 0.0f;
    [SerializeField, Tooltip("どこまで閉じるか（Inspectorは親との差）")]
    public float _minPosition = 0.0f;


	void Start () {
	
	}
	

	void Update () {
        //開閉処理
        if (_windMill.GetComponent<WindMill>().GetOpen())
            if (transform.position.y < _maxPosition)
                transform.position += new Vector3(0, _openSpeed, 0);

        if(!_windMill.GetComponent<WindMill>().GetOpen())
            if(transform.position.y > _minPosition)
                transform.position -= new Vector3(0, _openSpeed,0);


	}
}
