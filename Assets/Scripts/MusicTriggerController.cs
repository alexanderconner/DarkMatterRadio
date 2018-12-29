using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
 *
 * This changes the audio mix or "AudioMixerSnapShot" currently heard 
 * by switch between them using Triggers on entry. Add this to the player controller game object.
 * 
 */
public class MusicController : MonoBehaviour {


    
    public AudioMixerSnapshot startingSnapshot;
    public AudioMixerSnapshot proximitySnapshot1;
    public AudioMixerSnapshot proximitySnapshot2;


    public AudioClip[] audioClips;
    public AudioSource audioSource;
    public float bpm = 108;

    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;


	// Use this for initialization
	void Start () {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote * 4;
        m_TransitionOut = m_QuarterNote * 32;
	}

    void OnTriggerEnter(Collider other)
    {
        /* if (other.CompareTag("TriggerZone1"))
        {
           
            proximitySnapshot1.TransitionTo(m_TransitionIn);
            //PlaySting();
        }  */

        string trigger = other.gameObject.tag;

        Debug.Log ("Collided with trigger: " + trigger);

        switch (trigger)
        {
            case "TriggerZone1":
                proximitySnapshot1.TransitionTo(m_TransitionIn);
                //PlaySting();
                break;
            case "TriggerZone2":
                proximitySnapshot2.TransitionTo(m_TransitionIn);
                //PlaySting();
                break;
        } 
    }

    void OnTriggerExit(Collider other)
    {
        /* if (other.CompareTag("TriggerZone1"))
         {
             startingSnapshot.TransitionTo(m_TransitionOut);
         } */

        switch (other.tag)
        {
            case "TriggerZone1":
                startingSnapshot.TransitionTo(m_TransitionOut);
                //PlaySting();
                break;
            case "TriggerZone2":
                proximitySnapshot1.TransitionTo(m_TransitionOut);
                //PlaySting();
                break;
        }
    }

    void PlaySting()
    {
        int randClip = Random.Range(0, audioClips.Length);
       audioSource.clip = audioClips[randClip];
       audioSource.Play();
    }
}
