using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsScreenController : MonoBehaviour
{
    public float WaitSeconds;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Flash Player on hit
    IEnumerator LoadScene()
    {
        Debug.Log("Ran");
        yield return new WaitForSeconds(WaitSeconds);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSplashScreen()
    {
        SceneManager.LoadScene(0);
    }
}
