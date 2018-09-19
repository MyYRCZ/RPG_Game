using UnityEngine;
using System.Collections;

public class playerattribute :  SingletonMono<playerattribute>
{
    [SerializeField]
    public bool zhongzu=true;    //目标
    [SerializeField]
    public string Playername;    //目标
    [SerializeField]
    public Transform Target;    //目标
    [SerializeField]
    public bool isbattle;    //是否进入战斗
    [SerializeField]
    public bool isdead=false;    //是否死亡
    [SerializeField]
    public int level =1;//dengji
    [SerializeField]
    public float exp = 0;//exp
    [SerializeField]
    public float neddexp = 100;//exp
    [SerializeField]
    public int strength;//力量
    [SerializeField]
    public int agility;    //敏捷
    [SerializeField]
    public int intelligence;//智力
    [SerializeField]
    public int stamina;//耐力
    [SerializeField]
    public float Now_Hp;    //当前生命值
    [SerializeField]
    public float Max_Hp;    //最大生命值
    [SerializeField]
    public float Now_Mp;    //当前蓝量
    [SerializeField]
    public float Max_Mp;    //最大蓝量

    [SerializeField]
    public float crits;   ///暴击几率
    [SerializeField]
    public float refreshHp;   //血量恢复速度
    
    [SerializeField]
    public int rapidly; ///急速
    [SerializeField]
    public int attack; ///攻强
    [SerializeField]
    public int magic; ///法强
    [SerializeField]
    public int def; ///护甲
    [SerializeField]
    public float Damagereductioncoefficient; //减伤系数
    [SerializeField]
    public float Damagecoefficient; //伤害系数
    [SerializeField]
    public float movespeed;   //移动速度

    [SerializeField]
    public float xixue;   //吸血
    [SerializeField]
    public float miss;   //闪避
    [SerializeField]
    public float addspeed;   //加速
                             // Use this for initializations
    public int quest1;   
    public int quest2;     //任务


    public float buff3time;
    public float buff4time;
    public float nowtime;

    public int gold;

    private float addtime = 0;
    override protected void Awake()
    {
        base.Awake();
       
    }
    void Start () {
        getattribute();
        neddexp = level * 100;
        Now_Hp = Max_Hp;
        Now_Mp = Max_Mp;

        Playername= choosechaaracter.playername;
        zhongzu = choosechaaracter.zhongzu;
    }
	
	// Update is called once per frame
	void Update () {
        neddexp = level * 100;
        if (!isdead)
        refreshhpmp();
     
        if (Now_Hp<=0)
        {
            isdead = true;
            Now_Hp = 0;
        }
        if(buff3time!=0)
        {
            buff3time += Time.deltaTime;
            Damagecoefficient = 1.3f;
            if(buff3time>=buffs.Instance.Getbuff(5003).time)
            {
                buff3time = 0;
            }
            
        }
        else
        {
            Damagecoefficient = 1;
        }
        if (buff4time != 0)
        {
            nowtime += Time.deltaTime;
            buff4time += Time.deltaTime;
            if(nowtime>=1)
            {
                Now_Hp += (int)magic * 0.3f + 1;
                //ui显示 留空;
                showdamgecontrol.Instance.adddamge(Resources.Load(skills.Instance.Getskill(1004).path, typeof(Sprite)) as Sprite, +(int)((int)magic * 0.3f + 1));
                nowtime = 0;
            }
            if (buff4time >= buffs.Instance.Getbuff(5004).time)
            {
                buff4time = 0;
                nowtime = 0;
            }
        }



    }

    public void getattribute()
    {
        strength = level * 2+ Equipattribute.Instance.strength;                   //力量
        agility = level * 2+Equipattribute.Instance.agility;                      //敏捷
        intelligence = level * 2+ Equipattribute.Instance.intelligence;           //智力
        stamina = level * 2+ Equipattribute.Instance.stamina;                     //耐力
        Max_Hp=40+5* stamina + Equipattribute.Instance.Hp;                         //生命上限
        Max_Mp = 50 + Equipattribute.Instance.Mp;                                 //魔法上限
        if (intelligence >= 200)                                                     //暴击几率
        {
                crits = 0.2f + Equipattribute.Instance.crits;
        }
        else
        {
            crits = 0.001f * intelligence + Equipattribute.Instance.crits;
        }
        rapidly= agility+ Equipattribute.Instance.rapidly;                      //急速
        attack = (int)(strength+ agility*0.6f+ Equipattribute.Instance.attack);  //攻强
        magic = intelligence + Equipattribute.Instance.magic;                    //法强
        def= strength+ stamina*3+ Equipattribute.Instance.def;                   //护甲
        refreshHp = 0.01f+Equipattribute.Instance.refreshHp;                           //生命回复速度


            if (def<=100)                                                             //减伤 系数
        {
            Damagereductioncoefficient = (def/10f)/100f;
        }
        else if(def<=1000)
        {
            Damagereductioncoefficient =(10 + (def - 100) / 45f)/100f;
        }
        else if(def<=10000)
        {
            Damagereductioncoefficient = (30 + (def - 1000) / 450f) / 100f;
        }
        else
        {
            Damagereductioncoefficient = (50 + (def - 10000) / 5000f) / 100f;
        }
    }

    void refreshhpmp()
    {
        addtime += Time.deltaTime;


        if (Now_Hp > Max_Hp)
        {
            Now_Hp = Max_Hp;
        }
        if (Now_Mp > Max_Mp)
        {
            Now_Mp = Max_Mp;
        }
        
        if ( addtime>=2)
        {
            if (Now_Hp < Max_Hp)
            {
                if (isbattle)
                {
                    Now_Hp += (int)(refreshHp * Max_Hp);
                    Mathf.Clamp(Now_Hp, 0, Max_Hp);
                }
                else
                {
                    Now_Hp += (int)((refreshHp + 0.02) * Max_Hp);
                    Mathf.Clamp(Now_Hp, 0, Max_Hp);
                }
            }
            if (Now_Mp < Max_Mp)
            {
                if (isbattle)
                {
                    Now_Mp += 1+(int)(0.02f * Max_Mp);
                }
                else
                {
                    Now_Mp += (int)(0.05f * Max_Mp);
                  
                }
            }
            addtime = 0;

        }
       
    }
}
