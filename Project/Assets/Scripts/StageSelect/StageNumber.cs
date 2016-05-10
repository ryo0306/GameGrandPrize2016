using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageNumber : MonoBehaviour {

    [SerializeField, Tooltip("ステージの情報")]
    private GameObject _stageStatus = null;

	void Start () {
	
	}
	

	void Update () {
        this.GetComponent<Text>().text = "Stage" + _stageStatus.GetComponent<StageStatus>().SelectGameNum.ToString();
	}
}
