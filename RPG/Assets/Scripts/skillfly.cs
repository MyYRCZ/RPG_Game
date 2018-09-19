using UnityEngine;
using System.Collections;

public class skillfly : MonoBehaviour
{
    public Transform target;
    public int damage;
    public int id;
    bool follow = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            this.transform.position = target.position;
        }

        if (id != 1004)
        {
            float dis = Vector3.Distance(transform.position, new Vector3(target.transform.Find("monster").transform.position.x, target.transform.Find("monster").transform.position.y + 1.2f, target.transform.Find("monster").transform.position.z));
            if (dis <= 0.5)
            {
                int c = Random.Range(0, 100);
                if (c <= playerattribute.Instance.crits * 100)
                {
                    target.transform.Find("monster").transform.GetComponent<enemyattribute>().Now_Hp -= (int)(2 * playerattribute.Instance.Damagecoefficient * damage * (1 - target.transform.Find("monster").transform.GetComponent<enemyattribute>().Damagereductioncoefficient)) + 1;
                    showdamgecontrol.Instance.adddamge(Resources.Load(skills.Instance.Getskill(id).path, typeof(Sprite)) as Sprite, -(int)(2 * damage * playerattribute.Instance.Damagecoefficient * (1 - target.transform.Find("monster").transform.GetComponent<enemyattribute>().Damagereductioncoefficient)) + 1);
                }
                else
                {
                    target.transform.Find("monster").transform.GetComponent<enemyattribute>().Now_Hp -= (int)(damage * playerattribute.Instance.Damagecoefficient * (1 - target.transform.Find("monster").transform.GetComponent<enemyattribute>().Damagereductioncoefficient) + 1);
                    showdamgecontrol.Instance.adddamge(Resources.Load(skills.Instance.Getskill(id).path, typeof(Sprite)) as Sprite, -(int)(damage * playerattribute.Instance.Damagecoefficient*(1 - target.transform.Find("monster").transform.GetComponent<enemyattribute>().Damagereductioncoefficient) + 1));
                }

                target.transform.Find("monster").transform.GetComponent<enemyattribute>().Target = playerattribute.Instance.transform;

                //在ui显示伤害结果;
                if (id == 1001)   //判断技能id为3001火球 添加灼烧效果
                {
                    target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff1time = 0.01f;
                }
                if (id == 1002)   //判断技能id为3002火球 添加减速效果
                {
                    target.transform.Find("monster").transform.GetComponent<enemyattribute>().buff2time = 0.01f;
                }


                Destroy(this.gameObject);

            }
            else
            {
                this.transform.Translate((new Vector3(target.transform.Find("monster").transform.position.x, target.transform.Find("monster").transform.position.y + 1.2f, target.transform.Find("monster").transform.position.z) - transform.position).normalized * 0.3f);
            }

    }
            else
            {
                follow = true;
                if (playerattribute.Instance.buff4time == 0)

                {
                    Destroy(this.gameObject);
}
            }
       
    }

}
