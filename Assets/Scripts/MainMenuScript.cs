using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public List<string> suspects;
    public GameObject AccuseButton;
    public int murderersIndex;
    public int indexOfLastPersonClicked;

    public GameObject DialougeBox; //Represents the DialogueBox
    public DialougeScript DialougeScript; //Represents the DialogueScript
    public GameObject SoundScript; //Represents the SoundScript

    public void AccsesDialogueBox()
    {
        SoundScript = GameObject.Find("SoundScript"); //Finds the SoundScript object
        //DialougeBox = SoundScript.transform.Find("DialougeBox").gameObject; //Find the DialogueBox
        DialougeScript = DialougeBox.GetComponent<DialougeScript>(); //Finds the DialgoueScript
        DialougeBox.SetActive(true); //Set the DialogueBox to active
        DialougeScript.lines.Clear(); //Removes all other lines
        DialougeScript.textComponent.text = string.Empty; //Removes all text from the textBox
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        //Main Menu
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        //Intro Scene
    }

    public void GoToInvestigation()
    {
        SceneManager.LoadScene(7);
        //Goes to investigation
    }

    public void GoToSuspects()
    {
        SceneManager.LoadScene(6);
        //Goes to suspects
    }

    public void GoToSurroundings()
    {
        SceneManager.LoadScene(4);
        //Goes to surroundings
    }

    public void GoToVictim()
    {
        SceneManager.LoadScene(5);
        //Goes to the victim
    }

    public void QuitGame()
    {
        Application.Quit();
        //Quits Game
    }

    public void Accuseation()
    {
        if(indexOfLastPersonClicked == murderersIndex)
        {
            print("You winn!");
        }
        else
        {
            print("You lose!");
        }
    }

    //Characters
    public void MissScarlett()
    {
        if (!DialougeBox.activeSelf)
        {
            AccsesDialogueBox();
            indexOfLastPersonClicked = 0;
            print(indexOfLastPersonClicked);
            AccuseButton.SetActive(true);

            DialougeScript.lines.Add("Miss Scarlett, full name Vivienne Scarlet. A young blonde woman.");
            DialougeScript.lines.Add("She큦 29 years, 165 cm tall and has the European shoe size: 38.");
            DialougeScript.StartDialouge(); //Starts the dialogue
        }
    }

    public void ColonelMustard()
    {
        if (!DialougeBox.activeSelf)
        {
            AccsesDialogueBox();
            indexOfLastPersonClicked = 1;
            print(indexOfLastPersonClicked);
            AccuseButton.SetActive(true);

            DialougeScript.lines.Add("Colonel Mustard, full name Algernon Mustard. An older man and a stock military officer.");
            DialougeScript.lines.Add("He큦 52 years old, 183 cm tall and has the European shoe size: 43.");
            DialougeScript.StartDialouge(); //Starts the dialogue
        }
    }

    public void MrGreen()
    {
        if (!DialougeBox.activeSelf)
        {
            AccsesDialogueBox();
            indexOfLastPersonClicked = 2;
            print(indexOfLastPersonClicked);
            AccuseButton.SetActive(true);

            DialougeScript.lines.Add("Mr. Green, full name Jonathan Green.");
            DialougeScript.lines.Add("He큦 38 years old, 178 cm and has the European shoe size: 41.");
            DialougeScript.StartDialouge(); //Starts the dialogue
        }
    }

    public void MrsPeackock()
    {
        if (!DialougeBox.activeSelf)
        {
            AccsesDialogueBox();
            indexOfLastPersonClicked = 3;
            print(indexOfLastPersonClicked);
            AccuseButton.SetActive(true);

            DialougeScript.lines.Add("Mrs.Peacock, full name Patricia Peacock.");
            DialougeScript.lines.Add("She큦 55 years old, 168 cm tall and has the European shoe size: 39.");
            DialougeScript.StartDialouge(); //Starts the dialogue
        }
    }

    public void ProfessorPlum()
    {
        if (!DialougeBox.activeSelf)
        {
            AccsesDialogueBox();
            indexOfLastPersonClicked = 4;
            print(indexOfLastPersonClicked);
            AccuseButton.SetActive(true);

            DialougeScript.lines.Add("Professor Plum, full name Edgar Plum.");
            DialougeScript.lines.Add("He큦 43 years old, 173 cm tall and has the European shoe size: 40.");
            DialougeScript.StartDialouge(); //Starts the dialogue
        }
    }

    public void DoctorOrchid()
    {
        if (!DialougeBox.activeSelf)
        {
            AccsesDialogueBox();
            indexOfLastPersonClicked = 5;
            print(indexOfLastPersonClicked);
            AccuseButton.SetActive(true);

            DialougeScript.lines.Add("Doctor Orchid, full name Diana Orchid. A young woman of East Asian descent, wearing a black blouse with a pink skirt.");
            DialougeScript.lines.Add("She큦 30 years old, 162 cm tall and has the European shoe size: 37.");
            DialougeScript.lines.Add("Dr. Orchid is the adopted daughter of Mr. Boddy, whom he took in when she was a teenager.");
            DialougeScript.StartDialouge(); //Starts the dialogue
        }
    }

    public void Start()
    {
        DialougeScript = DialougeBox.GetComponent<DialougeScript>(); //Finds the DialgoueScript

        suspects.Add("Miss Scarlett");//index: 0
        suspects.Add("Colonel Mustard");//index: 1
        suspects.Add("Mr. Green");//index: 2
        suspects.Add("Mrs. Peacock");//index: 3
        suspects.Add("Professor Plum");//index: 4
        suspects.Add("Doctor Orchid");//index: 5

        murderersIndex = 4;
    }
}

