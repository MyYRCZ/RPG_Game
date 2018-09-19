using UnityEngine;
using System.Collections;

public class minmapcontrol : MonoBehaviour {
    public Camera mimapcam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   public void jiansize()
    {
        mimapcam.orthographicSize -= 1;
        if (mimapcam.orthographicSize<5)
        {
            mimapcam.orthographicSize = 5;
        }
    }
    public void jiasize()
    {
        mimapcam.orthographicSize+= 1;
        if (mimapcam.orthographicSize >11)
        {
            mimapcam.orthographicSize = 11;
        }
    }
}
