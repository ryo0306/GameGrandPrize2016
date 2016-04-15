using UnityEngine;
using System.Collections;


//TODO:WindMill&Gate{WindMill, Gate}という
//     親子関係でプレハブにすると
//     このコードではGateが全て開いてしまう。
//     理由としてGateがOpenのフラグをみる時
//     名前検索をしていて同じものを
//     見てしまっているからだと思われる。

public class WindMill : MonoBehaviour {

    [SerializeField, Tooltip("ゲートが開いてるか")]
    bool _open = false;

	void Start () {
	
	}
	
	
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (!Physics.Raycast(ray, out hit)) return;
            if (hit.collider.gameObject.name != transform.name) return;
            Debug.Log(transform.name);
            _open = !_open;
        }
    }

    public bool GetOpen()
    {
        return _open;
    } 
}
