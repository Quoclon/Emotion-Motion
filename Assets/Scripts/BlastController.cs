using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> AffectedObjects;
    public Vector3 ForceVector;

    void OnTriggerEnter2D(Collider2D collision)
    {
        AffectedObjects.Add(collision.gameObject);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        AffectedObjects.Remove(collision.gameObject);
    }

    void FixedUpdate()
    {
        Debug.Log(AffectedObjects.Count);
        if (Input.GetMouseButton(0))
            PushObjects();  
    }

    private void PushObjects()
    {
        for (int I = 0; I < AffectedObjects.Count; I++)
        {
            AffectedObjects[I].GetComponent<Rigidbody2D>().AddForce(ForceVector);
        }
    }
}
