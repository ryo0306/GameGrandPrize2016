using UnityEngine;
using System.Collections;

public class CameraWork : MonoBehaviour {

    [SerializeField]
    private GameObject player = null;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(player.transform.position.x + 6.25f,0,-10);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.transform.position.x + 6.25f, 0, -10);
    }
}
