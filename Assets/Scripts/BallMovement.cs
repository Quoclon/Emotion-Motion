using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    private float maxVelocity = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Random 360 Direction
        //GetComponent<Rigidbody2D>().velocity = Random.onUnitSphere * thrust;
    }

    void FixedUpdate()
    {
        //Debug.Log("Pre-Clamp: " + rb.velocity.magnitude);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        //Debug.Log("Post-Clamp: " + rb.velocity.magnitude);
    }

    public void AddForce(float forceAmount)
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * forceAmount, ForceMode2D.Impulse);
    }

    public void ClampVelocity(float magnitude)
    {
        maxVelocity = magnitude;
    }


}
