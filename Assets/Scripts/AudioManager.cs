using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float WaitSeconds;

    //AudioSource audioSource;
    public AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        audioSources = Resources.FindObjectsOfTypeAll<AudioSource>();
        StartCoroutine(LoadAudio());    
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadAudio()
    {
        yield return new WaitForSeconds(WaitSeconds);
        playAudio("SoundTrack1");
    }

    public void playAudio(string audioSourceName)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            //Debug.Log("AudioSource in Array of Audiosources: " + audioSource);

            if (audioSource.name == audioSourceName)
            {
                //Debug.Log(audioSourceName);
                audioSource.Play();
                float playTime = audioSource.clip.length;
            }
        }
    }
}
