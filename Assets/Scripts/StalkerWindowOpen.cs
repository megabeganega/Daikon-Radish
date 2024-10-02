using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerWindowOpen : MonoBehaviour
{
    #region Variables
    // event

    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public bool StalkerAction = false;
    public bool WindowOpened = true;
    #endregion 

    #region instruction ui
    //hidden mesh triggers instruction ui when player enters proximity of door

    public void Start(){
       // WindowOpened = true;
        WindowOpened = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        //Collider detects Player
        if (collision.transform.tag == "Enemy")
        {
            //Maybe Add An IE Numerator here so it can loop idk.
            OpenWindow();
        }
    }
    #endregion

    #region window close
    //Press E = Window close
    public void OpenWindow()
    {
        WindowOpened = true; 
        AnimeObject.GetComponent<Animator>().Play("WindowOpen");
        ThisTrigger.SetActive(true);
        StalkerAction = false;      
        ClosedWindowCounter.current.DecreaseCounter();
    }
    #endregion 
}
