using UnityEngine;
using System.Collections;

public class EscButtongroup : SingletonMono<EscButtongroup> {
    private bool open;
    public Transform character;
    public Transform bag;
    public Transform quest;
    public Transform skill;
    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (open)
        {
            if (character.GetComponent<characterwindow>().open == true || bag.GetComponent<bagwindow>().open == true || quest.GetComponent<questcontrol>().open == true)
            {
                closewindow();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(quest.GetComponent<questcontrol>().open==true)
            {
                quest.GetComponent<questcontrol>().window();
                return;
            }
           else  if (bag.GetComponent<bagwindow>().open == true)
            {
                bag.GetComponent<bagwindow>().window();
                return;
            }
            else if (skill.GetComponent<windowskill>().open == true)
            {
                skill.GetComponent<windowskill>().window();
                return;
            }
            else if (character.GetComponent<characterwindow>().open == true)
            {
                character.GetComponent<characterwindow>().window();
                return;
            }
            else if (playerattribute.Instance.Target!=null)
            {
                playerattribute.Instance.Target = null;
                return;
            }
            else
            {
                window();
            }
        }
      
	}
    public void openwindow()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
        open = true;
      



    }
    public void closewindow()
    {
        this.transform.localScale = new Vector3(0, 1, 1);
        open = false;
    }
    public void window()
    {
        if (!open)
        {
            openwindow();
        }
        else
        {
            closewindow();
        }
    }
    public void exit()
    {
        Application.Quit();
    }
}
