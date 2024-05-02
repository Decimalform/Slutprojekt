using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialougeScript : MonoBehaviour
{
    public List<GameObject> interactableObjects; //List of all objects that you can interact with/that triggers the dialogueBox

    //Visable textbox componets
    public TextMeshProUGUI textComponent;

    public List<string> names; //List of all characters names

    public List<string> lines; //Dialouge lines
    public float textSpeed; //The speed of the dialouge text

    private int lineIndex; //Index number of dialogue lines

    //GameObject and TextMesh that represents the nameBox
    public GameObject nameBox;
    public TextMeshProUGUI nameOfSpeaker;

    public ImageScript imageScript; //GameObject to accses the portrait script

    public SoundScript Canvas; //GameObject to accses soundeffects

    public int numberOfPerson; //GameObject that stores the number of the person you are speaking to



    // Start is called before the first frame update
    void Start()
    {
        textSpeed = 0.1f;
        textComponent.text = string.Empty;
        StartDialouge();

        //Set variables that represent other components
        nameOfSpeaker = nameBox.GetComponent<TextMeshProUGUI>();

        imageScript = GameObject.Find("Portrait").GetComponent<ImageScript>();

        Canvas = GameObject.Find("Canvas").GetComponent<SoundScript>();

        //Sets numberOfPerson
        numberOfPerson = 1; //Sets a startvalue for numberOfPerson

        ChangeToPerson1(); //Sets the number of the initial person speaking to person1
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[lineIndex])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[lineIndex];
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
        lineIndex = 0;
        print(lines[lineIndex]);
        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (lineIndex < lines.Count -1)
        {
            lineIndex++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            lines.Clear();
        }
    }

    IEnumerator TypeLine()
    {
        voiceDecider();//Plays voice-sound at the begining of each line

        foreach (char c in lines[lineIndex].ToCharArray())//Loop that types out every character one by one
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);//Waits for a moment before typing out the next character

            //Checks if the character just typed out is a space. If yes then play voice-sound
            if (char.IsWhiteSpace(c))
            {
                Debug.Log("The character is a space.");
                voiceDecider();
            }
        }
    }

    //Characters talking and voice decisions
    public void ChangeToPerson1()
    {
        textSpeed = 0.07f; //Decides how fast Person1 speaks
        nameOfSpeaker.text = names[0]; //Changes the nameBox to the right name 
        imageScript.portrait.sprite = imageScript.portraits[0]; //Changes the portrait-box to the right portrait
        numberOfPerson = 1; //Changes the number of the person you are speaking to to one
    }

    public void ChangeToPerson2()
    {
        textSpeed = 0.1f; //Decides how fast Person2 speaks
        nameOfSpeaker.text = names[1]; //Changes the nameBox to the right name
        imageScript.portrait.sprite = imageScript.portraits[1]; //Changes the portrait-box to the right portrait
        numberOfPerson = 2; //Changes the number of the person you are speaking to to two
    }

    private void voiceDecider() //Decides which voice to use while speaking
    {
        if (numberOfPerson == 1)
        {
            Canvas.Sound1();
        }

        if (numberOfPerson == 2)
        {
            Canvas.Sound2();
        }
    }
}


