using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStats : MonoBehaviour
{
    [SerializeField]
    public string ballColor;
    public int ballNumber;

    //TODO: Fix  this to use Singleton
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();
        gameManager.AddActiveBall(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        
    }

}
