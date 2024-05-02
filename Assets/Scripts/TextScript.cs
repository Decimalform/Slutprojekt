using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public TextMeshPro textbox;

    //variables
    public int index;
    public int keyInt;

    //Lists of strings
    public List<string> places;

    public List<string> times;

    //Lists of GameObjects
    public List<GameObject> weapons;

    // Start is called before the first frame update
    void Start()
    {
        //places
        places.Add("Kitchen");
        places.Add("Dinning Room");
        places.Add("Lounge");
        places.Add("Ballroom");
        places.Add("Hall");
        places.Add("Conservatory");
        places.Add("Billiard Room");
        places.Add("Library");
        places.Add("Study");

        //times

        //GameObjects
    }

    // Update is called once per frame
    void Update()
    {
        textbox = GameObject.FindObjectOfType<TextMeshPro>();

        if(Input.GetKeyDown(KeyCode.P))
        {
            textbox.text = (places[0] + " - 1" + places[1] + " - 2" + places[3] + " - 4" + places[4] + " - 5" + places[5] + " - 6" + places[6] + " - 7" + places[7] + " - 8" + places[8] + " - 9");

            if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3)
                || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6)
                || Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Alpha9))
            {
                if (Input.anyKeyDown)
                {
                    foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
                    {
                        if (Input.GetKeyDown(key))
                        {
                            Debug.Log("Key " + key.ToString() + " was pressed.");
                            
                            keyInt = (int)key - (int)KeyCode.Alpha1 + 1;

                            textbox.text = ("Place selected " + places[(keyInt - 1)]);
                        }
                    }
                }

            }
        }
    }
}
