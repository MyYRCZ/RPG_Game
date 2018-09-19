using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class quest : SingletonMono<quest> {
    public int id;
    public string Name;
    public string info;
    public int exp;
    public int gold;
    public int num;
    public string needinfo;
    List<quest> questlist = new List<quest>();
    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
    }
    void Start () {
        if (Resources.Load("quest"))
        {
            
            //  StreamReader sr = new StreamReader("Assets/Resources/skill.xml", Encoding.UTF8);//数据流
            XmlDocument doc = new XmlDocument();
            doc.Load("Assets/Resources/quest.xml");
            XmlNode root = doc.SelectSingleNode("root");//获取XML文档中的根节点
            XmlNodeList listItem = root.ChildNodes;//获取根节点下面的所有子节点

            for (int i = 0; i < listItem.Count; i++)
            {
                XmlElement elem = listItem[i] as XmlElement;
                quest tempquest = new quest();
                tempquest.id = int.Parse(elem.GetAttribute("ID"));
                tempquest.Name = elem.GetAttribute("Name");
                tempquest.info = elem.GetAttribute("info");
                tempquest.exp = int.Parse(elem.GetAttribute("exp"));
                tempquest.gold = int.Parse(elem.GetAttribute("gold"));
                tempquest.num = int.Parse(elem.GetAttribute("num"));
                tempquest.needinfo = elem.GetAttribute("needinfo");


                questlist.Add(tempquest);

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
      //  print(questlist[1]);
	}
    public quest Getqquest(int id)
    {
        for (int i = 0; i < questlist.Count; i++)
        {
            if (questlist[i].id == id)
            {
                return questlist[i];
            }

        }
        //print("error");
        return questlist[0];


    }
}
