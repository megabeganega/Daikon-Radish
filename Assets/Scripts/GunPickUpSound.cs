using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUpSound : MonoBehaviour
{
    #region Variables
    public GameObject Gun;
    public AudioSource GetGunSound;
    #endregion
    
    #region Update
    void Update()
    {
        //Checks if Gun game object is active
        if(Gun.activeSelf == true){
            //Plays Pick Up sound 
            GetGunSound.enabled = true;
        }
    }
    #endregion
}
