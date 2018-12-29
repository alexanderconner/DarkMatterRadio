using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//From this: https://unity3d.com/learn/tutorials/topics/scripting/events-creating-simple-messaging-system 
// And: https://www.youtube.com/watch?v=_nRzoTzeyxU 


public class DialogueEvent : MonoBehaviour
{

    public Text dialogueText;
    private AudioSource audioSource;

    public float textTime = 5f; 

    private UnityAction dialogueListener;

    public string dialogueName;

    [TextArea(3, 10)]
    public string[] sentences;

    private void Awake()
    {
        dialogueListener = new UnityAction(StartDialogue);
    }

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        EventManager.StartListening(dialogueName, dialogueListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening(dialogueName, dialogueListener);
    }

    void StartDialogue()
    {
        Debug.Log("Starting dialogue " + dialogueName);
        //update GUI here

        StartCoroutine(ShowSentences(sentences));
    }

    IEnumerator ShowSentences(string[] sentences)
    {
        foreach (string sentence in sentences)
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            dialogueText.text = sentence;
            yield return new WaitForSeconds(textTime);
        }

        dialogueText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {

        string trigger = other.gameObject.tag;

        Debug.Log("Collided with trigger: " + trigger);

        EventManager.TriggerEvent(dialogueName);

        OnDisable();
    }

}
