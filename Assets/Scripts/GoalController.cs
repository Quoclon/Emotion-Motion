using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public string color;
    public string audioString = "GoalScored1";

    BallStats ballStats;

    //TODO: Fix  this to use Singleton
    public GameManager gameManager;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();
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
            ballStats = collision.GetComponent<BallStats>();

            if (ballStats.ballColor == this.color)
            {
                audioManager.playAudio(ballStats.ballColor.ToString());
                gameManager.RemoveActiveBall(collision.gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}
