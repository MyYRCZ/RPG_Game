using UnityEngine;
using System.Collections;

public class Equipattribute : SingletonMono<Equipattribute>
{
    [SerializeField]
    public int strength;//力量
    [SerializeField]
    public int agility;    //敏捷
    [SerializeField]
    public int intelligence;//智力
    [SerializeField]
    public int stamina;//耐力
    [SerializeField]
    public int Hp;    //生命上限
    [SerializeField]
    public int Mp;    //魔法值上限
    [SerializeField]
    public float crits;   ///暴击几率
    [SerializeField]
    public float refreshHp;   //血量恢复速度
    [SerializeField]
    public int attack; ///攻强
    [SerializeField]
    public int magic; ///法强
    [SerializeField]
    public int rapidly; ///急速
    [SerializeField]
    public int def; ///护甲
    [SerializeField]
    public float xixue;   //吸血
    [SerializeField]
    public float miss;   //闪避
    [SerializeField]
    public float addspeed;   //加速
                             // Use this for initialization



    public int weaponid;
    public int pantsid;
    public int bootsid;
    public int headid;
    public int backid;
    override protected void Awake()
    {
        base.Awake();

    }
    void Start () {
        getequipattribute();
        playerattribute.Instance.getattribute();
    }
	
	// Update is called once per frame
	void Update () {

        //getequipattribute();
       // playerattribute.Instance.getattribute();



    }
   public void getequipattribute()
    {
        strength = 0;
        agility = 0;
        intelligence = 0;
        stamina = 0;
        Hp = 0;
        Mp = 0;
        crits = 0;
        refreshHp = 0;
        attack = 0;
        magic = 0;
        rapidly = 0;
        def = 0;
        if (weaponid != 0)
        {
            strength += goods.Instance.Getgood(weaponid).strength;
            agility += goods.Instance.Getgood(weaponid).agility;
            intelligence += goods.Instance.Getgood(weaponid).intelligence;
            stamina += goods.Instance.Getgood(weaponid).stamina;
            Hp += goods.Instance.Getgood(weaponid).Hp;
            Mp += goods.Instance.Getgood(weaponid).Mp;
            crits += goods.Instance.Getgood(weaponid).crits;
            refreshHp += goods.Instance.Getgood(weaponid).refreshHp;
            attack += goods.Instance.Getgood(weaponid).attack;
            magic += goods.Instance.Getgood(weaponid).magic;
            rapidly += goods.Instance.Getgood(weaponid).rapidly;
            def += goods.Instance.Getgood(weaponid).def;
        }
      
        if (pantsid != 0)
        {
            strength += goods.Instance.Getgood(pantsid).strength;
            agility += goods.Instance.Getgood(pantsid).agility;
            intelligence += goods.Instance.Getgood(pantsid).intelligence;
            stamina += goods.Instance.Getgood(pantsid).stamina;
            Hp += goods.Instance.Getgood(pantsid).Hp;
            Mp += goods.Instance.Getgood(pantsid).Mp;
            crits += goods.Instance.Getgood(pantsid).crits;
            refreshHp += goods.Instance.Getgood(pantsid).refreshHp;
            attack += goods.Instance.Getgood(pantsid).attack;
            magic += goods.Instance.Getgood(pantsid).magic;
            rapidly += goods.Instance.Getgood(pantsid).rapidly;
            def += goods.Instance.Getgood(pantsid).def;
        }
        if (bootsid != 0)
        {
            strength += goods.Instance.Getgood(bootsid).strength;
            agility += goods.Instance.Getgood(bootsid).agility;
            intelligence += goods.Instance.Getgood(bootsid).intelligence;
            stamina += goods.Instance.Getgood(bootsid).stamina;
            Hp += goods.Instance.Getgood(bootsid).Hp;
            Mp += goods.Instance.Getgood(bootsid).Mp;
            crits += goods.Instance.Getgood(bootsid).crits;
            refreshHp += goods.Instance.Getgood(bootsid).refreshHp;
            attack += goods.Instance.Getgood(bootsid).attack;
            magic += goods.Instance.Getgood(bootsid).magic;
            rapidly += goods.Instance.Getgood(bootsid).rapidly;
            def += goods.Instance.Getgood(bootsid).def;
        }
        if (headid != 0)
        {
            strength += goods.Instance.Getgood(headid).strength;
            agility += goods.Instance.Getgood(headid).agility;
            intelligence += goods.Instance.Getgood(headid).intelligence;
            stamina += goods.Instance.Getgood(headid).stamina;
            Hp += goods.Instance.Getgood(headid).Hp;
            Mp += goods.Instance.Getgood(headid).Mp;
            crits += goods.Instance.Getgood(headid).crits;
            refreshHp += goods.Instance.Getgood(headid).refreshHp;
            attack += goods.Instance.Getgood(headid).attack;
            magic += goods.Instance.Getgood(headid).magic;
            rapidly += goods.Instance.Getgood(headid).rapidly;
            def += goods.Instance.Getgood(headid).def;
        }
        if (backid != 0)
        {
            strength += goods.Instance.Getgood(backid).strength;
            agility += goods.Instance.Getgood(backid).agility;
            intelligence += goods.Instance.Getgood(backid).intelligence;
            stamina += goods.Instance.Getgood(backid).stamina;
            Hp += goods.Instance.Getgood(backid).Hp;
            Mp += goods.Instance.Getgood(backid).Mp;
            crits += goods.Instance.Getgood(backid).crits;
            refreshHp += goods.Instance.Getgood(backid).refreshHp;
            attack += goods.Instance.Getgood(backid).attack;
            magic += goods.Instance.Getgood(backid).magic;
            rapidly += goods.Instance.Getgood(backid).rapidly;
            def += goods.Instance.Getgood(backid).def;
        }

    }
}
