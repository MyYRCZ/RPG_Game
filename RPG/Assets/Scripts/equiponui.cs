using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class equiponui : MonoBehaviour  ,IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{

    
     public int id;
     private string a;
    private float entertime;
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (id != 0)
        {


            if (Input.GetMouseButtonDown(1))
            {
              if(mybag.Instance.addgood(id))
                {
                    if (this.transform.name == "wepon")
                    {
                        Equipattribute.Instance.weaponid = 0;
                    }
                    else if (this.transform.name == "pants")
                    {
                        Equipattribute.Instance.pantsid = 0;
                    }
                    else if (this.transform.name == "boots")
                    {
                        Equipattribute.Instance.bootsid = 0;
                    }
                    else if (this.transform.name == "head")
                    {
                        Equipattribute.Instance.headid = 0;
                    }
                    else if (this.transform.name == "back")
                    {
                        Equipattribute.Instance.backid = 0;
                    }
                    Equipattribute.Instance.getequipattribute();
                    playerattribute.Instance.getattribute() ;
                }

                return;

            }
            if (Input.GetMouseButtonDown(0))
            {
                this.transform.Find("Image").GetComponent<Image>().color = Color.grey;
                mousuicontrol.Instance.transform.GetComponent<Image>().sprite = this.transform.Find("Image").GetComponent<Image>().sprite;
                mousuicontrol.Instance.ischange = true;
                mousuicontrol.Instance.transform.localScale = Vector3.one;
                FreeLookCam.Instance.ismouseinui = true;
                mousuicontrol.Instance.movefrom = this.transform;
            }
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (mousuicontrol.Instance.ischange == true)
        {
            mousuicontrol.Instance.movetarget = this.transform;
        }
        if (!mousuicontrol.Instance.ischange)
        {
            entertime += Time.deltaTime;
        }
          
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (mousuicontrol.Instance.ischange == true)
        {
            mousuicontrol.Instance.movetarget = null;
        }
        entertime = 0;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
       
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonUp(0))
        {
            this.transform.Find("Image").GetComponent<Image>().color = Color.white;
        }
        if(this.transform.name=="wepon")
        {
            id = Equipattribute.Instance.weaponid;
        }
        else if (this.transform.name == "pants")
        {
            id = Equipattribute.Instance.pantsid;
        }
      else   if (this.transform.name == "boots")
        {
            id = Equipattribute.Instance.bootsid;
        }
        else if (this.transform.name == "head")
        {
            id = Equipattribute.Instance.headid;
        }
       else   if (this.transform.name == "back")
        {
            id = Equipattribute.Instance.backid;
        }


        if (id!=0)
        {
            this.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load(goods.Instance.Getgood(id).path, typeof(Sprite)) as Sprite;
            this.transform.Find("Image").transform.localScale = Vector3.one;
        }
        else
        {
            this.transform.Find("Image").transform.localScale = Vector3.zero;
        }
        if (entertime > 0 && id != 0)
        {
            entertime += Time.deltaTime;
            if (entertime >= 0.8f)
            {
                this.transform.parent.Find("goodson").transform.localScale = new Vector3(1, 1, 1);
                this.transform.parent.Find("goodson").transform.position = Input.mousePosition;
                this.transform.parent.Find("goodson").transform.Find("name").GetComponent<Text>().text = goods.Instance.Getgood(id).Name;
                switch (goods.Instance.Getgood(id).color)
                {
                    case "white":
                        this.transform.parent.Find("goodson").transform.Find("name").GetComponent<Text>().color = Color.white;
                        break;
                    case "green":

                        this.transform.parent.Find("goodson").transform.Find("name").GetComponent<Text>().color = Color.green;
                        break;
                    case "blue":
                        this.transform.parent.Find("goodson").transform.Find("name").GetComponent<Text>().color = Color.blue;
                        break;
                    case "purple":
                        this.transform.parent.Find("goodson").transform.Find("name").GetComponent<Text>().color = Color.red + Color.blue;
                        break;
                    case "orange":
                        this.transform.parent.Find("goodson").transform.Find("name").GetComponent<Text>().color = Color.red + Color.yellow;
                        break;

                }
                if (goods.Instance.Getgood(id).type == "equip")
                {
                    a = "";
                    if (goods.Instance.Getgood(id).strength != 0)
                    {
                        a += "力量+" + goods.Instance.Getgood(id).strength + "\n";
                    }

                    if (goods.Instance.Getgood(id).agility != 0)
                    {
                        a += "敏捷+" + goods.Instance.Getgood(id).agility + "\n";
                    }

                    if (goods.Instance.Getgood(id).intelligence != 0)
                    {
                        a += "智力+" + goods.Instance.Getgood(id).intelligence + "\n";
                    }

                    if (goods.Instance.Getgood(id).stamina != 0)
                    {
                        a += "耐力+" + goods.Instance.Getgood(id).stamina + "\n";
                    }

                    if (goods.Instance.Getgood(id).Hp != 0)
                    {
                        a += "最大生命值+" + goods.Instance.Getgood(id).Hp + "\n";
                    }

                    if (goods.Instance.Getgood(id).Mp != 0)
                    {
                        a += "最大魔法值+" + goods.Instance.Getgood(id).Mp + "\n";
                    }

                    if (goods.Instance.Getgood(id).crits != 0)
                    {
                        a += "暴击+" + goods.Instance.Getgood(id).crits + "\n";
                    }
                    if (goods.Instance.Getgood(id).refreshHp != 0)
                    {
                        a += "生命恢复速度+" + goods.Instance.Getgood(id).refreshHp + "\n";
                    }
                    if (goods.Instance.Getgood(id).attack != 0)
                    {
                        a += "攻强+" + goods.Instance.Getgood(id).attack + "\n";
                    }
                    if (goods.Instance.Getgood(id).magic != 0)
                    {
                        a += "法强+" + goods.Instance.Getgood(id).magic + "\n";
                    }
                    if (goods.Instance.Getgood(id).rapidly != 0)
                    {
                        a += "急速+" + goods.Instance.Getgood(id).rapidly + "\n";
                    }
                    if (goods.Instance.Getgood(id).def != 0)
                    {
                        a += "护甲+" + goods.Instance.Getgood(id).def + "\n";
                    }

                }
                this.transform.parent.Find("goodson").transform.Find("info").GetComponent<Text>().text = a;
                this.transform.parent.Find("goodson").transform.Find("intro").GetComponent<Text>().text = goods.Instance.Getgood(id).intro;

                //goods.Instance.Getgood(goodid)
            }
            else
            {
                this.transform.parent.Find("goodson").transform.localScale = new Vector3(0, 1, 1);
            }
        }


    }
}
