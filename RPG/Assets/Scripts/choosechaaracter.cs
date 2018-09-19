using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class choosechaaracter : SingletonMono<choosechaaracter> {
    public GameObject[] characters;
    public int currentChar = 0;
    public Text text;

    public static bool zhongzu=true;
    public static string playername;
    public int type=1;
    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
    }
    void Start () {
        type = 1;
        zhongzu = true;

    }
	
	// Update is called once per frame
	void Update () {

        playername  = text.text;

        if (zhongzu)
        {
            if (type==1)
            {
                currentChar = 0;
            }
            if (type == 2)
            {
                currentChar = 1;
            }
            if (type == 3)
            {
                currentChar = 2;
            }

        }
        else if(!zhongzu)
        {
            if (type == 1)
            {
                currentChar = 4;
            }
            if (type == 2)
            {
                currentChar = 5;
            }
            if (type == 3)
            {
                currentChar = 6;

            }
        }


        foreach (GameObject child in characters)
        {
            if (child == characters[currentChar])
                child.SetActive(true);
            else
            {
                child.SetActive(false);

                if (child.GetComponent<triggerProjectile>())
                    child.GetComponent<triggerProjectile>().clearProjectiles();
            }
        }

    }
    public  void changezhongzu(int i)
    {
        if(i==1)
        {
            zhongzu = true;
           
        }
        else if(i==2)
        {
            zhongzu = false;
           
        }
      
    }
    public void changetype(int i)
    {
        if(i==1)
        {
            type = 1;
        }
       else if (i ==2)
        {
            type = 2;
        }
      else if (i == 3)
        {
            type = 3;
        }
    }
}
