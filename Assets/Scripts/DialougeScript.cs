using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor; //Unnessesary
using UnityEngine;
using UnityEngine.UI;

public class DialougeScript : MonoBehaviour
{
    public List<GameObject> interactableObjects; //List of all objects that you can interact with/that triggers the dialogueBox

    //Visable textbox componets
    public TextMeshProUGUI textComponent; //Represents the text in the dialogueBox

    public List<string> names; //List of all characters names

    public List<string> lines; //Dialouge lines
    public float textSpeed; //The speed of the dialouge text

    private int lineIndex; //Index number of dialogue lines

    //GameObject and TextMesh that represents the NameBox
    public GameObject NameBox;
    public TextMeshProUGUI nameOfSpeaker;

    public ImageScript ImageScript; //GameObject to accses the Portrait script

    public SoundScript SoundScript; //GameObject to accses soundeffects

    public int numberOfPerson; //Int that keeps track of the person you are speaking to

    public Image Portrait; //Represents the portrait object in the dialogueBox


    // Start is called before the first frame update
    void Start()
    {
        print("dialogue script start");
        textSpeed = 0.1f; //Sets the intial waiting time between the typing of each character to 0.1 seconds
        //textComponent.text = string.Empty; //Makes sure that the dialogueBox starts empty
        StartDialouge(); //Plays the StartDialogue method, starting the dialouge when the game starts

        //Set variables that represent other components
        nameOfSpeaker = NameBox.GetComponent<TextMeshProUGUI>(); //Sets nameOfSpeaker to the nameBox

        ImageScript = GameObject.Find("Portrait").gameObject.GetComponent<ImageScript>(); //Sets GameObject ImageScript to Script ImageScript

        SoundScript = GameObject.Find("Canvas").gameObject.GetComponent<SoundScript>(); //Sets GameObject SoundScript to script SoundScript

        //Sets numberOfPerson
        numberOfPerson = 1; //Sets a startvalue for numberOfPerson

        Portrait = ImageScript.gameObject.GetComponent<Image>(); //Sets the portrait object to the Image component on this GameObject


        ChangeToPerson1(); //Sets the number of the initial person speaking to person1
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //If the left mouse button is pressed
        {
            if (textComponent.text == lines[lineIndex]) //If the text in the dialogueBox = the current line
            {
                NextLine(); //Do the NextLine() method, goes to the next line
            }
            else
            {
                StopAllCoroutines(); //Stops all coroutines, in this case the coroutine in question would be TypeLine()
                textComponent.text = lines[lineIndex]; //Makes the text in the dialougeBox = the current line (this way you can skip through dialouge)
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            interactableObjects[0].SetActive(true);
        }
    }
   
    //Dialogue mangement
    public void StartDialouge()
    {
        lineIndex = 0; //Makes the lineIndex 0
        StartCoroutine(TypeLine()); //Starts the TypeLine() method
    }

    void NextLine()
    {
        if (lineIndex < lines.Count -1) //If the lineIndex < the amount of elements in lines -1
        {
            lineIndex++; //Increases the lineIndex int by one
            textComponent.text = string.Empty; //Sets the text in the dialogueBox to empty
            StartCoroutine(TypeLine()); //Starts the TypeLine() method
        }
        else
        {
            gameObject.SetActive(false); //Inactivates the dialogueBox 
            lines.Clear();
        }
    }

    IEnumerator TypeLine()
    {
        VoiceDecider();//Plays voice-sound at the begining of each line

        foreach (char letter in lines[lineIndex].ToCharArray())//Loop that types out every character one by one
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(textSpeed);//Waits for a moment before typing out the next character

            //Checks if the character just typed out is a space. If yes then play voice-sound
            if (char.IsWhiteSpace(letter))
            {
                VoiceDecider();
            }
        }
    }

    //Characters talking and voice decisions
    public void ChangeToPerson1()
    {
        textSpeed = 0.07f; //Decides how fast Person1 speaks
        nameOfSpeaker.text = names[0]; //Changes the NameBox to the right name 
        print(ImageScript.gameObject.name);
        print(ImageScript.portraits[0].name);
        Portrait.sprite = ImageScript.portraits[0]; //Changes the Portrait-box to the right Portrait 
        numberOfPerson = 1; //Changes the number of the person you are speaking to to one
    }

    public void ChangeToPerson2()
    {
        textSpeed = 0.1f; //Decides how fast Person2 speaks
        nameOfSpeaker.text = names[1]; //Changes the NameBox to the right name
        Portrait.sprite = ImageScript.portraits[1]; //Changes the Portrait-box to the right Portrait
        numberOfPerson = 2; //Changes the number of the person you are speaking to to two
    }

    private void VoiceDecider() //Decides which voice to use while speaking
    {
        if (numberOfPerson == 1) //If the number of the person talking = 1/if you´re talking to person 1
        {
            SoundScript.Sound1(); //Play the first sound ´from the SoundScript
        }

        if (numberOfPerson == 2) //If the number of the person talking = 2/if you´re talking to person 2
        {
            SoundScript.Sound2(); //Play the second sound from the SoundScript
        }
    }
}


