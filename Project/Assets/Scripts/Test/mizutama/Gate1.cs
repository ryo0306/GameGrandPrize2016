using UnityEngine;
using System.Collections;

public class Gate1 : MonoBehaviour {


    [SerializeField, Tooltip("スイッチの本体")]
    private GameObject _windMill = null;

    [SerializeField, Range(0.0f, 1.0f), Tooltip("開く速度")]
    float _upSpeed = 0.01f;
    [SerializeField,Tooltip("どこまで開くか(座標は親との差)")]
    public float _maxPosition = 5.14f;
    [SerializeField, Tooltip("どこまで閉じるか(座標は親との差)")]
    public float _minPosition = 0.0f;
	void Start () {
	
	}
	
	void Update () {
        if (_windMill.GetComponent<WindMill>().GetOpen()) 
        if(transform.position.y < _maxPosition)
        transform.position +=new Vector3(0, _upSpeed, 0);

        if(!_windMill.GetComponent<WindMill>().GetOpen())
            if(transform.position.y > _minPosition)
                transform.position -= new Vector3(0, _upSpeed, 0);
    }
}
