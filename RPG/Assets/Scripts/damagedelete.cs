using UnityEngine;
using System.Collections;

public class damagedelete : MonoBehaviour {

    private float nowtime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        nowtime += Time.deltaTime;
        if(nowtime>=3)
        {
            Destroy(this.gameObject);
        }

    }
}
