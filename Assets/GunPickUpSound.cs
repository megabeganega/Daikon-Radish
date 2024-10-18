using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUpSound : MonoBehaviour
{
    public GameObject Gun;
    public AudioSource GetGunSound;
    void Update()
    {
        //Checks if Gun game object is active
        if(Gun.activeSelf == true)
        {
            //Plays Pick Up sound 
            GetGunSound.enabled = true;
        }
    }
}
