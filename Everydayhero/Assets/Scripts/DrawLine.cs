using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DrawLine : MonoBehaviour
{
    public static List<GameObject> gameObjects = new List<GameObject>();

    public static int Win;

    public GameObject pre;
    bool isStart = false;
    //public GameObject[] gameObjects1;


    void Start()
    {
        Win = 0;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && isStart == false)
        {
            pre.SetActive(false);
            isStart = true;
            Time.timeScale = 1;

        }
        //if (Win == 1)
        //{
        //    gameObjects1[0].SetActive(true);
        //}
        //if (Win == 2)
        //{
        //    gameObjects1[1].SetActive(true);
        //}
    }

    //public void ZaiLai()
    //{
    //    SceneManager.LoadScene(0);
    //    gameObjects.Clear();
    //}
    //public void TuiChu()
    //{
    //    Application.Quit();
    //}
}
