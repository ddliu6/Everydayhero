using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    public static int curCovidCount;
    public static int MoveCount;
    public static int MaskCount;
    public static int InsfectionCount;

    public static Count instance { get; private set; }
    public Text MoveText;
    public Text MaskText;
    public Text CovidText;
    public Text InfectionText;
    public Text timer;

    float timeLeft = 30f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft- Time.deltaTime > 0f)
        {
            timeLeft -= Time.deltaTime;
            timer.text = "Time: " + Mathf.Round(timeLeft).ToString() + " s";
        }
        else
            timeLeft = 0;

        //Debug.Log(MaskCount);
        //Debug.Log(InsfectionCount);
    }

    public float showTimeLeft()
    {
        return timeLeft;
    }

    public void FinalMove()
    {
        MoveText.text = MoveCount.ToString();
    }

    public void FinalMask()
    {
        MaskText.text = MaskCount.ToString();
    }

    public void FinalCovid()
    {
        CovidText.text = curCovidCount.ToString();
    }

    public void FinalInfection()
    {
        InfectionText.text = InsfectionCount.ToString();
    }
    //public void ChangeCovidCount()
    //{
    //    curCovidCount = curCovidCount + 1;
    //    Debug.Log(curCovidCount);
    //}
}
