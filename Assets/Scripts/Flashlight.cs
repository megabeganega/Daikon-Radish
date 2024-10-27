using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    #region Variables
    public GameObject flashlight;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool on;
    public bool off;
    #endregion



    #region Start
    void Start(){
        //flashlight off when game start
        off = true;
        flashlight.SetActive(false);
    }
    #endregion

    #region Update
    void Update(){
        //flashlight input
        if(off && Input.GetButtonDown("F")){
            flashlight.SetActive(true);
            turnOn.Play();
            off = false;
            on = true;
        }
        //Turns off if on and pressed F key
        else if(on && Input.GetButtonDown("F")){
            flashlight.SetActive(false);
            turnOff.Play();
            off = true;
            on = false;
        }
    }
    #endregion
}