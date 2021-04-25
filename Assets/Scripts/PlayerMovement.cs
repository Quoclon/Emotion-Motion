using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    [SerializeField]
    private float innerCircleRadius;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        innerCircleRadius = GameObject.FindGameObjectsWithTag("InnerCircle")[0].transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        //innerCircleRadius = GameObject.FindGameObjectsWithTag("InnerCircle")[0].transform.localScale.x;

    }

    private void FixedUpdate()
    {
        Move();
        //MoveFixed();
        /*
        Vector3 v = newLocation - circleCenter;
        v = Vector3.ClampMagnitude(v, circleRadius);
        newLocation = circleCenter + v;
        */
    }

    void MoveFixed()
    {
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * speed);
 
    } 

    // Move the Player Parent
    void Move()
    {
        transform.Translate(
          Input.GetAxis("Horizontal") * speed * Time.deltaTime,
          Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);

        CheckCircleBounds();
    }

    void CheckCircleBounds()
    {
        float radius = innerCircleRadius; //radius of *black circle*

        Vector3 newLocation = transform.position;
        Vector3 centerPosition = new Vector3(0,0,0); //center of *black circle*

        float distance = Vector3.Distance(newLocation, centerPosition); //distance from ~green object~ to *black circle*

        if (distance > radius) //If the distance is less than the radius, it is already within the circle.
        {
            Vector3 fromOriginToObject = newLocation - centerPosition; //~GreenPosition~ - *BlackCenter*
            fromOriginToObject *= radius / distance; //Multiply by radius //Divide by Distance
            newLocation = centerPosition + fromOriginToObject; //*BlackCenter* + all that Math
            transform.position = newLocation;
        }
    }

    public void ClampMovement()
    {
    
    }
}
