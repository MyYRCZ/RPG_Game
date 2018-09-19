using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class bagslot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    public int goodid;
    public int num = 1;
    private float entertime;

    string a;
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if(mousuicontrol.Instance.ischange==true)
        {
            mousuicontrol.Instance.movetarget = this.transform;
        }
        this.transform.Find("press").localScale = new Vector3(1, 1, 1);
        if(!mousuicontrol.Instance.ischange)
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
        this.transform.Find("press").localScale = new Vector3(0, 1, 1);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (num > 1)
        {
            this.transform.Find("Text").GetComponent<Text>().text = num + "";
        }
        else
        {
            this.transform.Find("Text").GetComponent<Text>().text =  "";
        }
        if(Input.GetMouseButtonUp(0))
        {
           // FreeLookCam.Instance.ismouseinui = false;
            this.transform.Find("icon").GetComponent<Image>().color = Color.white;
        }
        if (goodid != 0)
        {
            this.transform.Find("icon").localScale = new Vector3(0.83f, 0.83f, 1);
            this.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(goods.Instance.Getgood(goodid).path, typeof(Sprite)) as Sprite;
           // print(goods.Instance.Getgood(goodid).path);
        }
        else
        {

            this.transform.Find("icon").localScale = new Vector3(0, 0, 1);
        }
        if(entertime>0&& goodid!=0)
        {
            entertime += Time.deltaTime;
            if(entertime>=0.8f)
            {
                this.transform.parent.parent.Find("goodson").transform.localScale = new Vector3(1, 1, 1);
                this.transform.parent.parent.Find("goodson").transform.position = Input.mousePosition+new Vector3(20,20,0);
                this.transform.parent.parent.Find("goodson").transform.Find("name").GetComponent<Text>().text = goods.Instance.Getgood(goodid).Name;
               switch(goods.Instance.Getgood(goodid).color)
                {
                    case "white":
                        this.transform.parent.parent.Find("goodson").transform.Find("name").GetComponent<Text>().color = Color.white;
                        break;
                    case "green":
                       
                        this.transform.parent.parent.Find("goodson").transform.Find("name").GetComponent<Text>().color = Color.green;
                        break;
                    case "blue":
                        this.transform.parent.parent.Find("goodson").transform.Find("name").GetComponent<Text>().color = Color.blue;
                        break;
                    case "purple":
                        this.transform.parent.parent.Find("goodson").transform.Find("name").GetComponent<Text>().color = Color.red + Color.blue;
                        break;
                    case "orange":
                        this.transform.parent.parent.Find("goodson").transform.Find("name").GetComponent<Text>().color = Color.red + Color.yellow;
                        break;

                }
                if (goods.Instance.Getgood(goodid).type == "equip")
                {
                    a = "";
                    if (goods.Instance.Getgood(goodid).strength != 0)
                    {
                        a += "力量+" + goods.Instance.Getgood(goodid).strength + "\n";
                    }

                    if (goods.Instance.Getgood(goodid).agility != 0)
                    {
                        a += "敏捷+" + goods.Instance.Getgood(goodid).agility + "\n";
                    }

                    if (goods.Instance.Getgood(goodid).intelligence != 0)
                    {
                        a += "智力+" + goods.Instance.Getgood(goodid).intelligence + "\n";
                    }

                    if (goods.Instance.Getgood(goodid).stamina != 0)
                    {
                        a += "耐力+" + goods.Instance.Getgood(goodid).stamina + "\n";
                    }

                    if (goods.Instance.Getgood(goodid).Hp != 0)
                    {
                        a += "最大生命值+" + goods.Instance.Getgood(goodid).Hp + "\n";
                    }

                    if (goods.Instance.Getgood(goodid).Mp != 0)
                    {
                        a += "最大魔法值+" + goods.Instance.Getgood(goodid).Mp + "\n";
                    }

                    if (goods.Instance.Getgood(goodid).crits != 0)
                    {
                        a += "暴击+" + goods.Instance.Getgood(goodid).crits + "\n";
                    }
                    if (goods.Instance.Getgood(goodid).refreshHp != 0)
                    {
                        a += "生命恢复速度+" + goods.Instance.Getgood(goodid).refreshHp + "\n";
                    }
                    if (goods.Instance.Getgood(goodid).attack != 0)
                    {
                        a += "攻强+" + goods.Instance.Getgood(goodid).attack + "\n";
                    }
                    if (goods.Instance.Getgood(goodid).magic != 0)
                    {
                        a += "法强+" + goods.Instance.Getgood(goodid).magic + "\n";
                    }
                    if (goods.Instance.Getgood(goodid).rapidly != 0)
                    {
                        a += "急速+" + goods.Instance.Getgood(goodid).rapidly + "\n";
                    }
                    if (goods.Instance.Getgood(goodid).def != 0)
                    {
                        a += "护甲+" + goods.Instance.Getgood(goodid).def + "\n";
                    }

                }
                else if(goodid==3003)
                {
                    a = "任务物品";
                }
                else
                {
                    a = "";
                    if (goods.Instance.Getgood(goodid).Hp != 0)
                    {
                        a += "恢复生命值+" + goods.Instance.Getgood(goodid).Hp + "\n";
                    }
                    if (goods.Instance.Getgood(goodid).Mp != 0)
                    {
                        a += "恢复魔法值+" + goods.Instance.Getgood(goodid).Mp + "\n";
                    }
                }
                this.transform.parent.parent.Find("goodson").transform.Find("info").GetComponent<Text>().text=a;
                this.transform.parent.parent.Find("goodson").transform.Find("intro").GetComponent<Text>().text= goods.Instance.Getgood(goodid).intro;

                //goods.Instance.Getgood(goodid)
            }
            else
            {
                this.transform.parent.parent.Find("goodson").transform.localScale = new Vector3(0, 1, 1);
            }
        }
	
	}
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (goodid != 0)
        {


            if (Input.GetMouseButtonDown(1))
            {
                use();
                return;

            }
            if (Input.GetMouseButtonDown(0))
            {
                this.transform.Find("icon").GetComponent<Image>().color = Color.grey;
                mousuicontrol.Instance.transform.GetComponent<Image>().sprite = this.transform.Find("icon").GetComponent<Image>().sprite;
                mousuicontrol.Instance.ischange = true;
                mousuicontrol.Instance.transform.localScale = Vector3.one;
                FreeLookCam.Instance.ismouseinui = true;
                mousuicontrol.Instance.movefrom = this.transform;
            }
        }
     
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {

        //throw new NotImplementedException();
    }
    public void use()                              //使用物品 首先遍历找到物品  2.判断物品类型  3如果是装备  判断当前是否穿有装备   没有直接穿上  有 图标交换  数据交换  4,更新数据 5若果物品 使用物品  判断该格子物品是否数量大于2
    {
        if (goods.Instance.Getgood(goodid).type=="equip")
        {
            if(goods.Instance.Getgood(goodid).equiptype==1)
            {
                if(Equipattribute.Instance.weaponid==0)
                {
                    Equipattribute.Instance.weaponid = goodid;
                       goodid = 0;
                    Equipattribute.Instance.getequipattribute();
                    playerattribute.Instance.getattribute();
                    return;
                }
                else
                {
                    int temp = goodid;
                    goodid = Equipattribute.Instance.weaponid;
                    Equipattribute.Instance.weaponid = temp;
                    Equipattribute.Instance.getequipattribute();
                    playerattribute.Instance.getattribute();
                    return;
                }

            }
            if (goods.Instance.Getgood(goodid).equiptype == 2)
            {
                if (Equipattribute.Instance.pantsid == 0)
                {
                    Equipattribute.Instance.pantsid = goodid;
                    goodid = 0;
                    Equipattribute.Instance.getequipattribute();
                    playerattribute.Instance.getattribute();
                    return;
                }
                else
                {
                    int temp = goodid;
                    goodid = Equipattribute.Instance.pantsid;
                    Equipattribute.Instance.pantsid = temp;
                    Equipattribute.Instance.getequipattribute();
                    playerattribute.Instance.getattribute();
                    return;
                }
            }
            if (goods.Instance.Getgood(goodid).equiptype == 3)
            {
                if (Equipattribute.Instance.bootsid == 0)
                {
                    Equipattribute.Instance.bootsid = goodid;
                    goodid = 0;
                    Equipattribute.Instance.getequipattribute();
                    playerattribute.Instance.getattribute();
                    return;
                }
                else
                {
                    int temp = goodid;
                    goodid = Equipattribute.Instance.bootsid;
                    Equipattribute.Instance.bootsid = temp;
                    Equipattribute.Instance.getequipattribute();
                    playerattribute.Instance.getattribute();
                    return;
                }
            }
            if (goods.Instance.Getgood(goodid).equiptype == 4)
            {
                if (Equipattribute.Instance.headid == 0)
                {
                    Equipattribute.Instance.headid = goodid;
                    goodid = 0;
                    Equipattribute.Instance.getequipattribute();
                    playerattribute.Instance.getattribute();
                    return;
                }
                else
                {
                    int temp = goodid;
                    goodid = Equipattribute.Instance.headid;
                    Equipattribute.Instance.headid = temp;
                    Equipattribute.Instance.getequipattribute();
                    playerattribute.Instance.getattribute();
                    return;
                }
            }
            if (goods.Instance.Getgood(goodid).equiptype == 5)
            {
                if (Equipattribute.Instance.backid == 0)
                {
                    Equipattribute.Instance.backid = goodid;
                    goodid = 0;
                    Equipattribute.Instance.getequipattribute();
                    playerattribute.Instance.getattribute();
                    return;
                }
                else
                {
                    int temp = goodid;
                    goodid = Equipattribute.Instance.backid;
                    Equipattribute.Instance.backid = temp;
                    Equipattribute.Instance.getequipattribute();
                    playerattribute.Instance.getattribute();
                    return;
                }
            }
           
        }
        else
        {
            switch(goodid)
            {
                case 3001:
                   if( playerattribute.Instance.Now_Hp + 50>playerattribute.Instance.Max_Hp)
                    {
                        playerattribute.Instance.Now_Hp = playerattribute.Instance.Max_Hp;
                    }
                   else
                    {
                        playerattribute.Instance.Now_Hp+=50;
                    }
                   if(num>1)
                    {
                        num -= 1;
                    }
                    else
                    {
                        num = 0;
                           goodid = 0;
                    }
                 
                    break;
                case 3002:
                    if (playerattribute.Instance.Now_Mp + 50 > playerattribute.Instance.Max_Mp)
                    {
                        playerattribute.Instance.Max_Mp = playerattribute.Instance.Max_Mp;
                    }
                    else
                    {
                        playerattribute.Instance.Max_Mp += 50;
                    }
                    if (num > 1)
                    {
                        num -= 1;
                    }
                    else
                    {
                        num = 0;
                        goodid = 0;
                    }
                    break;

            }
        }
    

    }

}
