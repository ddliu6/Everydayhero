using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Load : MonoBehaviour
{
   
    public string sceneName;
    public GameObject res;
    //public AudioClip audioFinish;

    //float AllTime;
    //int total = 30;
    bool isEnd = false;
    public GameObject finish;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float time = GameObject.Find("Count").GetComponent<Count>().showTimeLeft();

        if (time == 0f) 
        {
            //if (DrawLine.gameObjects.Count == 0)
            {
                Time.timeScale = 0;
                res.SetActive(true);
                finish.SetActive(true);
                if (Count.curCovidCount != 0)
                {
                    Count.instance.FinalCovid();
                }
                if (Count.MoveCount != 0)
                {
                    Count.instance.FinalMove();
                }
                if (Count.MaskCount != 0)
                {
                    Count.instance.FinalMask();
                }
                if (Count.InsfectionCount != 0)
                {
                    Count.instance.FinalInfection();
                }
                
                
                if (Input.anyKeyDown && isEnd == false)
                {
                    Application.LoadLevel(sceneName);
                    isEnd = true;
                    Time.timeScale = 1;

                }
                

            }
        
        }
       
       
    }
}
