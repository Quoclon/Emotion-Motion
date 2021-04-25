using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpawnType
{ Timer, Burst, Single};

public class BallSpawner : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject[] spawnableBalls;
    private GameObject ballToSpawn;

    [Header("SpawnType")]
    public SpawnType spawnType;

    [Header("Spawn Variables")]
    public Transform spawnPoint;
    public int ballsThisLevel = 6;
    public float spawnRate = 2.5f;
    private float nextSpawn = 0f;
    private float timer = 0f;

    [Header("Ball Variables")]
    public float ballMagnitudeMax = 6f;
    public float ballForce = 25f;
    private int ballType;

    [SerializeField]
    private List<GameObject> nextBalls = new List<GameObject>();

    [SerializeField]
    private List<GameObject> ballHopper = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();

        if (spawnType == SpawnType.Single)
            SpawnBall();

        if (spawnType == SpawnType.Timer)
            CreateBallHopper();
    }

    // Update is called once per frame
    void Update()
    {
        CheckNextBalls();

        if (spawnType == SpawnType.Timer)
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

        if (ballHopper.Count <= 0)
            return;

        ballToSpawn = ballHopper[0];
        ballHopper.Remove(ballHopper[0]);

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

        //Fire Toward Centre of Circle
        GameObject newBall = Instantiate(ballToSpawn, spawnPosition, fireAngle);
        newBall.GetComponent<BallMovement>().AddForce(ballForce);
        newBall.GetComponent<BallMovement>().ClampVelocity(ballMagnitudeMax);
    }

    void CreateBallHopper()
    {
        for (int i = 0; i < ballsThisLevel; i++)
        {
            AddBall();
            //gameManager.AddBallToTotal(ballHopper[i]);
        }

        gameManager.CreateTotalBallList(ballHopper);
    }

    void AddBall()
    {
        //Select a Random Ball to Spawn
        int rand = Random.Range(0, spawnableBalls.Length);
        ballToSpawn = spawnableBalls[rand];
        ballHopper.Add(ballToSpawn);
        //gameManager.AddBallToTotal(ballToSpawn);
    }

    void CheckNextBalls()
    {
        //Debug.Log(nextBalls.Count);
        for (int i = nextBalls.Count-1; i >= 0; i--)
        {
            if(ballHopper.Count > i)
            {
                nextBalls[i].GetComponent<SpriteRenderer>().color = ballHopper[i].GetComponent<SpriteRenderer>().color;
                continue;
            }
            nextBalls[i].GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
