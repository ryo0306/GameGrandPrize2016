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

    private bool _isOpening = false;

    void Start () {
	
	}


    void Update(){

        if (_isOpening) return;
        if (_mike.GetComponent<MikeInput>().nowVolume < 0.7f) return;
            _open = !_open;
            _isOpening = true;
        

    }

    public bool GetOpen()
    {
        return _open;
    }
    
    public bool IsOpenig
    {
        get { return _isOpening; }
        set { _isOpening = value; }
    } 
}
