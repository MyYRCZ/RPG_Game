using UnityEngine;
using System.Collections;

public class enemyattribute : MonoBehaviour {
    [SerializeField] public Transform Target;//怪物目标
    [SerializeField]public string monstername;//怪物名字
    [SerializeField] public bool isboss;//是否为boss;
    [SerializeField]public int level;//怪物等级;
    [SerializeField]public int Min_Damage;//最小攻击
    [SerializeField]public int Max_Damage;//最大攻击
    [SerializeField]public float Now_Hp;    //当前生命值
    [SerializeField] public float Max_Hp;    //最大生命值
    [SerializeField]public float Now_Mp;    //当前蓝量
    [SerializeField]public float Max_Mp;    //最大蓝量
    [SerializeField] public int NormalAttack_distance;   //普通攻击距离
    [SerializeField] public int refreshHp;   //血量恢复速度
    [SerializeField] public bool isbattle;    //是否进入战斗
    [SerializeField]public float doubledamagepercent;   //暴击几率
    [SerializeField] public float Damagereductioncoefficient; //减伤系数
    [SerializeField]public float Curspeed;   //移动速度
    [SerializeField]public string image;   //图片
    [SerializeField]public Vector3 size;   //图片
    
    public float buff1time;
    public float buff2time;
    public float buff5time;
    public float nowtime;
    public bool isdead;
    public bool isdrag;
    private Animator ani;
    private float i = 1;
   
    bool speedchange;
    bool hpchange;


    // Use this for initialization
    void Start () {
        ani = this.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        death();
        if(isboss&&Now_Hp/Max_Mp<=0.3f)
        {
            buff5time += Time.deltaTime;
        }
        if(isboss&& Now_Hp / Max_Mp <= 0.5f)
        {


        }
        if(Target==null&&isboss&&!isbattle)
        {
            this.transform.parent.localScale = Vector3.one;
            i = 1;
            Max_Hp = 300;
            Now_Hp = 300;
            hpchange = false;
            buff5time = 0;
        }
       // print(isdead);
    if (playerattribute.Instance.Target==this.transform.parent)
        {
            this.transform.Find("Plane").localScale = size;
        }
    else
        {
            this.transform.Find("Plane").localScale = Vector3.zero;
        }
        if (buff2time != 0)
        {
            buff2time += Time.deltaTime;
            if(!speedchange)
            {
                Curspeed = Curspeed *0.6f;
                speedchange = true;
            }
         
            if (buff2time >= buffs.Instance.Getbuff(5002).time)
            {
                buff2time = 0;
                Curspeed = Curspeed / 0.6f;
            }

        }
        else
        {
           
            speedchange = false;
        }
        if (buff1time != 0)
        {
            nowtime += Time.deltaTime;
            buff1time += Time.deltaTime;
            if (nowtime >= 1)
            {
                Now_Hp -= (int)(playerattribute.Instance.magic * 0.2f) + 1;
                showdamgecontrol.Instance.adddamge(Resources.Load(buffs.Instance.Getbuff(5001).path, typeof(Sprite)) as Sprite, -((int)(playerattribute.Instance.magic * 0.2f) + 1));
                nowtime = 0;
            }
            if (buff1time >= buffs.Instance.Getbuff(5001).time)
            {
                buff1time = 0;
                nowtime = 0;
            }
        }
        if (buff5time != 0)
        {
          
            i += 1.5f / 60f;
            if(i>=1.3f)
            {
                i = 1.3f;
            }
            if (!hpchange)
            {
                this.transform.parent.localScale = new Vector3(i, i, i);
                Now_Hp *= 2;
                Max_Hp *= 2;
                hpchange = true;
            }
           if(Now_Hp<=0)
            {
                this.transform.parent.localScale = Vector3.one;
                i = 1;
                Max_Hp /= 2;
                hpchange = false;
                buff5time = 0;
            }
        }
        else
        { 
}
    }


    public void normalattack()
    {
        print("damagedown" + Random.Range(Min_Damage, Max_Damage) );
        playerattribute.Instance.Now_Hp -= (int)(Random.Range(Min_Damage, Max_Damage) * (1.0f - playerattribute.Instance.Damagereductioncoefficient));
    }


    public void death()
    {
        if (Now_Hp <= 0)
        {
            Now_Hp = 0;
            isdead = true;
            buff5time = 0;
            Target = null;
            buff1time = 0;
            buff2time = 0;
        
        }
    }
}
