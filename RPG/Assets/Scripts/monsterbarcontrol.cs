using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class monsterbarcontrol : MonoBehaviour
{


    public GameObject hpbar;
    public GameObject ui;
    private GameObject m_hpbar;
    public Transform head;

    public RectTransform rectBloodPos;


    private Button check;
    // Use this for initialization
    void Start()
    {


        m_hpbar = Instantiate(hpbar);
        m_hpbar.transform.SetParent(ui.transform);
        rectBloodPos = m_hpbar.GetComponent<RectTransform>();
        check = m_hpbar.GetComponentInChildren<Button>();
        check.GetComponent<Button>().onClick.AddListener(pressbutton);
        Transform go = m_hpbar.transform.Find("jiantou");
        go.GetComponent<Image>().color = new Color(go.GetComponent<Image>().color.r, go.GetComponent<Image>().color.g, go.GetComponent<Image>().color.b, 0);


    }

    // Update is called once per frame
    void Update()
    {
      // print( head.transform.parent.GetComponent<enemyattribute>().isdead);
        float angle = Vector3.Angle(Camera.main.transform.forward, Camera.main.transform.transform.position - transform.position);
        if (Vector3.Distance(head.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 50||
           (angle <= 85 && Vector3.Distance(head.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 10)||head.transform.parent.GetComponent<enemyattribute>().isdead)
        {
            m_hpbar.SetActive(false);
        }
        else
        {
                m_hpbar.SetActive(true);
                rectBloodPos = WorldToUI(head.position);    
        }

        if(playerattribute.Instance.Target==this.transform.parent&& angle >= 85&&!head.transform.parent.GetComponent<enemyattribute>().isdead)
        {
            m_hpbar.transform.localScale = new Vector3(1.2f, 1.2f, 1);
            // m_hpbar.transform.FindChild("箭头").GetComponent<GameObject>().SetActive(true);
            Transform go = m_hpbar.transform.Find("jiantou");
            go.GetComponent<Image>().color = new Color(go.GetComponent<Image>().color.r, go.GetComponent<Image>().color.g, go.GetComponent<Image>().color.b, 1);
            m_hpbar.SetActive(true);
            rectBloodPos = WorldToUI(head.position);
        }
        else
        {
            m_hpbar.transform.localScale = new Vector3(1, 1, 1);
            // m_hpbar.transform.FindChild("箭头").GetComponent<GameObject>().SetActive(true);
            Transform go = m_hpbar.transform.Find("jiantou");
            go.GetComponent<Image>().color = new Color(go.GetComponent<Image>().color.r, go.GetComponent<Image>().color.g, go.GetComponent<Image>().color.b, 0);
        }
        
        m_hpbar.transform.Find("hpbackground").transform.Find("hpfill").GetComponent<Image>().fillAmount= this.GetComponent<enemyattribute>().Now_Hp / this.GetComponent<enemyattribute>().Max_Hp;
        m_hpbar.transform.Find("hpbackground").transform.Find("monstername").GetComponent<Text>().text = this.GetComponent<enemyattribute>().monstername;
        m_hpbar.transform.Find("hpbackground").transform.Find("hp%").GetComponent<Text>().text= this.GetComponent<enemyattribute>().Now_Hp / this.GetComponent<enemyattribute>().Max_Hp*100+"%";
        m_hpbar.transform.Find("hpbackground").transform.Find("hp").GetComponent<Text>().text = this.GetComponent<enemyattribute>().Now_Hp+ "/"+ this.GetComponent<enemyattribute>().Max_Hp ;


    }
    public RectTransform WorldToUI(Vector3 point)
    {
        Vector2 vec2 = Camera.main.WorldToScreenPoint(head.position);

        rectBloodPos.anchoredPosition = new Vector2(vec2.x - Screen.width / 2 + 0, vec2.y - Screen.height / 2);
        return rectBloodPos;

    }
    public void pressbutton()
    {
      
        playerattribute.Instance.Target = this.transform.parent;
    }



}


