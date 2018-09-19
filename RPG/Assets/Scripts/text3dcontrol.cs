using UnityEngine;
using System.Collections;

public class text3dcontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.forward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);

        if(this.transform.parent.name=="NPC1")
        {
            if(playerattribute.Instance.quest1==0)
            {
                this.transform.GetComponent<TextMesh>().text = "!";
                this.transform.GetComponent<TextMesh>().color = Color.yellow;
            }
            if (playerattribute.Instance.quest1 == 1)
            {
                this.transform.GetComponent<TextMesh>().text = "?";

                if(questcontrol.Instance.quest1num>=3)
                {
                    this.transform.GetComponent<TextMesh>().color = Color.yellow;
                }
                else
                {
                    this.transform.GetComponent<TextMesh>().color = Color.grey;
                }
               
            }
            if (playerattribute.Instance.quest1 == 2)
            {
                this.transform.GetComponent<TextMesh>().text = "";
            }

        }

        if (this.transform.parent.name == "NPC2")
        {
            if (playerattribute.Instance.quest2 == 0)
            {
                this.transform.GetComponent<TextMesh>().text = "!";
                this.transform.GetComponent<TextMesh>().color = Color.yellow;
            }
            if (playerattribute.Instance.quest2 == 1)
            {
                this.transform.GetComponent<TextMesh>().text = "?";

                if (questcontrol.Instance.quest2num >= 3)
                {
                    this.transform.GetComponent<TextMesh>().color = Color.yellow;
                }
                else
                {
                    this.transform.GetComponent<TextMesh>().color = Color.grey;
                }

            }
            if (playerattribute.Instance.quest2 == 2)
            {
                this.transform.GetComponent<TextMesh>().text = "";
            }

        }


    }
}
