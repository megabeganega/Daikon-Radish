using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{  
    #region variables
    private GameObject mainMenu;
    private GameObject optionsMenu;
    private GameObject loading; 
    private GameObject instructionsMenu;

    public AudioSource buttonSound;
    #endregion
    #region Start
    void Start(){
        mainMenu = GameObject.Find("MainMenuCanvas");
        optionsMenu = GameObject.Find("OptionsCanvas");
        loading = GameObject.Find("LoadingCanvas");
        instructionsMenu = GameObject.Find("InstructionsCanvas");

        //sets main menu to default scene
        mainMenu.GetComponent<Canvas>().enabled = true;
        optionsMenu.GetComponent<Canvas>().enabled = false;
        loading.GetComponent<Canvas>().enabled = false;
        instructionsMenu.GetComponent<Canvas>().enabled = false;
    }
    #endregion
    #region Methods
    //Button SFX + Scene enabled/disabled
    public void StartButton(){
        loading.GetComponent<Canvas>().enabled = true;
        mainMenu.GetComponent<Canvas>().enabled = false;
        buttonSound.Play();
        SceneManager.LoadScene("Game");
    }

    public void OptionsButton(){
        //Goes to Options
        buttonSound.Play();
        mainMenu.GetComponent<Canvas>().enabled = false;
        optionsMenu.GetComponent<Canvas>().enabled = true;
    }

    public void ExitGameButton(){
        //Exits Game
        buttonSound.Play();
        Application.Quit();
    }

    public void ReturnToMainMenuButton(){
        //Returns to Main Menu
        buttonSound.Play();
        mainMenu.GetComponent<Canvas>().enabled = true;
        optionsMenu.GetComponent<Canvas>().enabled = false;
    }

    public void InstructionsMenuButton(){
        //Intrustctions
        buttonSound.Play();
        mainMenu.GetComponent<Canvas>().enabled = false;
        instructionsMenu.GetComponent<Canvas>().enabled = true;
    }
    #endregion
}
