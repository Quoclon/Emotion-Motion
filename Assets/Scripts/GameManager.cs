using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioManager audioManager;

    [SerializeField]
    private List<GameObject> ActiveBallList = new List<GameObject>();
    public GameObject player;
    public GameObject spawner;

    public GameObject levelOverGO;


    //UI Interactions
    public TextMeshProUGUI textLevelOver;
    public TextMeshProUGUI textTimeCounter;
    public TextMeshProUGUI textTotalTimeTaken;

    public TextMeshProUGUI textGreenCount;
    public TextMeshProUGUI textBlueCount;
    public TextMeshProUGUI textRedCount;
    public TextMeshProUGUI textYellowCount;

    //Time Counter
    public float timeLimit = 90f;
    float timeCounter = 0;
    public float timeIntervals = 10f;

    //Level Status
    public bool levelActive = false;
    public bool won = true;
    public bool lost = true;

    //Ball Counter
    int totalBallsThisLevel = 0;
    int totalBallsSpawned = 0;
    int totalBallsScored = 0;

    //Ball Color Counters
    int greenCount = 0;
    int blueCount = 0;
    int redCount = 0;
    int yellowCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        levelActive = true;
        ResetActiveBallCount();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
            ReloadLevel();

        if (levelActive)
        {
            UpdateTime();
            UpdateUI();
        }

    }

    public void ReloadLevel()
    {
        levelActive = true;
        ResetActiveBallCount();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReloadGame()
    {
        levelActive = true;
        ResetActiveBallCount();
        SceneManager.LoadScene(0);
    }
    void UpdateTime()
    {
        timeCounter += Time.deltaTime * timeIntervals;
        CheckLoseCondition();
    }

    void UpdateUI()
    {
        textTimeCounter.text = timeCounter.ToString("F1");
        textGreenCount.text = greenCount.ToString();
        textBlueCount.text = blueCount.ToString();
        textRedCount.text = redCount.ToString();
        textYellowCount.text = yellowCount.ToString();
    }

    public void AddActiveBall(GameObject ball)
    {
        string ballColor = ball.GetComponent<BallStats>().ballColor;

        switch (ballColor)
        {
            case "Green":
                greenCount++;
                break;
            case "Blue":
                blueCount++;
                break;
            case "Red":
                redCount++;
                break;
            case "Yellow":
                yellowCount++;
                break;
            default:
                break;
        }

        //Add Ball to Ball List
        ActiveBallList.Add(ball);
        totalBallsSpawned++;
        //Debug.Log("totalBallsSpawned: " + totalBallsSpawned);
    }

    public void RemoveActiveBall(GameObject ball)
    {
        string ballColor = ball.GetComponent<BallStats>().ballColor;

        switch (ballColor)
        {
            case "Green":
                greenCount--;
                break;
            case "Blue":
                blueCount--;
                break;
            case "Red":
                redCount--;
                break;
            case "Yellow":
                yellowCount--;
                break;
            default:
                break;
        }

        //Remove Ball from Ball List
        ActiveBallList.Remove(ball);
        //Destroy(ball);

        totalBallsScored++;
        //Debug.Log("totalBallsScrored: " + totalBallsScored);
    
        //Check to See if Last Ball Scored
        CheckWinCondition();
    }


    public void CreateTotalBallList(List<GameObject> ballHopper)
    {
        totalBallsThisLevel = ballHopper.Count;
        //Debug.Log("totalBallsThisLevel " + totalBallsThisLevel);
    }


    // WIN Conditin & Reset Functions
    void CheckWinCondition()
    {
        if (totalBallsThisLevel - totalBallsScored == 0)
        {
            textLevelOver.text = "You Win!";
            audioManager.playAudio("Win");
            ToggleSceneOver();
        }
    }


    // WIN Conditin & Reset Functions
    void CheckLoseCondition()
    {
        if (timeCounter >= timeLimit)
        {
            timeCounter = timeLimit;
            audioManager.playAudio("Lose");
            textLevelOver.text = "You Lose!";
            ToggleSceneOver();
        }
    }

    void ToggleSceneOver()
    {
        levelActive = false;
        textTotalTimeTaken.text = timeCounter.ToString("F1");
        ToggleLevelOverCanvas();
        DisablePlayer();
        DisableSpawner();
        DisableBalls();
        //PauseGame();
        //ResetActiveBallCount();
    }

    void ToggleLevelOverCanvas()
    {
        if (!levelOverGO.activeSelf)
        {
            levelOverGO.SetActive(true);
            return;
        }

        if (levelOverGO.activeSelf)
            levelOverGO.SetActive(false);
    }

    void DisablePlayer()
    {
        player.SetActive(false);
    }


    void DisableBalls()
    {
        for (int i = 0; i < ActiveBallList.Count; i++)
        {
            ActiveBallList[i].SetActive(false);
        }
    }

    void DisableSpawner()
    {
        spawner.SetActive(false);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ResetActiveBallCount()
    {
        greenCount = 0;
        blueCount = 0;
        redCount = 0;
        yellowCount = 0;

        totalBallsThisLevel = 0;
        totalBallsScored = 0;
        totalBallsSpawned = 0;

        levelActive = true;
    }

}
