using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject canvas; //Represents the canvas
    public GameObject DialougeBox; //Represents the DialogueBox
    public DialougeScript dialougeScript; //Represents the DialogueScript

    public void accsesDialogueBox()
    {
        canvas = GameObject.Find("Canvas"); //Finds the Canvas object
        DialougeBox = canvas.transform.Find("DialougeBox").gameObject; //Find the DialogueBox
        dialougeScript = DialougeBox.GetComponent<DialougeScript>(); //Finds the DialgoueScript
        DialougeBox.SetActive(true); //Set the DialogueBox to active
        dialougeScript.lines.Clear(); //Removes all other lines
        dialougeScript.textComponent.text = string.Empty; //Removes all text from the textBox
    }

    //Interactions
    public void bulettHoles()
    {
        accsesDialogueBox();
        dialougeScript.lines.Add("There appears to be bulletholes in the wall");
        dialougeScript.ChangeToPerson2();
        dialougeScript.StartDialouge(); //Starts the dialogue
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
