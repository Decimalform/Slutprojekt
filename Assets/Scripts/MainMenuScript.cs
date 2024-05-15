using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
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
}

