using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class characterwindow : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler{
    private Transform message;
    public bool open = false;

	// Use this for initialization
	void Start () {
      
        message = this.transform.Find("scoll rect").transform.Find("right");
       
    }
	
	// Update is called once per frame
	void Update () {
   
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(!open)
            {
                openwindow();
            }
            else
            {
                closewindow();
            }
        }
        if(open)
        {
            this.transform.Find("left").transform.Find("name").GetComponent<Text>().text = playerattribute.Instance.Playername + "";
            message.Find("level").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.level + "";
            message.Find("exp").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.exp + "";
            message.Find("exp").transform.Find("need").GetComponent<Text>().text = 100 + "";
            message.Find("liliang").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.strength + "";
            message.Find("minjie").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.agility + "";
            message.Find("zhili").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.intelligence + "";
            message.Find("naili").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.stamina + "";
            message.Find("hp").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.Max_Hp + "";
            message.Find("mp").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.Max_Mp + "";
            message.Find("baoji").transform.Find("now").GetComponent<Text>().text = string.Format("{0:0.00}", playerattribute.Instance.crits); ;
           
            message.Find("jisu").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.rapidly + "";
            message.Find("gongqiang").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.attack + "";
            message.Find("faqiang").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.magic + "";
            message.Find("hujia").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.def + "";

        }

    }
    public void openwindow()
    {
       
        this.transform.parent.GetComponent<Canvas>().sortingOrder = 6;
        this.transform.localScale = new Vector3(1, 1, 1);
        this.transform.Find("left").transform.Find("name").GetComponent<Text>().text= playerattribute.Instance.Playername + "";
        message.Find("level").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.level+"";
        message.Find("exp").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.exp + "";
        message.Find("exp").transform.Find("need").GetComponent<Text>().text = 100 + "";
        message.Find("liliang").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.strength + "";
        message.Find("minjie").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.agility + "";
        message.Find("zhili").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.intelligence + "";
        message.Find("naili").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.stamina + "";
        message.Find("hp").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.Max_Hp + "";
        message.Find("mp").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.Max_Mp + "";
        message.Find("baoji").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.crits + "";
        message.Find("jisu").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.rapidly + "";
        message.Find("gongqiang").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.attack + "";
        message.Find("faqiang").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.magic + "";
        message.Find("hujia").transform.Find("now").GetComponent<Text>().text = playerattribute.Instance.def + "";
        this.transform.Find("Scrollbar").GetComponent<Scrollbar>().value = 1;
        open = true;


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
    
}