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
    #endregion 

    #region instruction ui
    //hidden mesh triggers instruction ui when player enters proximity of door

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
    private void OpenWindow()
    {
        AnimeObject.GetComponent<Animator>().Play("WindowOpen");
        ThisTrigger.SetActive(false);
        StalkerAction = false;      
        ClosedWindowCounter.current.DecreaseCounter();
    }
    #endregion 
}
