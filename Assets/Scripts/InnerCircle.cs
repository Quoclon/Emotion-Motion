using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerCircle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Exited");
        if(collision.tag == "Player")
        {
            Debug.Log("Player Exit");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Entered");
    }
}
