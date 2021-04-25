using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public string color;

    //TODO: Fix  this to use Singleton
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);
        if (collision.gameObject == null)
            return;

        if (collision.tag == "Ball")
        {
            if (collision.GetComponent<BallStats>().ballColor == this.color)
            {
                //Debug.Log("Hit");
                //Debug.Log(collision.gameObject);
                gameManager.RemoveBall(collision.gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}
