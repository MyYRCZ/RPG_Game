using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uitextcontrol : SingletonMono<uitextcontrol> {

    private float nowtime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(nowtime!=0)
        {
            nowtime += Time.deltaTime;
            if(nowtime>=2f)
            {
                this.GetComponent<Text>().text = "";
                nowtime = 0;
            }
        }
    else
        {
            this.GetComponent<Text>().text = "";
        }
	}
    public void  addtext(string tx)
    {
        nowtime = 0.01f;
        this.GetComponent<Text>().text = tx;

    }
}
