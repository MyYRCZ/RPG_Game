using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class skills : SingletonMono<skills>
{
    public int id;
    public float cooldowntime;
    public float skillfaraway;
    public string skillmode;
    public string castmode;
    public int casttime;
    public int usedmp;
    public bool iscd;
    public bool ispubliccd;
    public float nowtime;
    public float publiccooldown = 1.5f;
    public string skillname;
    public string path;
    public string skillfrom;
    public float percent;
    // Use this for initialization
    List<skills> skilllist = new List<skills>();
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {

        if (Resources.Load("skill"))
        {
            //  StreamReader sr = new StreamReader("Assets/Resources/skill.xml", Encoding.UTF8);//数据流
            XmlDocument doc = new XmlDocument();
            doc.Load("Assets/Resources/skill.xml");
            XmlNode root = doc.SelectSingleNode("root");//获取XML文档中的根节点
            XmlNodeList listItem = root.ChildNodes;//获取根节点下面的所有子节点
            for (int i = 0; i < listItem.Count; i++)
            {
                skills tempskill = new skills();
                XmlElement elem = listItem[i] as XmlElement;

                tempskill.id = int.Parse(elem.GetAttribute("ID"));
                tempskill.cooldowntime = float.Parse(elem.GetAttribute("cooldowntime"));
                tempskill.skillfaraway = float.Parse(elem.GetAttribute("skillfaraway"));
                tempskill.skillmode = elem.GetAttribute("SkillMode");
                tempskill.castmode = elem.GetAttribute("CastMode");
                tempskill.usedmp = int.Parse(elem.GetAttribute("usedmp"));
                tempskill.casttime = int.Parse(elem.GetAttribute("casttime"));
                tempskill.skillname = elem.GetAttribute("Name");
                tempskill.skillfrom = elem.GetAttribute("skillfrom");
                tempskill.percent = float.Parse(elem.GetAttribute("percent"));
                tempskill.path = elem.GetAttribute("path");
                skilllist.Add(tempskill);



            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public skills Getskill(int id)
    {
        for (int i = 0; i < skilllist.Count; i++)
        {
            if (skilllist[i].id == id)
            {
                return skilllist[i];
            }

        }
        //print("error");
        return skilllist[0];


    }
}
