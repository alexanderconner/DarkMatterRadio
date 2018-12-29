using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//From this: https://unity3d.com/learn/tutorials/topics/scripting/events-creating-simple-messaging-system 
// And: https://www.youtube.com/watch?v=_nRzoTzeyxU 

    //This Event Class calls StartDeath() when the player falls off the map and hits a trigger that has this attached to it. 

public class resetPlayerOnFallEvent : MonoBehaviour
{

    [Tooltip("Drag the UI element here to fill text on death")] public Text deathDialogueText;
    private AudioSource audioSource;
    [Tooltip("the particle system to activate on respawn")] public ParticleSystem respawnExplosion;
    public float textTime = 5f;

    private UnityAction onFallListener;

    public string onFallListenerName;

    [TextArea(3, 10)]
    public string[] sentences;

    private Vector3 playerStartingPosition;
    private GameObject player;

    private void Awake()
    {
        onFallListener = new UnityAction(StartDeath);
        player = GameObject.FindGameObjectWithTag("Player");
        playerStartingPosition = player.transform.position;
        print("player starting position: " + playerStartingPosition.ToString());
    }

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    void OnEnable()
    {
        EventManager.StartListening(onFallListenerName, onFallListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening(onFallListenerName, onFallListener);
    }

    void StartDeath()
    {
        Debug.Log("Starting Event Respawn: " + onFallListenerName);
        //update GUI here

        StartCoroutine(HandleDeath(sentences));
    }

    IEnumerator HandleDeath(string[] sentences)
    {

        //Reset player Location. 
        player.transform.position = playerStartingPosition;
        if (respawnExplosion != null )
        {
            respawnExplosion.Emit(100);
        }
       

        foreach (string sentence in sentences)
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            deathDialogueText.text = sentence;
            yield return new WaitForSeconds(textTime);
        }

        deathDialogueText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {

        string trigger = other.gameObject.tag;

        Debug.Log("Respawn Collided with trigger: " + trigger);

        EventManager.TriggerEvent(onFallListenerName);

        //OnDisable();
    }

}
