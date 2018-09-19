using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class bagwindow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool open = false;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.B))
        {
            window();
        }
        if(open)
        {
            this.transform.Find("window(bag)").Find("gold").Find("Text").GetComponent<Text>().text = playerattribute.Instance.gold + "";
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
