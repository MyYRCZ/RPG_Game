using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class playeruicontrol : MonoBehaviour, IPointerDownHandler,IPointerUpHandler,IPointerExitHandler
{

    public bool canmove=false;
    private bool ismove;
    private Vector2 movepos;
    private Vector2 nowpos;

   

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        FreeLookCam.Instance.ismouseinui = true;
        if (Input.GetMouseButtonDown(0)&&canmove)
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

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        FreeLookCam.Instance.ismouseinui = false;

        if (Input.GetMouseButtonUp(0))
        {
          
            playerattribute.Instance.Target = playerattribute.Instance.transform;
        }
      

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Find("level").transform.Find("Text").GetComponent<Text>().text = playerattribute.Instance.level + "";
        this.transform.Find("MP").GetComponent<Image>().fillAmount = playerattribute.Instance.Now_Mp / playerattribute.Instance.Max_Mp;
        this.transform.Find("MP").transform.Find("Text").GetComponent<Text>().text = float.Parse(string.Format("{0:0.00}", playerattribute.Instance.Now_Mp / playerattribute.Instance.Max_Mp)) * 100 + "%";
        this.transform.Find("HP").GetComponent<Image>().fillAmount = playerattribute.Instance.Now_Hp / playerattribute.Instance.Max_Hp;
        this.transform.Find("HP").transform.Find("Text").GetComponent<Text>().text = float.Parse(string.Format("{0:0.00}", playerattribute.Instance.Now_Hp / playerattribute.Instance.Max_Hp)) * 100 + "%";




        if (ismove&&canmove)
        {
            Vector2 offset = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - movepos;
            this.transform.position = nowpos + offset;
            if (Input.GetMouseButtonUp(0))
            {
                ismove = false;
            }
        }


    }
    public void chgange()
    {
        canmove = !canmove;
        this.transform.Find("Button").localScale = Vector3.zero;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        this.transform.Find("Button").localScale = Vector3.zero;
        
    }
}
