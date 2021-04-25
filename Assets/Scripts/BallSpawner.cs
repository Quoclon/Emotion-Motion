using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpawnType
{ Timer, Burst, Single};

public class BallSpawner : MonoBehaviour
{
    public GameObject[] balls;
    private GameObject ball;

    [Header("SpawnType")]
    public SpawnType spawnType;

    [Header("Spawn Variables")]
    public Transform spawnPoint;
    public int ballsThisLevel = 4;
    public float spawnRate = 2.5f;
    private float nextSpawn = 0f;
    private float timer = 0f;

    [Header("Ball Variables")]
    public float ballMagnitudeMax = 6f;
    public float ballForce = 25f;
    private int ballType;
    
    // Start is called before the first frame update
    void Start()
    {
        if (spawnType == SpawnType.Single)
            SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnType == SpawnType.Timer)
            TimedSpawn();
    }

    //TODO: Improve Timer
    void TimedSpawn()
    {
        timer = Time.time;
        if (Time.time > nextSpawn)
        {
            SpawnBall();
            nextSpawn = Time.time + spawnRate;
        }
    }

    //TODO: Tidy up this function
    public void SpawnBall()
    {
        //Select a Random Ball to Spawn
        int rand = Random.Range(0, balls.Length);
        ball = balls[rand];

        //Determine Spawn Position
        Vector3 spawnPosition = transform.position;
        if (spawnType == SpawnType.Burst)
            spawnPosition = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);

        if (spawnType != SpawnType.Burst)
            spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y, 0);

        //Determine into Centre of Circle
        float lookAngle;
        Vector2 lookDirection;
        Quaternion fireAngle;

        lookDirection = new Vector3(0,0,0) - spawnPosition;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        fireAngle = spawnPoint.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        //Debug.Log(Quaternion.Euler(0f, 0f, lookAngle - 90f));

        //Fire Toward Centre of Circle
        GameObject newBall = Instantiate(ball, spawnPosition, fireAngle);
        newBall.GetComponent<BallMovement>().AddForce(ballForce);
        newBall.GetComponent<BallMovement>().ClampVelocity(ballMagnitudeMax);
    }
}
