using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;
    private Vector3 uppush;
    // Use this for initialization
    void Start () {
        // offset = transform.position - player.transform.position;
        uppush = new Vector3(0, 2, 0);
            
    }
	
	// Update is called once per frame
	void Update () {
       // transform.position = player.transform.position + offset;
        this.transform.LookAt(player.transform.position+uppush);
	}
}
