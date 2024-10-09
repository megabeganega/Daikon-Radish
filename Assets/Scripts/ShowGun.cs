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
        pickUpSystem.ItemOnPlayer.SetActive(false);
        gun.SetActive(false);
        pickUpSystem.BulletCount.SetActive(false);

    }
    
    void Update()
    {
        if (openBoxScript.ShowGun == true)
        {
            gun.SetActive(true);
            if (pickUpSystem.ItemOnPlayer.activeSelf == true)
            {
                gun.SetActive(false);
                return;
            }
        }
    }
}