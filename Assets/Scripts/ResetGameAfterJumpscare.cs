using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameAfterJumpscare : MonoBehaviour
{   
    #region Variables
    public GameObject GameOver; 
    #endregion
    // Start is called before the first frame update
    #region Methods
    void Start(){
        StartCoroutine(GameSceneReload());
        GameOver.SetActive(true);
    }
    #endregion

    #region IEnumerator
    IEnumerator GameSceneReload(){
    //Waits for 5 seconds than returns the player to a resetted game scene
        yield return new WaitForSeconds(6.5f);
        GameOver.SetActive(false);
        SceneManager.LoadScene("Game");
    }
  #endregion
}
