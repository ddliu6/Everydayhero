using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject gamePause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPause()
    {
        Time.timeScale = 0;
        gamePause.SetActive(true);
    }

    public void OnResume()
    {
        Time.timeScale = 1;
        gamePause.SetActive(false);
    }

}
