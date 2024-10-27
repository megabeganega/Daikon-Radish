using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGun : MonoBehaviour
{
    #region Variables
    public GameObject gun;
    public OpenBoxScript openBoxScript;
    public PickUpSystem pickUpSystem;
    private bool GunShown;
    #endregion

    #region Start
    void Start(){
        //sets both the GunToBePickedUp and Gun held in player POV to false, aswell as the BulletCount for the gun
        pickUpSystem.ItemOnPlayer.SetActive(false);
        gun.SetActive(false);
        pickUpSystem.BulletCount.SetActive(false);
        GunShown = false;
    }
    #endregion
    
    #region Update
    void Update(){
        if(GunShown == true){return;}
        if(openBoxScript.ShowGun == true){
            StartCoroutine(GunShow());
            //If Player is holding Gun, the GunToBePickedUp disappears
            if(GunShown == true){
                gun.SetActive(false);
            }
        }
    }

    private IEnumerator GunShow(){
        GunShown = true;
        //Waits for 2 seconds 
        yield return new WaitForSeconds(2);
        gun.SetActive(true);
    }
    #endregion
}