using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public AudioClip audioGrab;
    public AudioClip audioPut;

    Vector2 vector21;

    
    // Start is called before the first frame update
    void Start()
    {
        vector21 = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(audioGrab, vector21);
        
    }

    private void OnMouseDrag()
    {
        
        this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }
    private void OnMouseUp()
    {

        for (int i = 0; i < DrawLine.gameObjects.Count; i++)
        {

            if (Vector2.Distance(DrawLine.gameObjects[i].transform.position, this.transform.position) <= 1.5)
            {
                AudioSource.PlayClipAtPoint(audioPut, DrawLine.gameObjects[i].transform.position);
                DrawLine.gameObjects[i].transform.GetComponent<Move>().Type1 = true;
                DrawLine.gameObjects[i].transform.GetComponent<Animator>().SetBool("State", true);

                Count.MaskCount += 1;

            }




        }
        this.transform.position = vector21;
    }
}
