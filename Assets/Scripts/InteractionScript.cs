using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InteractionScript : MonoBehaviour
{
    public GameObject Canvas; //Represents the SoundScript
    public GameObject DialougeBox; //Represents the DialogueBox
    public DialougeScript DialougeScript; //Represents the DialogueScript

    public void AccsesDialogueBox()
    {
        Canvas = GameObject.Find("SoundScript"); //Finds the SoundScript object
        DialougeBox = Canvas.transform.Find("DialougeBox").gameObject; //Find the DialogueBox
        DialougeScript = DialougeBox.GetComponent<DialougeScript>(); //Finds the DialgoueScript
        DialougeBox.SetActive(true); //Set the DialogueBox to active
        DialougeScript.lines.Clear(); //Removes all other lines
        DialougeScript.textComponent.text = string.Empty; //Removes all text from the textBox
    }

    //Interactions
    public void BulettHoles()
    {
        AccsesDialogueBox();
        DialougeScript.lines.Add("There appears to be bulletholes in the wall");
        DialougeScript.ChangeToPerson2();
        DialougeScript.StartDialouge(); //Starts the dialogue
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
