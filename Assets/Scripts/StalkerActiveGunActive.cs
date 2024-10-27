using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerActiveGunActive : MonoBehaviour
{
    #region Variables
    public GameObject Gun;
    public GameObject ChaserStalker;
    #endregion

    #region Update
    void Update(){
        //Trigger is enabled only when first stage ends, until then its disabled
        if(Gun.activeSelf == false){
            ChaserStalker.SetActive(false);
        }
        if(Gun.activeSelf == true){
            //Chaser Stalker Activated when Player Opens Box to get spawned gun
            ChaserStalker.SetActive(true);
        }

    }
    #endregion
}
