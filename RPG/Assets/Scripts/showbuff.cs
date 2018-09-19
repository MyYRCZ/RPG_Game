using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class showbuff : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isonui;
    public float time;
    public int id;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(buffs.Instance.Getbuff(id).time!=0)
        {
            this.transform.Find("Text").GetComponent<Text>().text = float.Parse(string.Format("{0:0.0}", buffs.Instance.Getbuff(id).time - time)) + "";
        }
        else
        {
            this.transform.Find("Text").GetComponent<Text>().text = "";
        }


        if(isonui)
        {
            this.transform.Find("show").transform.localScale = Vector3.one;
            this.transform.Find("show").Find("Text").GetComponent<Text>().text = buffs.Instance.Getbuff(id).info;
            this.transform.Find("show").position = Input.mousePosition;
        }
        else
        {
            this.transform.Find("show").transform.localScale = Vector3.zero;
        }

    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        isonui = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        isonui = false;
    }
}
