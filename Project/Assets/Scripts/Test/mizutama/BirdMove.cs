using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour
{
    Rigidbody2D rigidbody2D;


    //メインカメラのタグ名　constは定数(絶対に変わらない値)
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    //カメラに映っているかの判定
    private bool _isRendered = false;


    [SerializeField, Range(1, 50), Tooltip("移動速度,")]
    float _speed = 0.0f;


    void OnTriggerEnter2D(Collider2D col)
    {
      
        if (_isRendered)
        {

        }
        
    }

    //Rendererがカメラに映ってる間に呼ばれ続ける
    void OnWillRenderObject()
    {
        //メインカメラに映った時だけ_isRenderedをtrue
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            _isRendered = true;
        }
    }

    void Update()
    {

        if (_isRendered)
        {
            transform.position -= new Vector3(_speed * Time.deltaTime, 0, 0);    
        }

    }
}
