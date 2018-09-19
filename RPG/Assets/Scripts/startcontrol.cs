using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startcontrol : MonoBehaviour {
    static private string nextlevel;
    AsyncOperation async;
    public Slider slider;
    public Text text;
    public float temp;
	// Use this for initialization
	void Start () {
        temp = 0;
        //print(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "loading")
        {

            async = SceneManager.LoadSceneAsync(nextlevel);
            async.allowSceneActivation = false;
            
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (text && slider)
        {
            temp = Mathf.Lerp(temp, async.progress, Time.deltaTime);
            text.text =(int)(temp / 9 * 10 * 100) + "%";
            slider.value = temp / 9 * 10;
            if (temp / 9 * 10 > 0.995)
            {

                text.text = 100.ToString() + "%";
                slider.value = 1;
                async.allowSceneActivation = true;
            }
        }
    }
    public void loadscence(string name)
    {
        nextlevel = name;
        SceneManager.LoadScene("loading");  
    }
}
