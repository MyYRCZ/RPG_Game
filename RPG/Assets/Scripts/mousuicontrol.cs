using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mousuicontrol : SingletonMono<mousuicontrol> {
    public bool ischange = false;
    public Transform movefrom;
    public Transform movetarget;
    public int id;
    protected override void Awake()
    {
        base.Awake();
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       // print(movetarget);
	if(ischange)
        {
            FreeLookCam.Instance.ismouseinui = true;
            transform.position = Input.mousePosition;
            if(Input.GetMouseButtonUp(0))
            {
                FreeLookCam.Instance.ismouseinui = false;
                ischange = false;
                this.transform.localScale = Vector3.zero;
                //判断交换
                if (movetarget == null)
                {
                      if ( movefrom.parent.name == "group")  //从技能条删除技能
                    {
                        movefrom.GetComponent<actionbarbuttom>().id = 0;
                        movefrom.Find("num").GetComponent<Text>().text = "";
                        movefrom.transform.Find("icon").GetComponent<Image>().color = Color.white;
                        
                    }
                }
                else if (movetarget.parent.name== "slotgroup"&& movefrom.parent.name=="slotgroup")  //背包内物品移动
                {
                    int temp = movetarget.GetComponent<bagslot>().goodid;
                    movetarget.GetComponent<bagslot>().goodid= movefrom.GetComponent<bagslot>().goodid;
                    movefrom.GetComponent<bagslot>().goodid = temp;
                    temp = movetarget.GetComponent<bagslot>().num;
                    movetarget.GetComponent<bagslot>().num = movefrom.GetComponent<bagslot>().num;
                    movefrom.GetComponent<bagslot>().num = temp;
                }
                else if (movetarget.parent.name == "slotgroup" && movefrom.parent.name == "left")//从装备栏取下装备
                {

                    if (movefrom.transform.name == "wepon")
                    {
                        movetarget.GetComponent<bagslot>().num = 1;
                        movetarget.GetComponent<bagslot>().goodid = movefrom.GetComponent<equiponui>().id;
                        Equipattribute.Instance.weaponid = 0 ;
                        Equipattribute.Instance.getequipattribute();
                        playerattribute.Instance.getattribute();

                    }
                    else if (movefrom.transform.name == "pants")
                    {
                        movetarget.GetComponent<bagslot>().num = 1;
                        movetarget.GetComponent<bagslot>().goodid = movefrom.GetComponent<equiponui>().id;
                       Equipattribute.Instance.pantsid=0;
                        Equipattribute.Instance.getequipattribute();
                        playerattribute.Instance.getattribute();
                    }
                    else if (movefrom.transform.name == "boots")
                    {
                        movetarget.GetComponent<bagslot>().num = 1;
                        movetarget.GetComponent<bagslot>().goodid = movefrom.GetComponent<equiponui>().id;
                        Equipattribute.Instance.bootsid=0;
                        Equipattribute.Instance.getequipattribute();
                        playerattribute.Instance.getattribute();
                    }
                    else if (movefrom.transform.name == "head")
                    {
                        movetarget.GetComponent<bagslot>().num = 1;
                        movetarget.GetComponent<bagslot>().goodid = movefrom.GetComponent<equiponui>().id;
                       Equipattribute.Instance.headid = 0;
                        Equipattribute.Instance.getequipattribute();
                        playerattribute.Instance.getattribute();
                    }
                    else if (movefrom.transform.name == "back")
                    {
                        movetarget.GetComponent<bagslot>().num = 1;
                        movetarget.GetComponent<bagslot>().goodid = movefrom.GetComponent<equiponui>().id;
                        Equipattribute.Instance.backid=0;
                        Equipattribute.Instance.getequipattribute();
                        playerattribute.Instance.getattribute();
                    }
                 
                }
                else if (movetarget.parent.name == "left" && movefrom.parent.name == "slotgroup")   //将装备穿到装备栏
                {

                    if(movetarget.name=="wepon" & goods.Instance.Getgood(movefrom.GetComponent<bagslot>().goodid).equiptype==1)
                    {
                        if(Equipattribute.Instance.weaponid==0)
                        {
                            Equipattribute.Instance.weaponid = movefrom.GetComponent<bagslot>().goodid;
                            movefrom.GetComponent<bagslot>().goodid = 0;
                            movefrom.GetComponent<bagslot>().num = 0;
                            Equipattribute.Instance.getequipattribute();
                            playerattribute.Instance.getattribute();
                        }
                        else
                        {
                            int atemp = movefrom.GetComponent<bagslot>().goodid;
                            movefrom.GetComponent<bagslot>().goodid= Equipattribute.Instance.weaponid;
                            Equipattribute.Instance.weaponid = atemp;
                            Equipattribute.Instance.getequipattribute();
                            playerattribute.Instance.getattribute();
                        }
                    }
                    if (movetarget.name == "pants" & goods.Instance.Getgood(movefrom.GetComponent<bagslot>().goodid).equiptype == 2)
                    {
                        if (Equipattribute.Instance.pantsid == 0)
                        {
                            Equipattribute.Instance.pantsid = movefrom.GetComponent<bagslot>().goodid;
                            movefrom.GetComponent<bagslot>().goodid = 0;
                            movefrom.GetComponent<bagslot>().num = 0;
                            Equipattribute.Instance.getequipattribute();
                            playerattribute.Instance.getattribute();
                        }
                        else
                        {
                            int atemp = movefrom.GetComponent<bagslot>().goodid;
                            movefrom.GetComponent<bagslot>().goodid = Equipattribute.Instance.pantsid;
                            Equipattribute.Instance.pantsid = atemp;
                            Equipattribute.Instance.getequipattribute();
                            playerattribute.Instance.getattribute();
                        }
                    }
                    if (movetarget.name == "boots" & goods.Instance.Getgood(movefrom.GetComponent<bagslot>().goodid).equiptype == 3)
                    {
                        if (Equipattribute.Instance.bootsid == 0)
                        {
                            Equipattribute.Instance.bootsid = movefrom.GetComponent<bagslot>().goodid;
                            movefrom.GetComponent<bagslot>().goodid = 0;
                            movefrom.GetComponent<bagslot>().num = 0;
                            Equipattribute.Instance.getequipattribute();
                            playerattribute.Instance.getattribute();
                        }
                        else
                        {
                            int atemp = movefrom.GetComponent<bagslot>().goodid;
                            movefrom.GetComponent<bagslot>().goodid = Equipattribute.Instance.bootsid;
                            Equipattribute.Instance.bootsid = atemp;
                            Equipattribute.Instance.getequipattribute();
                            playerattribute.Instance.getattribute();
                        }
                    }
                    if (movetarget.name == "head" & goods.Instance.Getgood(movefrom.GetComponent<bagslot>().goodid).equiptype == 4)
                    {
                        if (Equipattribute.Instance.headid == 0)
                        {
                            Equipattribute.Instance.headid = movefrom.GetComponent<bagslot>().goodid;
                            movefrom.GetComponent<bagslot>().goodid = 0;
                            movefrom.GetComponent<bagslot>().num = 0;
                            Equipattribute.Instance.getequipattribute();
                            playerattribute.Instance.getattribute();
                        }
                        else
                        {
                            int atemp = movefrom.GetComponent<bagslot>().goodid;
                            movefrom.GetComponent<bagslot>().goodid = Equipattribute.Instance.headid;
                            Equipattribute.Instance.headid = atemp;
                            Equipattribute.Instance.getequipattribute();
                            playerattribute.Instance.getattribute();
                        }
                    }
                    if (movetarget.name == "back" & goods.Instance.Getgood(movefrom.GetComponent<bagslot>().goodid).equiptype == 5)
                    {
                        if (Equipattribute.Instance.backid == 0)
                        {
                            Equipattribute.Instance.backid = movefrom.GetComponent<bagslot>().goodid;
                            movefrom.GetComponent<bagslot>().goodid = 0;
                            movefrom.GetComponent<bagslot>().num = 0;
                            Equipattribute.Instance.getequipattribute();
                            playerattribute.Instance.getattribute();
                        }
                        else
                        {
                            int atemp = movefrom.GetComponent<bagslot>().goodid;
                            movefrom.GetComponent<bagslot>().goodid = Equipattribute.Instance.backid;
                            Equipattribute.Instance.backid = atemp;
                            Equipattribute.Instance.getequipattribute();
                            playerattribute.Instance.getattribute();
                        }
                    }

                }
                else if (movetarget.parent.name == "group" && movefrom.parent.name == "slotgroup")  //将物品放入技能栏使用
                {
                    if(goods.Instance.Getgood(movefrom.GetComponent<bagslot>().goodid).type=="used")
                    {
                        movetarget.GetComponent<actionbarbuttom>().id = movefrom.GetComponent<bagslot>().goodid;
                        int num = 0;
                      
                        for (int i = 0; i < 32; i++)
                        {
                            if (mybag.Instance.items[i].goodid == movetarget.GetComponent<actionbarbuttom>().id)
                            {
                                num += mybag.Instance.items[i].num;
                            }
                        }
                        movetarget.Find("num").GetComponent<Text>().text = num + "";
                        movetarget.Find("num").transform.localScale = Vector3.one;
                    }
                    
                }
                else if (movetarget.parent.name == "group" && movefrom.parent.name == "group")  //从技能条拖动到技能条
                {
                    int temp1 = movefrom.GetComponent<actionbarbuttom>().id;
                    movefrom.GetComponent<actionbarbuttom>().id = movetarget.GetComponent<actionbarbuttom>().id;
                    movetarget.GetComponent<actionbarbuttom>().id = temp1;
                    string temp2 = movefrom.transform.Find("num").GetComponent<Text>().text;
                    movefrom.transform.Find("num").GetComponent<Text>().text= movetarget.transform.Find("num").GetComponent<Text>().text;
                    movetarget.transform.Find("num").GetComponent<Text>().text = temp2;
                    movefrom.transform.Find("icon").GetComponent<Image>().color = Color.white;

                }
                else if (movetarget.parent.name == "group" && movefrom.parent.parent.name == "skillgroup")  //从技能拖动到技能条
                {
                    movetarget.GetComponent<actionbarbuttom>().id = movefrom.GetComponent<skillinwindow>().id;
                    movetarget.transform.Find("num").GetComponent<Text>().text = "";
                }

            }
        }
    
	}
}
