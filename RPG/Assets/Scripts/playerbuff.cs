using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerbuff : MonoBehaviour
{
    public Transform buff;
    public Transform go1;
    public Transform go2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerattribute.Instance.buff3time != 0 && playerattribute.Instance.buff4time == 0)
        {
            go1.transform.localScale = Vector3.one;
            go2.transform.localScale = Vector3.zero;
            go1.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5003).path, typeof(Sprite)) as Sprite;
            go1.transform.GetComponent<showbuff>().id = 5003;
            go1.transform.GetComponent<showbuff>().time = playerattribute.Instance.buff3time;
        }
        else if (playerattribute.Instance.buff4time != 0 && playerattribute.Instance.buff3time == 0)
        {
            go1.transform.localScale = Vector3.one;
            go2.transform.localScale = Vector3.zero;
            // GameObject  go1= Instantiate(buff, transform) as GameObject;
            go1.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5004).path, typeof(Sprite)) as Sprite;
            go1.transform.GetComponent<showbuff>().id = 5004;
            go1.transform.GetComponent<showbuff>().time = playerattribute.Instance.buff4time;
        }
        else if (playerattribute.Instance.buff4time != 0 && playerattribute.Instance.buff3time != 0)
        {
            go1.transform.localScale = Vector3.one;
            go2.transform.localScale = Vector3.one;
            go1.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5003).path, typeof(Sprite)) as Sprite;
            go2.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load(buffs.Instance.Getbuff(5004).path, typeof(Sprite)) as Sprite;
            go1.transform.GetComponent<showbuff>().id = 5003;
            go1.transform.GetComponent<showbuff>().time = playerattribute.Instance.buff3time;
            go2.transform.GetComponent<showbuff>().id = 5004;
            go2.transform.GetComponent<showbuff>().time = playerattribute.Instance.buff4time;
        }
        else
        {
            go1.transform.localScale = Vector3.zero;
            go2.transform.localScale = Vector3.zero;
        }
    }
}
