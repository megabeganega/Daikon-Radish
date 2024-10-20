using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerActiveGunActive : MonoBehaviour
{
    public GameObject Gun;
    public GameObject ChaserStalker;

    void Update()
    {
        //Trigger is enabled only when first stage ends, until then its disabled
        if (Gun.activeSelf == false)
        {
            ChaserStalker.SetActive(false);
        }
        if (Gun.activeSelf == true)
        {
            Debug.Log(Gun.activeSelf);
            ChaserStalker.SetActive(true);
        }

    }
}
