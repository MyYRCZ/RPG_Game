using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelupshow : SingletonMono<levelupshow> {

    float nowtime = 0;
    public GameObject effect;
    protected override void Awake()
    {
        base.Awake(); 
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(nowtime!=0)
        {
            nowtime += Time.deltaTime;
            this.transform.localScale = Vector3.one;
            this.transform.Find("level").GetComponent<Text>().text = "" + playerattribute.Instance.level;
            if(nowtime>=5)
            {
                nowtime = 0;
            }
        }
        else
        {
            this.transform.localScale = Vector3.zero;
        }
	}
   public  void showlevelup()
    {
        nowtime = 0.01f;
        GameObject go = Instantiate(effect,playerattribute.Instance.transform) as GameObject;
    }
}
