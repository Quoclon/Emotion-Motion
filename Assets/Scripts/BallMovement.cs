using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float thrust = 3f;
    
    //TODO:
    //Clamp Velocity?

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
