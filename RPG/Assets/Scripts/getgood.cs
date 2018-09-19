using UnityEngine;
using System.Collections;

public class getgood : SingletonMono<getgood> {
    public float nowtime;
    protected override void Awake()
    {
        base.Awake();
    }

    // Use this for initialization
    void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {
        if (nowtime != 0)
        {
            nowtime += Time.deltaTime;
            this.transform.localScale = Vector3.one;

            if (nowtime >= 8)
            {
                nowtime = 0;
                mybag.Instance.addgood(3003);
            }
        }
        else
        {
            this.transform.localScale = Vector3.zero;
        }
    }
    public void showgetgood(Vector3 vec3)
    {
        print(1111111111111111);
        this.transform.position = vec3;
        nowtime = 0.01f;
    }
    public void add()
    {

        nowtime = 0;
        mybag.Instance.addgood(3003);
    }
}
