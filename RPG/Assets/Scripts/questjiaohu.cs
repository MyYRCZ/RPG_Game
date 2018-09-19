using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class questjiaohu : SingletonMono<questjiaohu> {

    private bool open;
    private int questid;
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
    public void openwindow(int id)
    {
        this.transform.localScale = new Vector3(1, 1, 1);
        open = true;
        questid = id;
       

        if (id==1)
        {
           
            this.transform.Find("background").transform.Find("info").GetComponent<Text>().text = quest.Instance.Getqquest(1).info;
            this.transform.Find("background").transform.Find("info").transform.Find("get").transform.Find("expnum").GetComponent<Text>().text = quest.Instance.Getqquest(1).exp + "";
            this.transform.Find("background").transform.Find("info").transform.Find("get").transform.Find("goldnum").GetComponent<Text>().text = quest.Instance.Getqquest(1).gold + "";
            this.transform.Find("background").transform.Find("info").transform.Find("need").transform.Find("info").GetComponent<Text>().text = quest.Instance.Getqquest(1).needinfo + "";
            this.transform.Find("background").transform.Find("info").transform.Find("need").transform.Find("now").GetComponent<Text>().text =questcontrol.Instance. quest1num + "";
            this.transform.Find("background").transform.Find("info").transform.Find("need").transform.Find("need").GetComponent<Text>().text = quest.Instance.Getqquest(1).num + "";
            if(playerattribute.Instance.quest1 == 0)
            {
                this.transform.Find("background").Find("Button").Find("Text").GetComponent<Text>().text = "接受任务";
            }
            if (playerattribute.Instance.quest1==1)
            {
                this.transform.Find("background").Find("Button").Find("Text").GetComponent<Text>().text = "完成任务";
            }
        }
        if (id==2)
        {

            this.transform.Find("background").transform.Find("info").GetComponent<Text>().text = quest.Instance.Getqquest(2).info;
            this.transform.Find("background").transform.Find("info").transform.Find("get").transform.Find("expnum").GetComponent<Text>().text = quest.Instance.Getqquest(2).exp + "";
            this.transform.Find("background").transform.Find("info").transform.Find("get").transform.Find("goldnum").GetComponent<Text>().text = quest.Instance.Getqquest(2).gold + "";
            this.transform.Find("background").transform.Find("info").transform.Find("need").transform.Find("info").GetComponent<Text>().text = quest.Instance.Getqquest(2).needinfo + "";
            this.transform.Find("background").transform.Find("info").transform.Find("need").transform.Find("now").GetComponent<Text>().text = questcontrol.Instance.quest2num + "";
            this.transform.Find("background").transform.Find("info").transform.Find("need").transform.Find("need").GetComponent<Text>().text = quest.Instance.Getqquest(2).num + "";
            if (playerattribute.Instance.quest2 == 0)
            {
                this.transform.Find("background").Find("Button").Find("Text").GetComponent<Text>().text = "接受任务";
            }
            if (playerattribute.Instance.quest2 == 1)
            {
                this.transform.Find("background").Find("Button").Find("Text").GetComponent<Text>().text = "完成任务";
            }
        }


    }
    public void buttondown()
    {
       
        if(questid==1)
        {
            if(playerattribute.Instance.quest1==0)
            {
                playerattribute.Instance.quest1 = 1;
             
                this.transform.localScale = new Vector3(0, 1, 1);
                open = false;
            }
            if (playerattribute.Instance.quest1 == 1)
            {
                if(questcontrol.Instance.quest1num>= quest.Instance.Getqquest(1).num)
                {
                    playerattribute.Instance.quest1 = 2;
                    playerattribute.Instance.gold += quest.Instance.Getqquest(1).gold;
                    playerattribute.Instance.exp += quest.Instance.Getqquest(1).exp;
                    this.transform.localScale = new Vector3(0, 1, 1);
                    open = false;
                }
                 
            }
        }
        if (questid == 2)
        {
            if (playerattribute.Instance.quest2== 0)
            {
                questcontrol.Instance.quest2num = 0;
                playerattribute.Instance.quest2 = 1;
                this.transform.localScale = new Vector3(0, 1, 1);
                open = false;
            }
            if (playerattribute.Instance.quest2 == 1)
            {
                if (questcontrol.Instance.quest2num >= quest.Instance.Getqquest(2).num)
                {
                    playerattribute.Instance.quest2 = 2;
                    playerattribute.Instance.gold += quest.Instance.Getqquest(2).gold;
                    playerattribute.Instance.exp += quest.Instance.Getqquest(2).exp;
                    this.transform.localScale = new Vector3(0, 1, 1);
                    open = false;
                }

            }
        }

       

    }
    public void closewindow()
    {
        this.transform.localScale = new Vector3(0, 1, 1);
        open = false;
    }
}
