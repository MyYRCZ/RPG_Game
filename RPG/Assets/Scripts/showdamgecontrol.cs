using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showdamgecontrol : SingletonMono<showdamgecontrol> {
    public GameObject damage;
    protected override void Awake()
    {
        base.Awake();
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void adddamge(Sprite sp,int num)
    {
        GameObject go = Instantiate(damage, this.transform)as GameObject;
        go.transform.Find("Image").GetComponent<Image>().sprite = sp;
        if(num>0)
        go.transform.Find("num").GetComponent<Text>().text ="+"+ num;
        else
        {
            go.transform.Find("num").GetComponent<Text>().text = "" + num;
        }
    }
}
