using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonLogic : MonoBehaviour
{
    #region Variables
    private GameObject BackToMainMenu;
    public AudioSource buttonSound2;
    #endregion
    // Start is called before the first frame update
    void Start(){
        BackToMainMenu = GameObject.Find("GameWon");
    }

    public void GameWon(){
        buttonSound2.Play();
        //Load Main Menu
        SceneManager.LoadScene("MainMenu");
    }
}
