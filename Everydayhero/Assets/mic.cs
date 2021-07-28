using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mic : MonoBehaviour
{
    private float timecount = 0;
    public float stoptime;
    public float recovertime;
    public bool Stopcases = false;

    // Update is called once per frame
    void Update()
    {
        if(Stopcases == true)
        {
            timecount += Time.deltaTime;
        }
        if(timecount >= stoptime)
        {
            GameObject.Find("spawn (3)").GetComponent<Create>().DisTime = recovertime;
            Stopcases = false;
        }
    }
    private void OnMouseDown()
    {
        if(Stopcases == false)
        {
            Stopcases = true;
            GameObject.Find("spawn (3)").GetComponent<Create>().DisTime = stoptime;
        }
    }
}
