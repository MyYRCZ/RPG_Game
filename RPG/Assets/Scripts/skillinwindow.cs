using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class skillinwindow : MonoBehaviour ,  IPointerDownHandler
{
    public int id = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(this.transform.parent.parent.parent.parent.GetComponent<windowskill>().open)
        {
            if (id != 0)
            {
                this.transform.Find("Image").transform.localScale = Vector3.one;
                this.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load(skills.Instance.Getskill(id).path, typeof(Sprite)) as Sprite;
                this.transform.Find("Text").GetComponent<Text>().text = skills.Instance.Getskill(id).skillname;
            }
            else
            {
                this.transform.Find("Image").transform.localScale = Vector3.zero;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            this.transform.parent.parent.parent.GetComponent<ScrollRect>().vertical = true;
        }

	}
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (id != 0)
        {
          
            if (Input.GetMouseButtonDown(0))
            {
                this.transform.parent.parent.parent.GetComponent<ScrollRect>().vertical = false;
                mousuicontrol.Instance.transform.GetComponent<Image>().sprite = this.transform.Find("Image").GetComponent<Image>().sprite;
                mousuicontrol.Instance.ischange = true;
                mousuicontrol.Instance.transform.localScale = Vector3.one;
                FreeLookCam.Instance.ismouseinui = true;
                mousuicontrol.Instance.movefrom = this.transform;
            }
        }
    }
}
