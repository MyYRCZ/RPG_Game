using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;


public class characterwindowmove : MonoBehaviour,IPointerDownHandler
{
    private bool ismove = false;
    private Vector2 movepos;
    private Vector2 nowpos;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (ismove)
        {
            Vector2 offset = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - movepos;
            this.transform.parent.position = nowpos + offset;
            if(Input.GetMouseButtonUp(0))
            {
                ismove = false;
            }
        }
    }
  

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
     
        movepos = Input.mousePosition;
        nowpos = this.transform.parent.position;
        ismove = true;
    }
}
