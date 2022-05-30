using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    [Header("Dialog")]
    [SerializeField] float typeSpeed;
    [SerializeField] GameObject continueButton;
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] string[] sentences;

    [Header("Help")]
    [SerializeField] bool shouldHelp = true;
    [SerializeField] GameObject helpButton;
    [SerializeField] GameObject dontHelpButton;

    GameManager gameManager;
    
    PlayerMovment playerMovment;
    int index;
    bool hasMeetNPC = false;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        playerMovment = FindObjectOfType<PlayerMovment>();
        continueButton.SetActive(false);
        if (shouldHelp)
        {
            helpButton.SetActive(false);
            dontHelpButton.SetActive(false);
        }

    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !hasMeetNPC)
        {
            StartCoroutine(Type());
            hasMeetNPC = true;
            playerMovment.isTalkingWithNPC = true;
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;

            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else if(shouldHelp)
        {
            textDisplay.text = "";
            playerMovment.isTalkingWithNPC = false;
            helpButton.SetActive(true);
            dontHelpButton.SetActive(true);
        }
        else
        {
            textDisplay.text = "";
            playerMovment.isTalkingWithNPC = false;
        }
    }
    public void HelpCountInc()
    {
        Debug.Log("Help count before: " + gameManager.helpCount);
        gameManager.helpCount++;
        Debug.Log("Help count after: " + gameManager.helpCount); 
    }


}


