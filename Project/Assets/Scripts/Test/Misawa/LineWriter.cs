using UnityEngine;
using System.Collections;

/*
作成日:2016/04/15
作成者:三澤裕樹
*/

public class LineWriter : MonoBehaviour
{

    [SerializeField, Tooltip("ついてくるプレイヤー")]
    private GameObject player = null;

    //初期位置をプレイヤーの位置に設定
    void OnEnable()
    {
        this.transform.position = player.transform.position;
    }

    //クリックされているときその位置にマーカーが移動する
    void Update()
    {
        this.transform.position = GetMousePointInWorld();
    }

/*    //ドラッグしたらマーカーが移動する
    void OnMouseDrag()
    {
        this.transform.position = GetMousePointInWorld();
    }
*/
    Vector3 GetMousePointInWorld()
    {
        Vector3 objectPointInScreen
            = Camera.main.WorldToScreenPoint(this.transform.position);

        Vector3 mousePointInScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPointInScreen.z);

        Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
        mousePointInWorld.z = this.transform.position.z;
        return mousePointInWorld;
    }
}
