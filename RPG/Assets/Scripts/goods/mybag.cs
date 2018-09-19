using UnityEngine;
using System.Collections;

public class mybag : SingletonMono<mybag>
{
    public bagslot[] items;
    bool havefind = false;
    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        items = this.transform.GetComponentsInChildren<bagslot>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool addgood(int id, int num = 1)
    {
        havefind = false;
        if (goods.Instance.Getgood(id).type == "equip")
        {
            for (int i = 0; i < 32; i++)
            {
                //string temp = " bagslot(" + i + ")";
                //print(temp);
                if (items[i].goodid == 0)
                {
                    items[i].goodid = id;
                    items[i].num = 1;
                    return true;
                }

            }
        }
        else
        {
            for (int i = 0; i < 32; i++)
            {
                string temp = "bagslot(" + i + ")";
                if (items[i].goodid == id)
                {
                    if (items[i].num < 20)
                    {
                        items[i].num += 1;
                        havefind = true;
                        return true;
                    }
                    else
                    {

                    }
                }

            }
            if (havefind == false)
            {
                for (int i = 0; i < 32; i++)
                {
                    string temp = "bagslot(" + i + ")";
                    if (items[i].goodid == 0)
                    {
                        items[i].goodid = id;
                        return true;
                    }

                }

            }

        }
        return false;
    }
    public void fixbag()
    {
        int index = 0;
        for (int i = 0; i < 32; i++)
        {
            if (items[i].goodid != 0)
            {
                items[index].goodid = items[i].goodid;
                items[index].num = items[i].num;
                if (i != index)
                {
                    items[i].goodid = 0;
                    items[i].num = 0;
                }
                index++;
            }
        }
        //for (int i = 0; i < index; i++)
        //{
        //    for(int j=i+1; j<index;j++)
        //    if (items[i].goodid>items[j].goodid)
        //    {
        //            int temp1 = items[i].goodid;
        //            items[i].goodid= items[j].goodid;
        //            items[j].goodid = temp1;
        //            int temp2 = items[i].num;
        //            items[i].num = items[j].num;
        //            items[j].num = temp2;
        //        }
        //}
    }
}

