using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Targetuicontrol : MonoBehaviour,IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
{


    public bool canmove = false;
    private bool ismove;
    private Vector2 movepos;
    private Vector2 nowpos;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        FreeLookCam.Instance.ismouseinui = true;
        if (Input.GetMouseButtonDown(0) && canmove)
        {
            movepos = Input.mousePosition;
            nowpos = this.transform.position;
            ismove = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (!canmove)
            {
                this.transform.Find("Button").localScale = Vector3.one;
                this.transform.Find("Button").Find("Text").GetComponent<Text>().text = "解锁框体";
                this.transform.Find("Button").position = Input.mousePosition;

            }
            else
            {
                this.transform.Find("Button").localScale = Vector3.one;
                this.transform.Find("Button").Find("Text").GetComponent<Text>().text = "锁定框体";
                this.transform.Find("Button").position = Input.mousePosition;
            }

        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
      
        this.transform.Find("Button").localScale = Vector3.zero;
    }

   
    public void chgange()
    {
        canmove = !canmove;
        this.transform.Find("Button").localScale = Vector3.zero;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(playerattribute.Instance.Target!=null)
        {

            if (playerattribute.Instance.Target.tag == "Player")
            {
                this.transform.localScale = new Vector3(1, 1, 1);
                this.transform.Find("namebackground").transform.Find("Text").GetComponent<Text>().text = playerattribute.Instance.Playername + "";//玩家名字
                this.transform.Find("MP").GetComponent<Image>().fillAmount = playerattribute.Instance.Now_Mp / playerattribute.Instance.Max_Mp;
                this.transform.Find("MP").transform.Find("Text").GetComponent<Text>().text = float.Parse(string.Format("{0:0.00}", playerattribute.Instance.Now_Mp / playerattribute.Instance.Max_Mp))*100  + "%";
                this.transform.Find("HP").GetComponent<Image>().fillAmount = playerattribute.Instance.Now_Hp / playerattribute.Instance.Max_Hp;
                this.transform.Find("HP").transform.Find("Text").GetComponent<Text>().text = float.Parse(string.Format("{0:0.00}", playerattribute.Instance.Now_Hp / playerattribute.Instance.Max_Hp)) * 100 + "%";
                Texture sp = Resources.Load("playercam", typeof(RenderTexture)) as Texture;
                this.transform.Find("mask").transform.Find("head").GetComponent<RawImage>().texture = sp;//修改怪物头像  留空

           
                    this.transform.Find("level").transform.Find("Image").transform.localScale = new Vector3(0, 0, 0);
                    this.transform.Find("level").transform.Find("Text").GetComponent<Text>().text = playerattribute.Instance.level + "";

            }

            if (playerattribute.Instance.Target.tag=="Monster")
            {
                this.transform.localScale = new Vector3(1, 1, 1);
                this.transform.Find("namebackground").transform.Find("Text").GetComponent<Text>().text = playerattribute.Instance.Target.GetComponentInChildren<enemyattribute>().monstername + "";//怪物名字
                this.transform.Find("MP").GetComponent<Image>().fillAmount = playerattribute.Instance.Target.GetComponentInChildren<enemyattribute>().Now_Mp / playerattribute.Instance.Target.GetComponentInChildren<enemyattribute>().Max_Mp;
                this.transform.Find("MP").transform.Find("Text").GetComponent<Text>().text = float.Parse(string.Format("{0:0.00}", playerattribute.Instance.Target.GetComponentInChildren<enemyattribute>().Now_Mp / playerattribute.Instance.Target.GetComponentInChildren<enemyattribute>().Max_Mp)) * 100 + "%";
                this.transform.Find("HP").GetComponent<Image>().fillAmount = playerattribute.Instance.Target.GetComponentInChildren<enemyattribute>().Now_Hp / playerattribute.Instance.Target.GetComponentInChildren<enemyattribute>().Max_Hp;
                this.transform.Find("HP").transform.Find("Text").GetComponent<Text>().text = float.Parse(string.Format("{0:0.00}", playerattribute.Instance.Target.GetComponentInChildren<enemyattribute>().Now_Hp / playerattribute.Instance.Target.GetComponentInChildren<enemyattribute>().Max_Hp)) * 100 + "%";
                Texture sp = Resources.Load(playerattribute.Instance.Target.GetComponentInChildren<enemyattribute>().image, typeof(Texture)) as Texture;
                this.transform.Find("mask").transform.Find("head").GetComponent<RawImage>().texture = sp;//修改怪物头像  留空

                if (playerattribute.Instance.Target.GetComponentInChildren<enemyattribute>().isboss)
                {
                    this.transform.Find("level").transform.Find("Image").transform.localScale = new Vector3(1, 1, 1);
                    this.transform.Find("level").transform.Find("Text").GetComponent<Text>().text = "";
                }
                else
                {
                    this.transform.Find("level").transform.Find("Image").transform.localScale = new Vector3(0, 0, 0);
                    this.transform.Find("level").transform.Find("Text").GetComponent<Text>().text = playerattribute.Instance.Target.GetComponentInChildren<enemyattribute>().level + "";
                }
            }

            if (playerattribute.Instance.Target.tag == "NPC")
            {
                this.transform.localScale = new Vector3(1, 1, 1);
                this.transform.Find("namebackground").transform.Find("Text").GetComponent<Text>().text = "任务使者";//怪物名字

                this.transform.Find("level").transform.Find("Image").transform.localScale = new Vector3(1, 1, 1);
                this.transform.Find("level").transform.Find("Text").GetComponent<Text>().text = "";

                this.transform.Find("MP").GetComponent<Image>().fillAmount = 1;
                this.transform.Find("MP").transform.Find("Text").GetComponent<Text>().text = "100%";
                this.transform.Find("HP").GetComponent<Image>().fillAmount =1;
                this.transform.Find("HP").transform.Find("Text").GetComponent<Text>().text = "100%";
                Texture sp = Resources.Load("monsterimage/NPC", typeof(Texture)) as Texture;
                this.transform.Find("mask").transform.Find("head").GetComponent<RawImage>().texture = sp;//修改怪物头像  留空

            }



            }
        else
        {
            this.transform.localScale = new Vector3(0, 0, 0);
        }

        if (ismove && canmove)
        {
            Vector2 offset = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - movepos;
            this.transform.position = nowpos + offset;
            if (Input.GetMouseButtonUp(0))
            {
                ismove = false;
            }
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        FreeLookCam.Instance.ismouseinui = false;
       
 
    }
}
