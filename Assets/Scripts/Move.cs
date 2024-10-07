using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public bool Type;
    public bool Type1;
    public bool Type2;

    public float Speed = 1;

    private int d = 3; //distance

    private bool IsStart = false;
    private bool IsEnd = false;
    private bool Isok = true;
    private float allTime;
    private int RestrictTime = 5;

    float glowTime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (this.GetComponent<Covid>() == null)
        {
            Isok = true;

        }
        else { Isok = false; }
        Vector2 force;
        if (Type2 == true)
        {
            force = new Vector2(Random.Range(-5000, 5000), Random.Range(-200, -150));
        }
        else
        {
            force = new Vector2(Random.Range(-50, 50), Random.Range(-200, -100));
        }
        this.GetComponent<Rigidbody2D>().AddForce(force);

    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Rigidbody2D>().velocity.y >= -1f && Time.timeScale != 0)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -10f));
        }
        
        //this.transform.Translate(Vector2.down * Time.deltaTime * Speed);
        if (this.transform.position.y <= -8.5f)
        {

            DrawLine.gameObjects.Remove(this.gameObject);

            Destroy(this.gameObject);

        }
       
        //if (this.transform.position.y <= -5.5f)
        //{


        //    if (Type || !Type1)
        //    {
        //        DrowLine.Win = 1;
        //        Time.timeScale = 0;

        //    }


        //}
        int thiscount = 0;

        glowTime += Time.deltaTime;
        //draw lines
        for (int i = 0; i < DrawLine.gameObjects.Count; i++)
        {
            if (DrawLine.gameObjects[i] != this.gameObject)
            {
                if (Vector2.Distance(DrawLine.gameObjects[i].transform.position, this.transform.position) <= d)
                {
                    if (Isok)
                    {
                        if (DrawLine.gameObjects[i].GetComponent<Covid>() != null)
                        {
                            //Debug.Log("ok");
                            IsStart = true;
                        }
                    }
                    //glowing per 0.5s
                    if(glowTime <=  0.25)
                    {
                        this.transform.GetComponent<LineRenderer>().positionCount = 2;
                        this.transform.GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
                        this.transform.GetComponent<LineRenderer>().SetPosition(1, DrawLine.gameObjects[i].transform.position);
                    }
                    else if(glowTime > 0.25 && glowTime <= 0.5 )
                    {
                        this.transform.GetComponent<LineRenderer>().positionCount = 0;
                    }
                    else if(glowTime > 0.5)
                        glowTime = 0;



                    Type = true;
                }
                else
                {
                    thiscount += 1;
                    
                }
            }


        }

        if (Isok)
        {
            
            if (IsStart)
            {
          
                allTime += Time.deltaTime;
                if (allTime >= RestrictTime)
                {
                    Count.InsfectionCount += 1;
                    
                    Isok = false;

                }
                else if (IsEnd)
                {
                   // Debug.Log("no");
                   
                }
                

            }
        }
        

        if (thiscount == DrawLine.gameObjects.Count - 1)
        {
            if (Type)
            {
                Type = false;
                this.transform.GetComponent<LineRenderer>().positionCount = 0;
            }
        }
    }

    private void OnMouseDrag()
    {
        allTime = 0;
        IsStart = false;
        IsEnd = false;
        this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        
    }

    private void OnMouseDown()
    {
        Count.MoveCount += 1;
    }

  

}
