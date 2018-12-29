using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    //private AudioSource[] allAudio;
    public AudioSource backgroundAudioSource;

    private void Awake()
    {
       // DontDestroyOnLoad(gameObject);
       // allAudio = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];
    }

    public void LoadNextLevel()
    {
        //StopAllAudio();
        //Let Timeline handle new audio
        AudioSource[] audioFXarray = GetComponents<AudioSource>();

        //Play all FX clips
        foreach (AudioSource audioFX in audioFXarray)
        {
            audioFX.Play();
        }

        //Get length of time left on currently playing audioclip and wait for it to finish then load the level.
        float timeLeftinClip = backgroundAudioSource.clip.length - backgroundAudioSource.time;
        print("time left in audio: " + timeLeftinClip);
        StartCoroutine(WaitForAudiotoFinish(timeLeftinClip)); 

    }

    /*// Use this for initialization
    void Start () {
        Invoke("LoadFirstScene", 2f);
	}
	
	
	void LoadFirstScene () {
        SceneManager.LoadScene(1);
	} */

    void StopAllAudio(AudioSource[] allAudio)
    {
        foreach (AudioSource audioS in allAudio)
        {
            audioS.Stop();
        }
    }

    private IEnumerator WaitForAudiotoFinish(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    void OnTriggerEnter(Collider other)
    {

        string trigger = other.gameObject.tag;

        Debug.Log("Level Collider Collided with trigger: " + trigger);

        if (trigger == "Player")
        {
            print("Loading Next Level");
            LoadNextLevel();
        }
    

    }
}
