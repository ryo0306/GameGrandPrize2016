using UnityEngine;
using System.Collections;

public class NodeRemover : MonoBehaviour {

//    [SerializeField, Tooltip("ノードとして配置したオブジェクトを何秒後に消すか")]
//    float _deleteTime = 3;

    // Use this for initialization
    //	void Start () {

    //    }
    public void Remove()
    {
        GameObject.Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        Remove();
    }
}
