using UnityEngine;
using System.Collections;

public class deathui : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(playerattribute.Instance.isdead)
        {
            this.transform.localScale = Vector3.one;
            WalkingOrc.Instance.animator.SetBool("isdead", true);


        }
        else
        {
            this.transform.localScale = Vector3.zero;
            WalkingOrc.Instance.animator.SetBool("isdead", false);


        }
    }
    public void refreshdeath()
    {
        playerattribute.Instance.isdead = false;
        playerattribute.Instance.Now_Hp = playerattribute.Instance.Max_Hp;
        playerattribute.Instance.Now_Mp = playerattribute.Instance.Max_Mp;
        WalkingOrc.Instance.animator.SetBool("isdead", false);

    }
}
