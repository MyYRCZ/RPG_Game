using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System.Xml;

using UnityEngine.EventSystems;
using System;

public class actionbarbuttom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    public bool skillormed;    // true skill fasle med kit
    public int id;
    public float cooldowntime;
    private float skillfaraway;
    private string skillmode;
    private string castmode;
    private int usedmp;
    private bool iscd;
    public bool ispubliccd;
    public float nowtime;
    public float publiccooldown = 1.5f;
    string skillname;
    string path;
    string skillfrom;
    float percent;
    int casttime;
    // Use this for initialization
    void Start()
    {
        if (id != 0)
        {
            cooldowntime = skills.Instance.Getskill(id).cooldowntime;
            skillfaraway = skills.Instance.Getskill(id).skillfaraway;
            skillmode = skills.Instance.Getskill(id).skillmode;
            castmode = skills.Instance.Getskill(id).castmode;
            usedmp = skills.Instance.Getskill(id).usedmp;
            skillname = skills.Instance.Getskill(id).skillname;
            path = skills.Instance.Getskill(id).path;
            skillfrom = skills.Instance.Getskill(id).skillfrom;
            percent = skills.Instance.Getskill(id).percent;
            casttime = skills.Instance.Getskill(id).casttime;

        }

        if (id != 0 && id < 2000)
        {
            this.transform.Find("icon").transform.localScale = new Vector3(1, 1, 1);
            this.transform.Find("icon").transform.GetComponent<Image>().sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
            skillormed = true;

        }
        else if (id > 3000)
        {
            this.transform.Find("icon").transform.localScale = new Vector3(1, 1, 1);
            this.transform.Find("icon").transform.GetComponent<Image>().sprite = Resources.Load(goods.Instance.Getgood(id).path, typeof(Sprite)) as Sprite;
            skillormed = false;
        }
        else
        {
            this.transform.Find("icon").transform.localScale = new Vector3(0, 1, 1);
        }
        // print(skillmode + "" + castmode + "" + usedmp + "" + skillname+" "+ path );



    }

    // Update is called once per frame
    void Update()
    {
        this.Start();

        if (Input.GetButton("skill" + this.transform.Find("key").GetComponent<Text>().text))
        {
            this.transform.Find("press").transform.localScale = new Vector3(1, 1, 1);
            print(1);
        }
        if (Input.GetButtonUp("skill" + this.transform.Find("key").GetComponent<Text>().text))
        {
            this.transform.Find("press").transform.localScale = new Vector3(0, 1, 1);
            print(2);
            use();
        }


        if (playerattribute.Instance.Target != null && playerattribute.Instance.Target != playerattribute.Instance.transform && skillormed&& playerattribute.Instance.Target.tag!="NPC")
        {
            //Debug.DrawLine(playerattribute.Instance.transform.position, playerattribute.Instance.Target.transform.FindChild("monster").transform.position);
            //print(Vector3.Angle(playerattribute.Instance.transform.forward, playerattribute.Instance.Target.transform.FindChild("monster").transform.position - playerattribute.Instance.transform.position));
            //print(Vector3.Distance(playerattribute.Instance.transform.position, playerattribute.Instance.Target.transform.FindChild("monster").transform.position));
            if (Vector3.Distance(playerattribute.Instance.transform.position, playerattribute.Instance.Target.transform.Find("monster").transform.position) >= skillfaraway && skillfaraway != 0)
            {
                this.transform.Find("icon").GetComponent<Image>().color = new Color(1, 0.1f, 0.1f, 1);
            }
            else
            {
                this.transform.Find("icon").GetComponent<Image>().color = new Color(1, 1, 1, 1);

            }
        }
        else
        {
            this.transform.Find("icon").GetComponent<Image>().color = new Color(1, 1, 1, 1);

        }
        if (skillormed)
        {
            cd();
            allcd();
        }
        if (!skillormed)
        {
            this.transform.Find("icon").GetComponent<Image>().color = new Color(1, 1, 1, 1);



        }

    }


    public void use()
    {
        if (!playerattribute.Instance.isdead)
        {
            if (skillormed)   //首先判断为技能还是物品
            {
                if (!playercastbarcontrol.Instance.iscast)
                {
                    //if (playerattribute.Instance.Target != null)//判断玩家是否拥有目标
                    //{
                    if (!iscd && !ispubliccd)
                    {
                        if (skillmode == "damage")   //判断技能模式
                        {
                            if (playerattribute.Instance.Target != null)//判断玩家是否拥有目标
                            {

                                if (playerattribute.Instance.Target.tag == "Monster")
                                {
                                    if (!playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().isdead)
                                    {
                                        if (Vector3.Distance(playerattribute.Instance.transform.position, playerattribute.Instance.Target.transform.Find("monster").transform.position) <= skillfaraway)//判断是否在技能的攻击范围内
                                        {


                                            if (Vector3.Angle(playerattribute.Instance.transform.forward, playerattribute.Instance.Target.transform.Find("monster").transform.position - playerattribute.Instance.transform.position) <= 70)  //判断是否面朝敌人 
                                            {
                                                if (castmode == "dutiao")
                                                {
                                                    if (playerattribute.Instance.Now_Mp >= usedmp)//判断是否拥有足够的魔法值
                                                    {
                                                        int damage;
                                                        if (skillfrom == "magic")
                                                        {
                                                            damage = (int)(playerattribute.Instance.magic * percent * UnityEngine.Random.Range(0.9f, 1.1f));
                                                        }
                                                        else
                                                        {
                                                            damage = (int)(playerattribute.Instance.attack * percent * UnityEngine.Random.Range(0.9f, 1.1f));
                                                        }

                                                        playercastbarcontrol.Instance.cast(id, this.transform.Find("icon").GetComponent<Image>().sprite, skillname, casttime, usedmp, playerattribute.Instance.Target, damage);
                                                        this.transform.Find("icon").transform.Find("cd").transform.GetComponent<Image>().fillAmount = 1f;

                                                        if (cooldowntime <= publiccooldown)
                                                        {
                                                            ispubliccd = true;
                                                        }
                                                        else
                                                        {
                                                            iscd = true;
                                                        }


                                                        for (int i = 1; i <= 9; i++)
                                                        {
                                                            // print(this.transform.parent.FindChild("slot" + i));
                                                            if (this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().iscd == false)
                                                            {
                                                                this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().ispubliccd = true;
                                                            }
                                                            else
                                                            {
                                                                if (this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().cooldowntime - this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().nowtime <= this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().publiccooldown / (1 + playerattribute.Instance.rapidly / 3000f))
                                                                {
                                                                    this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().iscd = false;
                                                                    this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().nowtime = 0;
                                                                    this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().ispubliccd = true;

                                                                }
                                                            }

                                                        }
                                                    }
                                                    else
                                                    {
                                                        uitextcontrol.Instance.addtext("魔法值不足");
                                                       
                                                    }
                                                }
                                                else if (castmode == "shunfa")
                                                {
                                                    if (playerattribute.Instance.Now_Mp >= usedmp)//判断是否拥有足够的魔法值
                                                    {
                                                        int damage;
                                                        if (skillfrom == "attack")
                                                        {
                                                            damage = (int)(playerattribute.Instance.attack * percent * UnityEngine.Random.Range(0.9f, 1.1f));
                                                        }
                                                        else
                                                        {
                                                            damage = (int)(playerattribute.Instance.attack * percent * UnityEngine.Random.Range(0.9f, 1.1f));
                                                        }

                                                        // playercastbarcontrol.Instance.cast(id, this.transform.FindChild("icon").GetComponent<Image>().sprite, skillname, casttime, usedmp, playerattribute.Instance.Target, damage);
                                                        playerattribute.Instance.GetComponentInChildren<Animator>().SetBool("Attack", true);  //改变动作
                                                        int c = UnityEngine.Random.Range(0, 100);
                                                        if (c <= playerattribute.Instance.crits * 100)
                                                        {
                                                            playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().Now_Hp -= (int)(2 * playerattribute.Instance.Damagecoefficient * damage * (1 - playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().Damagereductioncoefficient)) + 1;
                                                            showdamgecontrol.Instance.adddamge(Resources.Load(skills.Instance.Getskill(id).path, typeof(Sprite)) as Sprite, -(int)(2 * playerattribute.Instance.Damagecoefficient * damage * (1 - playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().Damagereductioncoefficient)) + 1);
                                                        }
                                                        else
                                                        {
                                                            playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().Now_Hp -= (int)(damage * playerattribute.Instance.Damagecoefficient * (1 - playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().Damagereductioncoefficient) + 1);
                                                            showdamgecontrol.Instance.adddamge(Resources.Load(skills.Instance.Getskill(id).path, typeof(Sprite)) as Sprite, -(int)(damage * playerattribute.Instance.Damagecoefficient * (1 - playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().Damagereductioncoefficient) + 1));
                                                        }



                                                        this.transform.Find("icon").transform.Find("cd").transform.GetComponent<Image>().fillAmount = 1f;

                                                        if (cooldowntime <= publiccooldown)
                                                        {
                                                            ispubliccd = true;
                                                        }
                                                        else
                                                        {
                                                            iscd = true;
                                                        }


                                                        for (int i = 1; i <= 9; i++)
                                                        {
                                                            // print(this.transform.parent.FindChild("slot" + i));
                                                            if (this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().iscd == false)
                                                            {
                                                                this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().ispubliccd = true;
                                                            }
                                                            else
                                                            {
                                                                if (this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().cooldowntime - this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().nowtime <= this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().publiccooldown / (1 + playerattribute.Instance.rapidly / 3000f))
                                                                {
                                                                    this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().iscd = false;
                                                                    this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().nowtime = 0;
                                                                    this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().ispubliccd = true;

                                                                }
                                                            }

                                                        }

                                                    }
                                                    else
                                                    {
                                                        uitextcontrol.Instance.addtext("魔法值不足");
                                                    }


                                                }




                                            }
                                            else
                                            {
                                                uitextcontrol.Instance.addtext("我需要面对目标");
                                            }
                                        }
                                        else
                                        {
                                            uitextcontrol.Instance.addtext("太远了");
                                            //1ui层显示红字 
                                            //2播放声音
                                        }

                                    }
                                    else
                                    {
                                        uitextcontrol.Instance.addtext("这不是一个有效的目标");
                                        //1ui层显示红字 
                                        //2播放声音
                                    }

                                }
                                else
                                {
                                    uitextcontrol.Instance.addtext("这不是一个有效的目标");
                                    //1ui层显示红字 
                                    //2播放声音
                                }

                            }
                            else
                            {
                                uitextcontrol.Instance.addtext("我需要一个目标");
                                //ui层显示红字 
                                //2播放声音
                            }



                        }

                        else if (skillmode == "health")      //当技能模式为治疗时
                        {
                            if (playerattribute.Instance.Now_Mp >= usedmp)   //只需要判断是否拥有足够魔法值
                            {
                                int health;
                                if (skillfrom == "magic")
                                {
                                    health = (int)(playerattribute.Instance.magic * percent * UnityEngine.Random.Range(0.9f, 1.1f));
                                }
                                else
                                {
                                    health = (int)(playerattribute.Instance.attack * percent * UnityEngine.Random.Range(0.9f, 1.1f));
                                }

                                playercastbarcontrol.Instance.cast(id, this.transform.Find("icon").GetComponent<Image>().sprite, skillname, casttime, usedmp, playerattribute.Instance.transform, health);
                                this.transform.Find("icon").transform.Find("cd").transform.GetComponent<Image>().fillAmount = 1f;

                                if (cooldowntime <= publiccooldown)
                                {
                                    ispubliccd = true;
                                }
                                else
                                {
                                    iscd = true;
                                }


                                for (int i = 1; i <= 9; i++)
                                {
                                    // print(this.transform.parent.FindChild("slot" + i));
                                    if (this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().iscd == false)
                                    {
                                        this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().ispubliccd = true;
                                    }
                                    else
                                    {
                                        if (this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().cooldowntime - this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().nowtime <= this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().publiccooldown / (1 + playerattribute.Instance.rapidly / 3000f))
                                        {
                                            this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().iscd = false;
                                            this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().nowtime = 0;
                                            this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().ispubliccd = true;

                                        }
                                    }

                                }
                            }

                            else
                            {
                                uitextcontrol.Instance.addtext("魔法值不足");
                                //1ui层显示红字 
                                //2播放声音
                            }
                        }
                        else if (skillmode == "buff")      //当技能模式为治疗时
                        {

                            if (id == 1005)
                            {
                                playerattribute.Instance.buff3time = 0.01f;
                            }
                            this.transform.Find("icon").transform.Find("cd").transform.GetComponent<Image>().fillAmount = 1f;

                            if (cooldowntime <= publiccooldown)
                            {
                                ispubliccd = true;
                            }
                            else
                            {
                                iscd = true;
                            }


                            for (int i = 1; i <= 9; i++)
                            {
                                // print(this.transform.parent.FindChild("slot" + i));
                                if (this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().iscd == false)
                                {
                                    this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().ispubliccd = true;
                                }
                                else
                                {
                                    if (this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().cooldowntime - this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().nowtime <= this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().publiccooldown / (1 + playerattribute.Instance.rapidly / 3000f))
                                    {
                                        this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().iscd = false;
                                        this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().nowtime = 0;
                                        this.transform.parent.Find("slot" + i).transform.GetComponent<actionbarbuttom>().ispubliccd = true;

                                    }
                                }

                            }



                        }
                    }
                    else
                    {
                        uitextcontrol.Instance.addtext("冷却中");
                        //1ui层显示红字 
                        //2播放声音

                    }

                }
                //else
                //{
                //    print("我需要一个目标");
                //    //1ui层显示红字 
                //    //2播放声音

                //}
                //   }
            }
            else  //使用物品
            {
                if (id != 0)
                {
                    //print("used");
                    int num = 0;

                    for (int i = 0; i < 32; i++)
                    {
                        if (mybag.Instance.items[i].goodid == id)
                        {
                            mybag.Instance.items[i].use();
                            for (int j = 0; j < 32; j++)
                            {
                                if (mybag.Instance.items[j].goodid == id)
                                {
                                    num += mybag.Instance.items[j].num;
                                  //  print(num);
                                }
                            }

                            if (num > 0)
                            {

                                actionbarbuttom[] item = this.transform.parent.GetComponentsInChildren<actionbarbuttom>();
                                for (int a = 0; a < 9; a++)
                                {
                                    if (item[a].id == id && item[a].transform.Find("key").GetComponent<Text>().text != this.transform.Find("key").GetComponent<Text>().text)
                                    {
                                        item[a].transform.Find("num").GetComponent<Text>().text = num + "";
                                    }
                                }
                                this.transform.Find("num").GetComponent<Text>().text = num + "";
                            }
                            else
                            {
                                actionbarbuttom[] item = this.transform.parent.GetComponentsInChildren<actionbarbuttom>();
                                for (int a = 0; a < 9; a++)
                                {
                                    if (item[a].id == id && item[a].transform.Find("key").GetComponent<Text>().text != this.transform.Find("key").GetComponent<Text>().text)
                                    {
                                        item[a].id = 0;
                                        item[a].transform.Find("num").GetComponent<Text>().text = "";
                                    }
                                }
                                id = 0;
                                this.transform.Find("num").GetComponent<Text>().text = "";

                            }
                            return;
                        }
                    }

                }
            }
        }
    }

    public void cd()
    {

        if (iscd)
        {
            nowtime += Time.deltaTime;
            this.transform.Find("icon").transform.Find("cd").transform.GetComponent<Image>().fillAmount = 1 - nowtime / cooldowntime;

            this.transform.Find("icon").transform.Find("cd").transform.Find("cdtime").transform.GetComponent<Text>().text = (int)(cooldowntime - nowtime) + 1 + "";



            if (cooldowntime - nowtime <= 0)
            {

                this.transform.Find("icon").transform.Find("cd").transform.Find("cdtime").transform.GetComponent<Text>().text = "";

                iscd = false;
                nowtime = 0;
            }


        }



    }
    public void allcd()
    {

        if (ispubliccd)
        {
            nowtime += Time.deltaTime;
            this.transform.Find("icon").transform.Find("cd").transform.GetComponent<Image>().fillAmount = 1 - nowtime / publiccooldown;

            this.transform.Find("icon").transform.Find("cd").transform.Find("cdtime").transform.GetComponent<Text>().text = (int)(publiccooldown - nowtime) + 1 + "";



            if (publiccooldown - nowtime <= 0)
            {

                this.transform.Find("icon").transform.Find("cd").transform.Find("cdtime").transform.GetComponent<Text>().text = "";

                ispubliccd = false;
                nowtime = 0;
            }


        }



    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (mousuicontrol.Instance.ischange == true)
        {
            mousuicontrol.Instance.movetarget = this.transform;
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (mousuicontrol.Instance.ischange == true)
        {
            mousuicontrol.Instance.movetarget = null;
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        //  throw new NotImplementedException();
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (id != 0)
        {
            if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
            {
                this.transform.Find("icon").transform.GetComponent<Image>().color = Color.grey;
                mousuicontrol.Instance.transform.GetComponent<Image>().sprite = this.transform.Find("icon").GetComponent<Image>().sprite;
                mousuicontrol.Instance.ischange = true;
                mousuicontrol.Instance.transform.localScale = Vector3.one;
                FreeLookCam.Instance.ismouseinui = true;
                mousuicontrol.Instance.movefrom = this.transform;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                use();
            }
        }
    }
}
