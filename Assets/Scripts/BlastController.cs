using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastController : MonoBehaviour
{
    public float forceMultiplier = 3000f;
    public float flashOpacity = .50f;
    public float flashTime = 0.05f;

    Color startingColor;
    Color newColor;

    float cooldown = 2f;
    float timer;

   [SerializeField]
    private List<GameObject> AffectedObjects = new List<GameObject>();

    [SerializeField]
    private Vector3 ForceVector;

    // Start is called before the first frame update
    void Start()
    {
        timer = cooldown;
        startingColor = GetComponent<SpriteRenderer>().color;
        newColor = new Color(startingColor.r, startingColor.g, startingColor.b, flashOpacity);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(AffectedObjects.Count);
        
        if (Input.GetMouseButtonDown(0))
        {
            ChangeColor();
            PushObjects();
        }


    }

   
    void FixedUpdate()
    {
       
    }

    private void ChangeColor()
    {
        StartCoroutine(flashPlayer());
        //newColor = GetComponent<SpriteRenderer>().color = new Color(startingColor.r, startingColor.g, startingColor.b, .75f);
    }

    private void PushObjects()
    {
        //Debug.Log(AffectedObjects.Count);
        for (int i = 0; i < AffectedObjects.Count; i++)
        {
            //Debug.Log("Pushed: " + i);
            ForceVector = transform.up;
            AffectedObjects[i].GetComponent<Rigidbody2D>().AddForce(ForceVector * forceMultiplier);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Enter: " + collision.tag);
        if (collision.tag != "Ball")
            return;

        AffectedObjects.Add(collision.gameObject);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Exit: " + collision.tag);
        if (collision.tag != "Ball")
            return;

        AffectedObjects.Remove(collision.gameObject);
    }

    //Flash Player on hit
    IEnumerator flashPlayer()
    {
        gameObject.GetComponent<SpriteRenderer>().color = newColor;
        yield return new WaitForSeconds(flashTime);
        gameObject.GetComponent<SpriteRenderer>().color = startingColor;
    }

}
