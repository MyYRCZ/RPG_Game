using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
public class goods : SingletonMono<goods>
{

    protected override void Awake()
    {
        base.Awake();
    }
  public   struct good
    {
        public int id;
        public string type;
        public int equiptype;
        public string Name;
        public string color;
        public int strength;//力量
        public int agility;    //敏捷
        public int intelligence;//智力
        public int stamina;//耐力
        public int Hp;    //生命上限
        public int Mp;    //魔法值上限
        public float crits;   ///暴击几率
        public float refreshHp;   //血量恢复速度
        public int attack; ///攻强
        public int magic; ///法强
        public int rapidly; ///急速
        public int def; ///护甲
        public string path;
        public string intro;
        public int weapontype;
    }
    List<good> goodlist = new List<good>();
    // Use this for initialization
    void Start()
    {


        if (Resources.Load("goods"))
        {
            //  StreamReader sr = new StreamReader("Assets/Resources/skill.xml", Encoding.UTF8);//数据流
            XmlDocument doc = new XmlDocument();
            doc.Load("Assets/Resources/goods.xml");
            XmlNode root = doc.SelectSingleNode("root");//获取XML文档中的根节点
            XmlNodeList listItem = root.ChildNodes;//获取根节点下面的所有子节点
      
            for (int i = 0; i < listItem.Count; i++)
            {
                XmlElement elem = listItem[i] as XmlElement;
                good tempgood=new good();
                tempgood.id = int.Parse(elem.GetAttribute("ID"));
                tempgood.type = elem.GetAttribute("type");
                tempgood.Name = elem.GetAttribute("Name");
                tempgood.color = elem.GetAttribute("color");
                if (tempgood.type=="equip")
                {
                    tempgood.strength = int.Parse(elem.GetAttribute("strength"));
                    tempgood.agility = int.Parse(elem.GetAttribute("agility"));
                    tempgood.intelligence = int.Parse(elem.GetAttribute("intelligence"));
                    tempgood.stamina = int.Parse(elem.GetAttribute("stamina"));
                    tempgood.Hp = int.Parse(elem.GetAttribute("hp"));
                    tempgood.Mp = int.Parse(elem.GetAttribute("mp"));
                    tempgood.refreshHp = float.Parse(elem.GetAttribute("refreshHp"));
                    tempgood.attack = int.Parse(elem.GetAttribute("attack"));
                    tempgood.magic = int.Parse(elem.GetAttribute("magic"));
                    tempgood.rapidly = int.Parse(elem.GetAttribute("rapidly"));
                    tempgood.def = int.Parse(elem.GetAttribute("def"));
                    tempgood.path = (elem.GetAttribute("path"));
                    tempgood.intro = (elem.GetAttribute("intro"));
                    tempgood.equiptype = int.Parse(elem.GetAttribute("equiptype"));
                    tempgood.weapontype = int.Parse(elem.GetAttribute("weapontype"));
                }
                if (tempgood.type == "used")
                {
                    tempgood.Hp = int.Parse(elem.GetAttribute("hp"));
                    tempgood.Mp = int.Parse(elem.GetAttribute("mp"));
                    tempgood.path = (elem.GetAttribute("path"));
                }

                goodlist.Add(tempgood);

            }
        }  
    }
    void Update()
    {

    }
    public good Getgood(int id)
    {
        for(int i=0;i<goodlist.Count;i++)
        {
            if (goodlist[i].id == id)
            {
                return goodlist[i];
            }
           
        }
        //print("error");
        return goodlist[1];
      

    }
  
}

// Update is called once per frame

