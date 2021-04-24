using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject[] balls;
    private GameObject ball;

    public float spawnRate = 2.5f;
    public float nextSpawn = 0f;
    public float timer = 0f;

    public int ballType;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(balls.Length);
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;

        if (Time.time > nextSpawn)
        {
            SpawnBall();
            nextSpawn = Time.time + spawnRate;
        }
    }

    public void SpawnBall()
    {
        ball = balls[Random.Range(0, balls.Length-1)];
        Instantiate(ball, transform.position, Quaternion.identity);
    }

}
