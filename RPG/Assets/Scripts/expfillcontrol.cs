using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class expfillcontrol : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        this.transform.Find("exp").localScale = new Vector3(1, 1, 1);
        this.transform.Find("exp").position = new Vector2(Input.mousePosition.x, this.transform.Find("exp").position.y);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        this.transform.Find("exp").localScale = new Vector3(0, 1, 1);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Find("expbarfill").GetComponent<Image>().fillAmount = playerattribute.Instance.exp / playerattribute.Instance.neddexp;
        this.transform.Find("exp").transform.Find("Text").GetComponent<Text>().text ="当前经验值为" +playerattribute.Instance.exp + "/"+ playerattribute.Instance.neddexp+"("+ playerattribute.Instance.exp / playerattribute.Instance.neddexp * 1.0f * 100+"%)"+",还需要" + (playerattribute.Instance.neddexp - playerattribute.Instance.exp)+"点经验升级";
        if(playerattribute.Instance.exp>= playerattribute.Instance.neddexp)
        {
            playerattribute.Instance.exp -= 100;
            playerattribute.Instance.level += 1;
            playerattribute.Instance.getattribute();
            levelupshow.Instance.showlevelup();
            playerattribute.Instance.Now_Hp = playerattribute.Instance.Max_Hp;
            playerattribute.Instance.Now_Mp = playerattribute.Instance.Max_Mp;

        }
    }
}

