using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastController : MonoBehaviour
{
    public float forceMultiplier = 100f;

    [SerializeField]
    private List<GameObject> AffectedObjects = new List<GameObject>();

    [SerializeField]
    private Vector3 ForceVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(AffectedObjects.Count);
        if (Input.GetMouseButtonDown(0))
            PushObjects();
    }

    void FixedUpdate()
    {
       
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


}
