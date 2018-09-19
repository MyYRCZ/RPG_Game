using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class questcontrol : SingletonMono<questcontrol>, IPointerEnterHandler, IPointerExitHandler
{
    public bool open = false;
    // Use this for initialization
    public int quest1num;
    public int quest2num;
    protected override void Awake()
    {
        base.Awake();
    }
    void Start () {

     
    }
	
	// Update is called once per frame
	void Update () {
        if(playerattribute.Instance.quest1==1)
        {
            int num = 0;
            for (int i = 0; i < 32; i++)
            {
                if (mybag.Instance.items[i].goodid == 3003)
                {
                    num += mybag.Instance.items[i].num;
                }
            }
            quest1num = num;
        }
     

        if (Input.GetKeyDown(KeyCode.L))
        {
            window();
        }
        if(open)
        {
            if(playerattribute.Instance.quest1==1&& (playerattribute.Instance.quest2==0 || playerattribute.Instance.quest2 == 2))
            {
                this.transform.Find("background").transform.Find("background").transform.Find("Button1").transform.localScale = Vector3.one;
                this.transform.Find("background").transform.Find("background").transform.Find("Button2").transform.localScale = Vector3.zero;
                this.transform.Find("background").transform.Find("background").transform.Find("Button1").transform.Find("Text").GetComponent<Text>().text = quest.Instance.Getqquest(1).Name;

            }
            else  if ((playerattribute.Instance.quest1 == 0 ||playerattribute.Instance.quest1 == 2) && playerattribute.Instance.quest2 == 1)
            {
                this.transform.Find("background").transform.Find("background").transform.Find("Button1").transform.localScale = Vector3.one;
                this.transform.Find("background").transform.Find("background").transform.Find("Button2").transform.localScale = Vector3.zero;
                this.transform.Find("background").transform.Find("background").transform.Find("Button1").transform.Find("Text").GetComponent<Text>().text = quest.Instance.Getqquest(2).Name;
            }
            else  if (playerattribute.Instance.quest1 == 1 && playerattribute.Instance.quest2 == 1)
            {
                this.transform.Find("background").transform.Find("background").transform.Find("Button1").transform.localScale = Vector3.one;
                this.transform.Find("background").transform.Find("background").transform.Find("Button2").transform.localScale = Vector3.one;
                this.transform.Find("background").transform.Find("background").transform.Find("Button1").transform.Find("Text").GetComponent<Text>().text = quest.Instance.Getqquest(1).Name;
                this.transform.Find("background").transform.Find("background").transform.Find("Button2").transform.Find("Text").GetComponent<Text>().text = quest.Instance.Getqquest(2).Name;
            }
            else
            {

                this.transform.Find("background").transform.Find("background").transform.Find("Button1").transform.localScale = Vector3.zero;
                this.transform.Find("background").transform.Find("background").transform.Find("Button2").transform.localScale = Vector3.zero;
            }



        }


    }
    public void openwindow()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
        open = true;
        this.transform.Find("background").transform.Find("info").transform.localScale = Vector3.zero;



    }
    public void closewindow()
    {
        this.transform.localScale = new Vector3(0, 1, 1);
        open = false;
    }
    public void window()
    {
        if (!open)
        {
            openwindow();
        }
        else
        {
            closewindow();
        }
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        FreeLookCam.Instance.ismouseinui = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        FreeLookCam.Instance.ismouseinui = false;
    }
     public void showinfo()
    {
        this.transform.Find("background").transform.Find("info").transform.localScale = Vector3.one;
        var button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
       if( button.GetComponentInChildren<Text>().text==quest.Instance.Getqquest(1).Name)
        {
            this.transform.Find("background").transform.Find("info").GetComponent<Text>().text = quest.Instance.Getqquest(1).info;
            this.transform.Find("background").transform.Find("info").transform.Find("get").transform.Find("expnum").GetComponent<Text>().text = quest.Instance.Getqquest(1).exp+"";
            this.transform.Find("background").transform.Find("info").transform.Find("get").transform.Find("goldnum").GetComponent<Text>().text = quest.Instance.Getqquest(1).gold + "";
            this.transform.Find("background").transform.Find("info").transform.Find("need").transform.Find("info").GetComponent<Text>().text = quest.Instance.Getqquest(1).needinfo + "";
            this.transform.Find("background").transform.Find("info").transform.Find("need").transform.Find("now").GetComponent<Text>().text = quest1num + "";
            this.transform.Find("background").transform.Find("info").transform.Find("need").transform.Find("need").GetComponent<Text>().text = quest.Instance.Getqquest(1).num + "";
          
        }
        if (button.GetComponentInChildren<Text>().text == quest.Instance.Getqquest(2).Name)
        {

            this.transform.Find("background").transform.Find("info").GetComponent<Text>().text = quest.Instance.Getqquest(2).info;
            this.transform.Find("background").transform.Find("info").transform.Find("get").transform.Find("expnum").GetComponent<Text>().text = quest.Instance.Getqquest(2).exp + "";
            this.transform.Find("background").transform.Find("info").transform.Find("get").transform.Find("goldnum").GetComponent<Text>().text = quest.Instance.Getqquest(2).gold + "";
            this.transform.Find("background").transform.Find("info").transform.Find("need").transform.Find("info").GetComponent<Text>().text = quest.Instance.Getqquest(2).needinfo + "";
            this.transform.Find("background").transform.Find("info").transform.Find("need").transform.Find("now").GetComponent<Text>().text = quest2num + "";
            this.transform.Find("background").transform.Find("info").transform.Find("need").transform.Find("need").GetComponent<Text>().text = quest.Instance.Getqquest(2).num + "";
        }
    }
}
