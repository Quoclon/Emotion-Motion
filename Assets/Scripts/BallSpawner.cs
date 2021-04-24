using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpawnType
{ Burst, Timer};

public class BallSpawner : MonoBehaviour
{
    public GameObject[] balls;
    private GameObject ball;

    private int ballType;

    [SerializeField]
    public SpawnType spawnType;
    //public SpawnType spawnType = SpawnType.Timer;

    public int startingBalls = 8;

    public float spawnRate = 2.5f;
    private float nextSpawn = 0f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if(spawnType == SpawnType.Burst)
             BurstSpawn();

        Debug.Log(balls.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnType == SpawnType.Timer)
            TimedSpawn();

    }


    void TimedSpawn()
    {
        timer = Time.time;

        if (Time.time > nextSpawn)
        {
            SpawnBall();
            nextSpawn = Time.time + spawnRate;
        }
    }


    void BurstSpawn()
    {
        for (int i = 0; i < startingBalls; i++)
        {
            SpawnBall();
        }
    }


    public void SpawnBall()
    {
        int rand = Random.Range(0, balls.Length);
        //Debug.Log(rand + " " + balls[rand]);
        ball = balls[rand];

        Vector3 spawnPosition = transform.position;
        if (spawnType == SpawnType.Burst)
            spawnPosition = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);

        Instantiate(ball, spawnPosition, Quaternion.identity);
    }

}
