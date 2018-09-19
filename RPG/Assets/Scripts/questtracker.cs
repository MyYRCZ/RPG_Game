using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class questtracker : MonoBehaviour {
    private bool open=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(open)
        {
            if (playerattribute.Instance.quest1 == 1 && (playerattribute.Instance.quest2 == 0 || playerattribute.Instance.quest2 == 2))
            {
                this.transform.Find("quest group").transform.Find("mission1").transform.localScale = Vector3.one;
                this.transform.Find("quest group").transform.Find("mission2").transform.localScale = Vector3.zero;
                this.transform.Find("quest group").transform.Find("mission1").transform.Find("questname").GetComponent<Text>().text = quest.Instance.Getqquest(1).Name;
                this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").GetComponent<Text>().text = quest.Instance.Getqquest(1).needinfo + "";
                this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").transform.Find("neednum").GetComponent<Text>().text = quest.Instance.Getqquest(1).num+"";
                this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").transform.Find("havedownnum").GetComponent<Text>().text = questcontrol.Instance.quest1num + "";
                if(questcontrol.Instance.quest1num>= quest.Instance.Getqquest(1).num)
                {
                    this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").transform.Find("Image").Find("down").transform.localScale = Vector3.one;
                }
                else
                {
                    this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").transform.Find("Image").Find("down").transform.localScale = Vector3.zero;
                }

            }
            else if ((playerattribute.Instance.quest1 == 0 || playerattribute.Instance.quest1 == 2) && playerattribute.Instance.quest2 == 1)
            {
                this.transform.Find("quest group").transform.Find("mission1").transform.localScale = Vector3.one;
                this.transform.Find("quest group").transform.Find("mission2").transform.localScale = Vector3.zero;
                this.transform.Find("quest group").transform.Find("mission1").transform.Find("questname").GetComponent<Text>().text = quest.Instance.Getqquest(2).Name;
                this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").GetComponent<Text>().text = quest.Instance.Getqquest(2).needinfo + "";
                this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").transform.Find("neednum").GetComponent<Text>().text = quest.Instance.Getqquest(2).num + "";
                this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").transform.Find("havedownnum").GetComponent<Text>().text = questcontrol.Instance.quest2num + "";
                if (questcontrol.Instance.quest2num >= quest.Instance.Getqquest(2).num)
                {
                    this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").transform.Find("Image").Find("down").transform.localScale = Vector3.one;
                }
                else
                {
                    this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").transform.Find("Image").Find("down").transform.localScale = Vector3.zero;
                }
            }
            else if (playerattribute.Instance.quest1 == 1 && playerattribute.Instance.quest2 == 1)
            {
                this.transform.Find("quest group").transform.Find("mission1").transform.localScale = Vector3.one;
                this.transform.Find("quest group").transform.Find("mission2").transform.localScale = Vector3.one;

                this.transform.Find("quest group").transform.Find("mission1").transform.Find("questname").GetComponent<Text>().text = quest.Instance.Getqquest(1).Name;
                this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").GetComponent<Text>().text = quest.Instance.Getqquest(1).needinfo + "";
                this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").transform.Find("neednum").GetComponent<Text>().text = quest.Instance.Getqquest(1).num + "";
                this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").transform.Find("havedownnum").GetComponent<Text>().text = questcontrol.Instance.quest1num + "";
                if (questcontrol.Instance.quest1num >= quest.Instance.Getqquest(1).num)
                {
                    this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").transform.Find("Image").Find("down").transform.localScale = Vector3.one;
                }
                else
                {
                    this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").transform.Find("Image").Find("down").transform.localScale = Vector3.zero;
                }


                this.transform.Find("quest group").transform.Find("mission2").transform.Find("questname").GetComponent<Text>().text = quest.Instance.Getqquest(2).Name;
                this.transform.Find("quest group").transform.Find("mission1").transform.Find("need").GetComponent<Text>().text = quest.Instance.Getqquest(2).needinfo + "";
                this.transform.Find("quest group").transform.Find("mission2").transform.Find("need").transform.Find("neednum").GetComponent<Text>().text = quest.Instance.Getqquest(2).num + "";
                this.transform.Find("quest group").transform.Find("mission2").transform.Find("need").transform.Find("havedownnum").GetComponent<Text>().text = questcontrol.Instance.quest2num + "";
                if (questcontrol.Instance.quest2num >= quest.Instance.Getqquest(2).num)
                {
                    this.transform.Find("quest group").transform.Find("mission2").transform.Find("need").transform.Find("Image").Find("down").transform.localScale = Vector3.one;
                }
                else
                {
                    this.transform.Find("quest group").transform.Find("mission2").transform.Find("need").transform.Find("Image").Find("down").transform.localScale = Vector3.zero;
                }
            }
            else
            {

                this.transform.Find("quest group").transform.Find("mission1").transform.localScale = Vector3.zero;
                this.transform.Find("quest group").transform.Find("mission2").transform.localScale = Vector3.zero;
            }
        }
	}
    public void openwindow()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
        open = true;
      



    }
    public void closewindow()
    {
        this.transform.localScale = new Vector3(0, 1, 1);
        open = false;
    }
    public void window()
    {
        print(11);
        if (!open)
        {
            openwindow();
        }
        else
        {
            closewindow();
        }
    }
}
