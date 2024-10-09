using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGun : MonoBehaviour
{
    public GameObject gun;
    public OpenBoxScript openBoxScript;
    public PickUpSystem pickUpSystem;

    void Start()
    {
        //sets both the GunToBePickedUp and Gun held in player POV to false, aswell as the BulletCount for the gun
        pickUpSystem.ItemOnPlayer.SetActive(false);
        gun.SetActive(false);
        pickUpSystem.BulletCount.SetActive(false);

    }
    
    void Update()
    {
        if (openBoxScript.ShowGun == true)
        {
            gun.SetActive(true);
            //If Player is holding Gun, the GunToBePickedUp disappears
            if (pickUpSystem.ItemOnPlayer.activeSelf == true)
            {
                gun.SetActive(false);
                return;
            }
        }
    }
}