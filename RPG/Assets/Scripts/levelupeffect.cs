using UnityEngine;
using System.Collections;

public class levelupeffect : MonoBehaviour {
    private float nowtime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = playerattribute.Instance.transform.position;
        nowtime += Time.deltaTime;
        if(nowtime>=3)
        {
            Destroy(this.gameObject);
        }



    }
}
