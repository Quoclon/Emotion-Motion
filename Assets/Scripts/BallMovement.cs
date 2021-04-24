using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private float thrust = 4f;
    
    //TODO:
    //Create an automatic velocity kick if still for more than 10 seconds? 

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().velocity = Random.onUnitSphere * thrust;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
