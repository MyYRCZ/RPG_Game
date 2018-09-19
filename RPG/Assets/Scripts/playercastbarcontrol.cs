using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playercastbarcontrol : SingletonMono<playercastbarcontrol>
{
    private float nowtime;
    private float casttime;
    public bool iscast;
    private int usemp = 0;
    private int useid;
    private Transform casttarget;
    private int skilldamage;

    private float stoptime;
    override protected void Awake()
    {
        base.Awake();

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (stoptime >= 0 && !iscast)
        {
            stoptime += Time.deltaTime;
            if (stoptime >= 1f)
            {
                this.transform.localScale = Vector3.zero;
                this.transform.Find("castfill").GetComponent<Image>().color = Color.green;
                stoptime = 0;
                nowtime = 0;
            }

        }
        if (iscast)
        {

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                iscast = false;
                stoptime += Time.deltaTime;
                this.transform.Find("text").transform.Find("skillname").transform.GetComponent<Text>().text = "被打断";
                this.transform.Find("castfill").GetComponent<Image>().color = Color.red;
            }
            if (useid != 1004)
            {
                nowtime += Time.deltaTime;
                this.transform.Find("text").transform.Find("nowtime").transform.GetComponent<Text>().text = nowtime + "";
                this.transform.Find("castfill").transform.GetComponent<Image>().fillAmount = nowtime / casttime;
                if (nowtime >= casttime)
                {
                    iscast = false;
                    nowtime = 0;
                    this.transform.localScale = new Vector3(0, 1, 1);


                    if (Vector3.Angle(playerattribute.Instance.transform.forward, playerattribute.Instance.Target.transform.Find("monster").transform.position - playerattribute.Instance.transform.position) < 70)
                    {
                        playerattribute.Instance.Now_Mp -= usemp;
                        skilleffect.Instance.casteffect(useid, casttarget, skilldamage);
                        playerattribute.Instance.GetComponentInChildren<Animator>().SetBool("Attack", true);
                        //playerattribute.Instance.Target.transform.FindChild("monster").transform.GetComponent<enemyattribute>().Target= playerattribute.Instance.transform;
                    }
                    else
                    {
                        print("面朝错误的方向");
                    }
                }
            }
            else
            {
                nowtime += Time.deltaTime;
                this.transform.Find("text").transform.Find("nowtime").transform.GetComponent<Text>().text = nowtime + "";
                this.transform.Find("castfill").transform.GetComponent<Image>().fillAmount = nowtime / casttime;
                if (nowtime >= casttime)
                {
                    iscast = false;
                    nowtime = 0;
                    this.transform.localScale = new Vector3(0, 1, 1);
                    playerattribute.Instance.Now_Mp -= usemp;
                    skilleffect.Instance.casteffect(useid, casttarget, skilldamage);
                    playerattribute.Instance.GetComponentInChildren<Animator>().SetBool("Attack", true);

                }
            }
        }

    }
    public void cast(int id, Sprite sp, string skillname, float time, int mp, Transform target, int damage)
    {
        this.transform.localScale = new Vector3(1, 1, 1);
        this.transform.Find("castfill").GetComponent<Image>().color = Color.green;
        this.transform.Find("text").transform.Find("subtime").transform.GetComponent<Text>().text = (time / (1 + playerattribute.Instance.rapidly / 3000f)) + "";
        casttime = (time / (1 + playerattribute.Instance.rapidly / 3000f));
        this.transform.Find("text").transform.Find("skillname").transform.GetComponent<Text>().text = skillname;
        this.transform.Find("icon").transform.Find("Image").transform.GetComponent<Image>().sprite = sp;
        iscast = true;
        usemp = mp;
        useid = id;
        casttarget = target;
        skilldamage = damage;
        nowtime = 0;
        stoptime = 0;
    }
}
// cooldowntime 
