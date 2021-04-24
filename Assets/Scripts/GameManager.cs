using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> BallList = new List<GameObject>();

    //UI Interactions
    public TextMeshProUGUI textGreenCount;
    public TextMeshProUGUI textBlueCount;
    public TextMeshProUGUI textRedCount;
    public TextMeshProUGUI textYellowCount;


    //Ball Counters
    int greenCount = 0;
    int blueCount = 0;
    int redCount = 0;
    int yellowCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        ResetBallCount();
    }

    // Update is called once per frame
    void Update()
    {
        UI_DisplayBallCounts();

        if (Input.GetKey(KeyCode.R))
        ReloadLevel();
    }

    void UI_DisplayBallCounts()
    {
        textGreenCount.text = greenCount.ToString();
        textBlueCount.text = blueCount.ToString();
        textRedCount.text = redCount.ToString();
        textYellowCount.text = yellowCount.ToString();
    }

    public void AddBall(GameObject ball)
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
        BallList.Add(ball);
    }

    public void RemoveBall(GameObject ball)
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
        BallList.Remove(ball);
        Destroy(ball);
    }


    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AdjustBallCount()
    {

    }

    public void ResetBallCount()
    {
         greenCount = 0;
         blueCount = 0;
         redCount = 0;
         yellowCount = 0;
    }
}
