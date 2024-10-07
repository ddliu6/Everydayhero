using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Create : MonoBehaviour
{
    public float DisTime;
    float ThisTime;

    public GameObject[] gameObjects;
    

    float AllTime;
    int total = 40;

    private int curCovidCount = 0;

    public int MyCurCovidCount { get { return curCovidCount; } }

    // Start is called before the first frame update
    void Start()
    {
        ThisTime = 0;

        int num = Random.Range(0, gameObjects.Length);
        if (num == 6 || num == 7)
        {
            Count.curCovidCount += 1;
        }
        GameObject gameObject1 = Instantiate(gameObjects[num]);
        
        gameObject1.transform.position = this.transform.position + new Vector3(Random.Range(-2.0f, 2.0f), 0, 0);
        DrawLine.gameObjects.Add(gameObject1);
        // Debug.Log(gameObjects.Length);
        //Debug.Log(num);
    }

    // Update is called once per frame
    void Update()
    {
       
        AllTime += Time.deltaTime;
        if (AllTime >= total)
        {
            if (DrawLine.gameObjects.Count == 0)
            {
                //DrowLine.Win = 2;
                //Time.timeScale = 0;
                
            }
            return;
        }
        ThisTime += Time.deltaTime;
        if (ThisTime >= DisTime)
        {
            ThisTime = 0;
            if (Random.Range(0, 10) >= 5)
            {
                int num = Random.Range(0, gameObjects.Length);
                if (num == 6 || num == 7)
                {
                    Count.curCovidCount += 1;


                }

                GameObject gameObject1 = Instantiate(gameObjects[num]);
                gameObject1.transform.position = this.transform.position + new Vector3(Random.Range(-2.0f, 2.0f), 0, 0);
                DrawLine.gameObjects.Add(gameObject1);
            }
        }
        
    }

    
}
