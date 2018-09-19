using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class buffs : SingletonMono<buffs> {
    List<buffs> bufflist = new List<buffs>();
    public int id;
    public string Name;
    public string info;
    public float time;
    public string path;
    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
    }
    void Start () {
        if (Resources.Load("buff"))
        {

            //  StreamReader sr = new StreamReader("Assets/Resources/skill.xml", Encoding.UTF8);//数据流
            XmlDocument doc = new XmlDocument();
            doc.Load("Assets/Resources/buff.xml");
            XmlNode root = doc.SelectSingleNode("root");//获取XML文档中的根节点
            XmlNodeList listItem = root.ChildNodes;//获取根节点下面的所有子节点

            for (int i = 0; i < listItem.Count; i++)
            {
                XmlElement elem = listItem[i] as XmlElement;
                buffs tempbuff = new buffs();
                tempbuff.id = int.Parse(elem.GetAttribute("ID"));
                tempbuff.Name = elem.GetAttribute("Name");
                tempbuff.info = elem.GetAttribute("info");
                tempbuff.time = float.Parse(elem.GetAttribute("time"));
                tempbuff.path = elem.GetAttribute("path");


                bufflist.Add(tempbuff);

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public buffs Getbuff(int id)
    {
        for (int i = 0; i < bufflist.Count; i++)
        {
            if (bufflist[i].id == id)
            {
                return bufflist[i];
            }

        }
        //print("error");
        return bufflist[0];


    }
  
}
