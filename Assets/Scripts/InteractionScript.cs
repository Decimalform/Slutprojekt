using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InteractionScript : MonoBehaviour
{
    public GameObject SoundScript; //Represents the SoundScript
    public GameObject DialougeBox; //Represents the DialogueBox
    public DialougeScript DialougeScript; //Represents the DialogueScript
    public bool switchToNonSelf; //Bool that is activated only when Kate is speaking (and it큦 not in the begining)

    // Start is called before the first frame update
    void Start()
    {
        switchToNonSelf = false;
    }
    public void AccsesDialogueBox()
    {
        SoundScript = GameObject.Find("SoundScript"); //Finds the SoundScript object
        //DialougeBox = SoundScript.transform.Find("DialougeBox").gameObject; //Find the DialogueBox
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
    void OnMouseDown()
    {
        // Add the behavior for when the object is clicked here
        if (!DialougeBox.activeSelf)
        {

            Debug.Log("Object clicked!");
            AccsesDialogueBox();

            //Furniture
            //Tags
            if (gameObject.tag == "Sofa")
            {
                print(gameObject.name);
                DialougeScript.lines.Add("Just a regular red sofa.");
            }

            if (gameObject.tag == "CupboardDoor")
            {
                print(gameObject.name);
                DialougeScript.lines.Add("The doors to the cupboard under the sink.");
            }

            //names
            if (gameObject.name == "Table")
            {
                print(gameObject.name);
                DialougeScript.lines.Add("A coffetable made out of dark wood.");
            }

            if (gameObject.name == "SinkPlace")
            {
                print(gameObject.name);
                DialougeScript.lines.Add("A simple sink. Before his death Mr. Body reported it brooken, however it seems to be working properly now.");
            }

            if (gameObject.name == "Sink")
            {
                print(gameObject.name);
                DialougeScript.lines.Add("The tap part of the sink. Supposedly this part of the sink was reported brooken by Mr. Body before his death.");
                DialougeScript.lines.Add("But it seems to be working fine now.");
            }

            //objects
            if (gameObject.name == "Wrench")
            {
                print(gameObject.name);
                DialougeScript.lines.Add("A wrench. It큦 probably about 40 cm long and around 2 cm thick. Most likely Mr. Body intended for this to be used to mend the sink.");
                DialougeScript.lines.Add("It has several diffirent finger prints that we belive could belong to any of the following: Mrs. Peacock, Professor Plum and or Colonel Mustard.");
            }

            if (gameObject.name == "MetalPipe")
            {
                print(gameObject.name);
                DialougeScript.lines.Add("A metal pipe. It큦 around 45 cm long and has a diameter of about 4 cm. Most likely Mr. Body intended for this to be used to mend the sink.");
                DialougeScript.lines.Add("It has several diffirent finger prints that we belive could belong to any of the following: Doctor Orchid, Mrs. Peacock and or Professor Plum.");
            }

            if (gameObject.name == "Candlestick")
            {
                print(gameObject.name);
                DialougeScript.lines.Add("A simple candlestick. It큦 approxinately 35 cm long and has an avrage diameter of about 6 cm, apart from in the bottom. Very decorative but not much else.");
                DialougeScript.lines.Add("It has several diffirent finger prints that we belive could belong to any of the following: Colonel Mustard, Miss Scarlett and Mr. Green.");
            }

            if (gameObject.name == "BrokenTeaCup")
            {
                print(gameObject.name);
                DialougeScript.lines.Add("A broken tea cup. It큦 shattered into a million pices. From the stains left around it one would guess it was filled to the brim before it broke");
            }

            if (gameObject.name == "CoffeStain")
            {
                print(gameObject.name);
                DialougeScript.lines.Add("A large coffe stain. Most likely caused by the now broken tea cup.");
                DialougeScript.lines.Add("Don큧 cry over spilled milk they said, they never mentioned coffe.");
            }

            if (gameObject.name == "Footprint")
            {
                print(gameObject.name);
                DialougeScript.lines.Add("A coffe stain in the shape of a footprint. It seems to be somewhere between a european size 40 and 43.");
            }

            //corpse
            if (gameObject.name == "CorpseCover")
            {
                print(gameObject.name);
                DialougeScript.lines.Add("The victim, the late Mr. Body became 51 years old. He큦 187 cm tall.");
                DialougeScript.lines.Add("The victim, Mr. Body seems to have been killed here in the basement. There are no signs of the body having been moved.");
                DialougeScript.lines.Add("The cause of death seems to be bludgeoning. From the size and depth of the wound we estimate that the murder weapon was likely around 35-45 cm long and about 4 cm thick.");
                DialougeScript.lines.Add("We have confirmed that none of the suspects left the property in between the time of the body discovery and police arriving on scene.");
                DialougeScript.lines.Add("Therefore we find it very likely that the murder weapon is still on the property.");
                DialougeScript.lines.Add("Also worth noting is that the victim has large coffe stains on and around his body as well as what seems to be shards and dust from the broken tea cup.");
                DialougeScript.lines.Add("It큦 possible he was holding it at the time of his death.");
                switchToNonSelf = true;
            }

            if (gameObject.name == "Corpse")
            {
                print(gameObject.name);
                DialougeScript.lines.Add("Nice boots, polished and everything. Not even the soles are dirty.");
            }

            if (switchToNonSelf == true)
            {
                DialougeScript.ChangeToPerson1();
            }
            else
            {
                DialougeScript.ChangeToPerson2();
            }

            DialougeScript.StartDialouge(); //Starts the dialogue
            switchToNonSelf = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
