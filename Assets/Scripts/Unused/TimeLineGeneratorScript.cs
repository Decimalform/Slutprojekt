using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TimeLineGeneratorScript : MonoBehaviour
{
    //times
    public List<string> times;
    public int timeOfDeath;
    public int numberOfTimeSlots;
    public int timeChosen;

    //suspects
    public List<string> suspects;
    public int killer;

    //places
    public List<string> places;
    public List<Vector3> placesCordinates;
    public int placeOfDeath;
    public int randomPlace;
    public List<Vector3> possibleTargetPositions;

    //distances
    public float distanceLeft;
    public float distanceRight;
    public float distanceUp;
    public float distanceDown;

    //weapons
    public List<string> weapons;
    public int murderWeapon;

    //Extra variables for loops and ranges
    public int numberOfSuspects;
    public int roomOfSuspects;
    public bool spawnedCharacters;
    public int numberOfMovements;
    public GameObject place;

    //GameObjects that will represent the diffirent suspects in game
    public List<GameObject> characterPrefabs;
    public GameObject characterPrefab;//Remove later
    public List<List<GameObject>> CharacterTimeBasedPosition = new List<List<GameObject>>(); //Generates a list of lists with GameObjects
    public List<List<List<List<Vector3>>>> SingualrMovements = new List<List<List<List<Vector3>>>>();

    //List variables
    public int currentTime;
    public int amountOfCharacters;
    public int moveNumber;
    public Vector3 raycastOrigin;

    // Start is called before the first frame update
    void Start()
    {
        spawnedCharacters = false;
        CharacterTimeBasedPosition = new List<List<GameObject>>();
        GeneralListAdder();
        SuspectsAdder();
        CharacterTimeBasedPositionAdder();
        Debug.Log("Start functioning");


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            //killer generator
            killer = Random.Range(0, 6);

            //time of death generator
            timeOfDeath = Random.Range(0, (times.Count));

            //place of death generator
            placeOfDeath = Random.Range(0, 9);

            //murderweapon generator
            murderWeapon = Random.Range(0, 6);

            print(suspects[killer] + " killed Mr. Boddy at " + times[timeOfDeath] + " in " + places[placeOfDeath] + " with the " + weapons[murderWeapon]);
            suspects.RemoveAt(killer);

            movementMaker();
            GameObject character = Instantiate(characterPrefabs[amountOfCharacters], SingualrMovements[currentTime][amountOfCharacters][moveNumber][0], Quaternion.identity);

            //EventGenerator();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            print("pressed button");
            timeChosen = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("pressed button");
            timeChosen = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("pressed button");
            timeChosen = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("pressed button");
            timeChosen = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            print("pressed button");
            timeChosen = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            print("pressed button");
            timeChosen = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            print("pressed button");
            timeChosen = 6;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0) || (Input.GetKeyDown(KeyCode.Alpha1) ) || (Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Alpha3)) || (Input.GetKeyDown(KeyCode.Alpha4)) || (Input.GetKeyDown(KeyCode.Alpha5)) || (Input.GetKeyDown(KeyCode.Alpha6)))
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Character");

            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }
            
            GameObject Canvas = GameObject.FindWithTag("SoundScript");

            print("pressed button");

            foreach (GameObject cha in CharacterTimeBasedPosition[timeChosen])
            {
                GameObject newCharacter = Instantiate(cha, Canvas.transform);
                newCharacter.transform.SetParent(Canvas.transform);

                newCharacter.tag = "Character";
            }
        }
    }

    private void EventGenerator()
    {
        //Removes the killer from the list so that the killer isn´t in two places at the same time
        suspects.RemoveAt(killer);
        characterPrefabs.RemoveAt(killer);

        //nästlad loop
        for (int i = 0; i < times.Count; i++)
        {
            for (int n = 0; n < suspects.Count; n++)
            {
                roomOfSuspects = Random.Range(0, 9);
                randomPlace = Random.Range(0, 9);

                print("At " + times[i] + " " + suspects[n] + " was in " + places[roomOfSuspects]);

                //adds the character to a list of characters in places for a certain time
                GameObject character = Instantiate(characterPrefabs[n], placesCordinates[randomPlace], Quaternion.identity);

                CharacterTimeBasedPosition[i].Add(character);

                //Changes character to the right name
                CharacterTimeBasedPosition[i][n].name = suspects[n];
                
            }
        }

        //Removes all the suspects and then re-adds them so that the killer is once againm included in the list
        suspects.Clear();
        SuspectsAdder();
    }

    private void KillersTimeLineGenerator()
    {
        int HHHH;
        HHHH = CharacterTimeBasedPosition[0].Count;
    }
    private void WeaponGenerator()
    {
        int HHHH;
        HHHH = CharacterTimeBasedPosition[0].Count;
    }

    private void GeneralListAdder()
    {
        //times
        times.Add("18:00");
        times.Add("18:30");
        times.Add("19:00");
        times.Add("19:30");
        times.Add("20:00");
        times.Add("20:30");
        times.Add("21:00");

        //places (the numbers indicate which spot the rooms have on the grid)
        places.Add("the kitchen");//1 - 0
        places.Add("the ball room");//2 - 1
        places.Add("the conservatory");//3 - 2
        places.Add("the dinning room");//4 - 3
        places.Add("the lounge");//5 - 4
        places.Add("the billiard room");//6 - 5
        places.Add("the library");//7 - 6 
        places.Add("the hall");//8 - 7
        places.Add("the study");//9 - 8

        //places actual cordinates
        //note to self: kolla om det finns ett mer effektivt sätt att genera alla vektorer (t.ex med en nästlad loop)
        Vector3 kitchen = new Vector3(-1, 1, 0);
        placesCordinates.Add(kitchen);

        Vector3 ballRoom = new Vector3(0, 1, 0);
        placesCordinates.Add(ballRoom);

        Vector3 conservatory = new Vector3(1, 1, 0);
        placesCordinates.Add(conservatory);

        Vector3 dinningRoom = new Vector3(-1, 0, 0);
        placesCordinates.Add(dinningRoom);

        Vector3 lounge = new Vector3(0, 0, 0);
        placesCordinates.Add(lounge);

        Vector3 billiardRoom = new Vector3(1, 0, 0);
        placesCordinates.Add(billiardRoom);

        Vector3 library = new Vector3(-1, -1, 0);
        placesCordinates.Add(library);

        Vector3 hall = new Vector3(0, -1, 0);
        placesCordinates.Add(hall);

        Vector3 study = new Vector3(1, -1, 0);
        placesCordinates.Add(study);

        //In-game places (for raycasts)
        for (int inGamePlaces = 0; inGamePlaces < placesCordinates.Count; inGamePlaces++)
        {
            Instantiate(place, placesCordinates[inGamePlaces], Quaternion.identity);
        }

        //weapons - all weapons
        weapons.Add("revolver");
        weapons.Add("knife");
        weapons.Add("rope");

        //bludgeoning weapons
        weapons.Add("lead pipe");
        weapons.Add("wrench");
        weapons.Add("candlestick");
    }

    //SuspectsAdder is a seperate function so that I can acsess and change the suspects list easier
    private void SuspectsAdder()
    {
        //suspects
        suspects.Add("Miss Scarlett");
        suspects.Add("Colonell Mustard");
        suspects.Add("Mr. Green");
        suspects.Add("Mrs. Peackock");
        suspects.Add("Profesor Plum");
        suspects.Add("Doctor Orchid");
    }
    private void CharacterTimeBasedPositionAdder()
    {
        List<GameObject> visableCharacters18 = new List<GameObject>(); //This defines the list before adding it
        Debug.Log("Added first object");
        CharacterTimeBasedPosition.Add(visableCharacters18); //This adds the list to CharacterTimeBasedPosition

        List<GameObject> visableCharacters1830 = new List<GameObject>();
        Debug.Log("Added the second object");
        CharacterTimeBasedPosition.Add(visableCharacters1830);

        List<GameObject> visableCharacters19 = new List<GameObject>();
        CharacterTimeBasedPosition.Add(visableCharacters19);

        List<GameObject> visableCharacters1930 = new List<GameObject>();
        CharacterTimeBasedPosition.Add(visableCharacters1930);

        List<GameObject> visableCharacters20 = new List<GameObject>();
        CharacterTimeBasedPosition.Add(visableCharacters20);

        List<GameObject> visableCharacters2030 = new List<GameObject>();
        CharacterTimeBasedPosition.Add(visableCharacters2030);

        List<GameObject> visableCharacters21 = new List<GameObject>();
        CharacterTimeBasedPosition.Add(visableCharacters21);
    }
    private void movementMaker()
    {
        //Adds all the times to the "main" list
        List<List<List<Vector3>>> eighteen = new List<List<List<Vector3>>>();
        SingualrMovements.Add(eighteen);

        List<List<List<Vector3>>> eighteenThirty = new List<List<List<Vector3>>>();
        SingualrMovements.Add(eighteenThirty);

        List<List<List<Vector3>>> nineteen = new List<List<List<Vector3>>>();
        SingualrMovements.Add(nineteen);

        List<List<List<Vector3>>> nineteenThirty = new List<List<List<Vector3>>>();
        SingualrMovements.Add(nineteenThirty);

        List<List<List<Vector3>>> twenty = new List<List<List<Vector3>>>();
        SingualrMovements.Add(twenty);

        List<List<List<Vector3>>> twentyThirty = new List<List<List<Vector3>>>();
        SingualrMovements.Add(twentyThirty);

        List<List<List<Vector3>>> twentyone = new List<List<List<Vector3>>>();
        SingualrMovements.Add(twentyone);

        print("added all lists");

        //loops in list
        for (currentTime = 0; currentTime < SingualrMovements.Count; currentTime++) //Loop that repeats for every time in the list
        {
            print("running time loop, currently on " + currentTime);

            //If there isn´t a position for a certain chracter then give that character a random starting position. Otherwise use the code like normal
            if (currentTime == 0)
            {
                for (int n = 0; n < suspects.Count; n++)
                {
                    randomPlace = Random.Range(0, 9);

                    print("At " + times[0] + " " + suspects[n] + " was in " + places[randomPlace]);

                    //adds the character to a list of characters in places for a certain time
                    GameObject character = Instantiate(characterPrefabs[n], placesCordinates[randomPlace], Quaternion.identity);

                    CharacterTimeBasedPosition[0].Add(character);

                    //Changes character to the right name
                    CharacterTimeBasedPosition[0][n].name = suspects[n];
                }
            }

            List<List<Vector3>> CharactersMovements = new List<List<Vector3>>();
            SingualrMovements[currentTime].Add(CharactersMovements); //Adds a character to the list of times


            for (amountOfCharacters = 0; amountOfCharacters < suspects.Count; amountOfCharacters++) //Loop that repeats utill all characters are added into the time
            {

                print("running character loop, currently on " + amountOfCharacters);

                List<Vector3> allMoves = new List<Vector3>();
                SingualrMovements[currentTime][amountOfCharacters].Add(allMoves); //Adds the list that movements will be stored in for each character HEEEEEEEELLA SUS

                numberOfMovements = Random.Range(1, 3);//Generates the number of times a character moves per timeslot

                /*
                print("currentTime: " + currentTime);
                print("amountOfCharacters: " + amountOfCharacters);
                print("position: " + (CharacterTimeBasedPosition[currentTime][amountOfCharacters].transform.position));

                raycastOrigin = (CharacterTimeBasedPosition[currentTime][amountOfCharacters].transform.position);

                print(raycastOrigin);*/

               for (moveNumber = 0; moveNumber < numberOfMovements; moveNumber++) //Loop that repeets the number of times a character moves durring one timeslot
                {
                    print("running move loop, currently on " + moveNumber);

                    //Raycasts that check which dircetions are possible to move in
                    RaycastHit hitLeft;
                    if (Physics.Raycast(raycastOrigin, Vector3.left, out hitLeft))
                    {
                        print("hitLeft " + hitLeft.collider.gameObject);
                        Vector3 positionToTheLeft = hitLeft.collider.gameObject.transform.position;

                        distanceLeft = hitLeft.distance;
                        if (distanceLeft < 1.1)
                        {
                            possibleTargetPositions.Add(positionToTheLeft); //If the distance to the position to the left is less than 1,1 the position is added to the list of possible directions to move in
                        }
                    }

                    RaycastHit hitRight;
                    if (Physics.Raycast(raycastOrigin, Vector3.right, out hitRight))
                    {
                        print("hitRight " + hitRight.collider.gameObject);
                        Vector3 positionToTheRight = hitRight.collider.gameObject.transform.position;

                        distanceLeft = hitRight.distance;
                        if (distanceLeft < 1.1)
                        {
                            possibleTargetPositions.Add(positionToTheRight);
                        }
                    }

                    RaycastHit hitUp;
                    if (Physics.Raycast(raycastOrigin, Vector3.up, out hitUp))
                    {
                        print("hitUp " + hitUp.collider.gameObject);
                        Vector3 positionToTheUp = hitUp.collider.gameObject.transform.position;

                        distanceLeft = hitUp.distance;
                        if (distanceLeft < 1.1)
                        {
                            possibleTargetPositions.Add(positionToTheUp);
                        }
                    }

                    RaycastHit hitDown;
                    if (Physics.Raycast(raycastOrigin, Vector3.down, out hitDown))
                    {
                        print("hitDown " + hitDown.collider.gameObject);
                        Vector3 positionToTheDown = hitDown.collider.gameObject.transform.position;

                        distanceLeft = hitDown.distance;
                        if (distanceLeft < 1.1)
                        {
                            possibleTargetPositions.Add(positionToTheDown);
                        }
                    }

                    print("possibleTargetPositions: " + possibleTargetPositions.Count);
                    int direction = Random.Range(0, possibleTargetPositions.Count); //Decides a dirrection to move in

                    print("currentTime: " + currentTime + " amountOfCharacters: " + amountOfCharacters + " moveNumber: " + moveNumber + " direction: ");
                    print("direction: " + direction);
                    print("SingularMovements" + SingualrMovements.Count);
                    print("currentTime" + SingualrMovements[currentTime].Count);
                    print("amountOfCharacters" + SingualrMovements[currentTime][amountOfCharacters].Count); //Hella sus
                    print("moveNumber" + SingualrMovements[currentTime][amountOfCharacters][moveNumber].Count);
                    SingualrMovements[currentTime][amountOfCharacters][moveNumber].Add(possibleTargetPositions[direction]); //Adds the singuar movement in one direction (times one hundered so that it will match the coordinates in the UI layer) to the list of movements

                }
            }
        }
    }
}
