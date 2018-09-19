using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class monsterbuff : MonoBehaviour
{
    public Transform buff;
    public Transform go1;
    public Transform go2;
    public Transform go3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // print(this.name);
        if (playerattribute.Instance.Target != null)
        {
            if (playerattribute.Instance.Target.tag == "Player")
            {
                if (playerattribute.Instance.buff3time != 0 && playerattribute.Instance.buff4time == 0)
                {
                    go1.transform.localScale = Vector3.one;
                    go2.transform.localScale = Vector3.zero;
                    go3.transform.localScale = Vector3.zero;
                    go1.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5003).path, typeof(Sprite)) as Sprite;
                    go1.transform.GetComponent<showbuff>().id = 5003;
                    go1.transform.GetComponent<showbuff>().time = playerattribute.Instance.buff3time;
                }
                else if (playerattribute.Instance.buff4time != 0 && playerattribute.Instance.buff3time == 0)
                {
                    go1.transform.localScale = Vector3.one;
                    go2.transform.localScale = Vector3.zero;
                    go3.transform.localScale = Vector3.zero;
                    // GameObject  go1= Instantiate(buff, transform) as GameObject;
                    go1.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5004).path, typeof(Sprite)) as Sprite;
                    go1.transform.GetComponent<showbuff>().id = 5004;
                    go1.transform.GetComponent<showbuff>().time = playerattribute.Instance.buff4time;
                }
                else if (playerattribute.Instance.buff4time != 0 && playerattribute.Instance.buff3time != 0)
                {
                    go1.transform.localScale = Vector3.one;
                    go2.transform.localScale = Vector3.one;
                    go3.transform.localScale = Vector3.zero;
                    go1.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5003).path, typeof(Sprite)) as Sprite;
                    go2.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5004).path, typeof(Sprite)) as Sprite;
                    go1.transform.GetComponent<showbuff>().id = 5003;
                    go1.transform.GetComponent<showbuff>().time = playerattribute.Instance.buff3time;
                    go2.transform.GetComponent<showbuff>().id = 5004;
                    go2.transform.GetComponent<showbuff>().time = playerattribute.Instance.buff4time;
                }
                else
                {
                    go1.transform.localScale = Vector3.zero;
                    go2.transform.localScale = Vector3.zero;
                    go3.transform.localScale = Vector3.zero;
                }



            }
            if (playerattribute.Instance.Target.tag == "Monster")
            {

                if (playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff1time != 0 && playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff2time == 0 && playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff5time == 0)
                {
                    go1.transform.localScale = Vector3.one;
                    go2.transform.localScale = Vector3.zero;
                    go3.transform.localScale = Vector3.zero;
                    go1.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5001).path, typeof(Sprite)) as Sprite;
                    go1.transform.GetComponent<showbuff>().id = 5001;
                    go1.transform.GetComponent<showbuff>().time = playerattribute.Instance.Target.transform.transform.Find("monster").GetComponent<enemyattribute>().buff1time;
                }
                else if (playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff1time == 0 && playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff2time != 0 && playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff5time == 0)
                {
                    go1.transform.localScale = Vector3.one;
                    go2.transform.localScale = Vector3.zero;
                    go3.transform.localScale = Vector3.zero;
                    go1.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5002).path, typeof(Sprite)) as Sprite;
                    go1.transform.GetComponent<showbuff>().id = 5002;
                    go1.transform.GetComponent<showbuff>().time = playerattribute.Instance.Target.transform.transform.Find("monster").GetComponent<enemyattribute>().buff2time;
                }
                else if (playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff1time == 0 && playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff2time == 0 && playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff5time != 0)
                {
                    go1.transform.localScale = Vector3.one;
                    go2.transform.localScale = Vector3.zero;
                    go3.transform.localScale = Vector3.zero;
                    go1.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5005).path, typeof(Sprite)) as Sprite;
                    go1.transform.GetComponent<showbuff>().id = 5005;
                    go1.transform.GetComponent<showbuff>().time = playerattribute.Instance.Target.transform.transform.Find("monster").GetComponent<enemyattribute>().buff5time;
                }
                else if (playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff1time != 0 && playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff2time != 0 && playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff5time == 0)
                {
                    go1.transform.localScale = Vector3.one;
                    go2.transform.localScale = Vector3.one;
                    go3.transform.localScale = Vector3.zero;
                    go1.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5001).path, typeof(Sprite)) as Sprite;
                    go1.transform.GetComponent<showbuff>().id = 5001;
                    go1.transform.GetComponent<showbuff>().time = playerattribute.Instance.Target.transform.transform.Find("monster").GetComponent<enemyattribute>().buff1time;
                    go2.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5002).path, typeof(Sprite)) as Sprite;
                    go2.transform.GetComponent<showbuff>().id = 5002;
                    go2.transform.GetComponent<showbuff>().time = playerattribute.Instance.Target.transform.transform.Find("monster").GetComponent<enemyattribute>().buff2time;
                }
                else if (playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff1time == 0 && playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff2time != 0 && playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff5time != 0)
                {
                    go1.transform.localScale = Vector3.one;
                    go2.transform.localScale = Vector3.one;
                    go3.transform.localScale = Vector3.zero;
                    go1.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5005).path, typeof(Sprite)) as Sprite;
                    go1.transform.GetComponent<showbuff>().id = 5005;
                    go1.transform.GetComponent<showbuff>().time = playerattribute.Instance.Target.transform.transform.Find("monster").GetComponent<enemyattribute>().buff5time;
                    go2.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5002).path, typeof(Sprite)) as Sprite;
                    go2.transform.GetComponent<showbuff>().id = 5002;
                    go2.transform.GetComponent<showbuff>().time = playerattribute.Instance.Target.transform.transform.Find("monster").GetComponent<enemyattribute>().buff2time;
                }
                else if (playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff1time != 0 && playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff2time == 0 && playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff5time != 0)
                {
                    go1.transform.localScale = Vector3.one;
                    go2.transform.localScale = Vector3.one;
                    go3.transform.localScale = Vector3.zero;
                    go1.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5001).path, typeof(Sprite)) as Sprite;
                    go1.transform.GetComponent<showbuff>().id = 5001;
                    go1.transform.GetComponent<showbuff>().time = playerattribute.Instance.Target.transform.transform.Find("monster").GetComponent<enemyattribute>().buff1time;
                    go2.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5005).path, typeof(Sprite)) as Sprite;
                    go2.transform.GetComponent<showbuff>().id = 5005;
                    go2.transform.GetComponent<showbuff>().time = playerattribute.Instance.Target.transform.transform.Find("monster").GetComponent<enemyattribute>().buff5time;
                }
                else if (playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff1time != 0 && playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff2time != 0 && playerattribute.Instance.Target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff5time != 0)
                {
                    go1.transform.localScale = Vector3.one;
                    go2.transform.localScale = Vector3.one;
                    go3.transform.localScale = Vector3.one;
                    go1.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5001).path, typeof(Sprite)) as Sprite;
                    go1.transform.GetComponent<showbuff>().id = 5001;
                    go1.transform.GetComponent<showbuff>().time = playerattribute.Instance.Target.transform.transform.Find("monster").GetComponent<enemyattribute>().buff1time;
                    go2.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5002).path, typeof(Sprite)) as Sprite;
                    go2.transform.GetComponent<showbuff>().id = 5002;
                    go2.transform.GetComponent<showbuff>().time = playerattribute.Instance.Target.transform.transform.Find("monster").GetComponent<enemyattribute>().buff2time;
                    go3.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5005).path, typeof(Sprite)) as Sprite;
                    go3.transform.GetComponent<showbuff>().id = 5005;
                    go3.transform.GetComponent<showbuff>().time = playerattribute.Instance.Target.transform.transform.Find("monster").GetComponent<enemyattribute>().buff5time;
                }

                else
                {
                    go1.transform.localScale = Vector3.zero;
                    go2.transform.localScale = Vector3.zero;
                    go3.transform.localScale = Vector3.zero;
                }
            }
             if (playerattribute.Instance.Target.tag == "NPC")
            {
                go1.transform.localScale = Vector3.zero;
                go2.transform.localScale = Vector3.zero;
                go3.transform.localScale = Vector3.zero;

            }
        }

    }
}
