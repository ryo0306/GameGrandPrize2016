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
    [SerializeField, Tooltip("マイクの情報")]
    private GameObject _mike = null;

    void Start () {
	
	}


    void Update(){

        if (_mike.GetComponent<MikeInput>().nowVolume >= 0.7f)
        {
            _open = !_open;
        }

    }

    public bool GetOpen()
    {
        return _open;
    } 
}
