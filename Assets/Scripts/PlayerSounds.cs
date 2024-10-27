using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    #region Variables
    public AudioSource footstepsSound, sprintSound;
    #endregion

    #region Update
    void Update()
    {
        //Checks for inputs of 4 keys
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            //Checks if sprinting 
            if(Input.GetKey(KeyCode.LeftShift)){
                footstepsSound.enabled = false;
                sprintSound.enabled = true;
            }
            //Sprint sound disabled if not running
            else{
                footstepsSound.enabled = true;
                sprintSound.enabled = false;
            }
        }
        //Walking Sound + Sprinting Sound disabled when player isn't moving
        else{
            footstepsSound.enabled = false;
            sprintSound.enabled = false;
        }
    }
    #endregion
}