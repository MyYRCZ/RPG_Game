using UnityEngine;
using System.Collections;

public class skilleffect : SingletonMono<skilleffect>
{

    // Use this for initialization
    override protected void Awake()
    {
        base.Awake();

    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void casteffect(int id,Transform target,int damage)
    {
        if(id!=1004)
        {
            GameObject go = Instantiate(Resources.Load("skilleffect/" + id) as GameObject);
            go.transform.position = new Vector3(playerattribute.Instance.transform.position.x, playerattribute.Instance.transform.position.y + 1, transform.position.z);
            go.transform.GetComponent<skillfly>().target = target;
            go.transform.GetComponent<skillfly>().damage = damage;
            go.transform.GetComponent<skillfly>().id = id;
        }
        else if(id==1004)
        {
            GameObject go = Instantiate(Resources.Load("skilleffect/" + id) as GameObject);
            go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, transform.position.z);
            go.transform.GetComponent<skillfly>().target = target;
            go.transform.GetComponent<skillfly>().damage = damage;
            go.transform.GetComponent<skillfly>().id = id;
            int c = Random.Range(0, 100);
            if (c <= playerattribute.Instance.crits * 100)
            {
                playerattribute.Instance.Now_Hp += (int)(2 * damage * playerattribute.Instance.Damagecoefficient);
                showdamgecontrol.Instance.adddamge(Resources.Load(skills.Instance.Getskill(id).path, typeof(Sprite)) as Sprite, +(int)(2 * damage * playerattribute.Instance.Damagecoefficient));
            }
            else
            {
                playerattribute.Instance.Now_Hp += (int)(damage * playerattribute.Instance.Damagecoefficient);
                showdamgecontrol.Instance.adddamge(Resources.Load(skills.Instance.Getskill(id).path, typeof(Sprite)) as Sprite, +(int)(damage * playerattribute.Instance.Damagecoefficient));
            }

            playerattribute.Instance.buff4time = 0.01f;

        }



    }


}
