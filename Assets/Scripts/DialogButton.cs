using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class DialogButton : MonoBehaviour
{
    public Flowchart flowchart;
    List<string> logTexts = new List<string>(); //log list
    int nextIndex; //next index to log
    string lastBlock = ""; //last recorded block

    public void autoPlay()
    {
        var says = flowchart.GetComponent<Block>().GetComponents<Say>();

        for (int i = 0; i < says.Length; ++i)
        {
            //Cancel all WaitforClick(s) except the Skip button
            if (says[i].ItemId != 34)
                says[i].cancelWaitforClick();
        }
        //start autoplay
        flowchart.SelectedBlock.ActiveCommand.Continue();
    }

    public void Stop()
    {
        var says = flowchart.GetComponent<Block>().GetComponents<Say>();

        for (int i = 0; i < says.Length; ++i)
        {
            //Click all WaitforClick(s)
           says[i].clickWaitforClick();
        }
        //stop autoplay
        flowchart.SelectedBlock.ActiveCommand.OnStopExecuting();
    }

    public void Log()
    {
        var block = flowchart.SelectedBlock; //current block
        var comands = block.CommandList; //current command list
        int Index = block.ActiveCommand.CommandIndex; //current Index
        
        //Once jump into a new block, reset the index
        if (block.BlockName != lastBlock)
        {
            nextIndex = 0;
            lastBlock = block.BlockName;
        }

        //Record the log
        for (int i = nextIndex; i <= Index; ++i)
        {
            //Check command type & cancel all WaitforClick(s) except the Skip button
            if (comands[i].GetType().ToString() == "Fungus.Say" && comands[i].ItemId != 34)
                logTexts.Add(comands[i].GetSummary());
         }
        nextIndex = Index + 1;

        Debug.Log("Block: " + lastBlock);
        Debug.Log("curIndex: " + Index);

        //Show the log
        for (int i = 0; i < logTexts.Count; ++i)
            Debug.Log(logTexts[i]);
    }
}
