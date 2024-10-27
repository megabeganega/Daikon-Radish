using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    #region Variables
    public GameObject PickupText;
    public GameObject ItemOnPlayer;
    public GameObject BulletCount;
    #endregion
    // Start is called before the first frame update
    #region Methods
    void Start(){
        //Sets Bullet Count To False so that it doesn't show up when it shouldn't
        BulletCount.SetActive(false);
        ItemOnPlayer.SetActive(false);
        PickupText.SetActive(false);
    }

    private void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Reach"){
            //enters trigger shows instructions
            PickupText.SetActive(true);
            //Press E in Trigger = Pick Up item
            if(Input.GetKey(KeyCode.E)){
                this.gameObject.SetActive(false);
                ItemOnPlayer.SetActive(true);
                PickupText.SetActive(false);
                BulletCount.SetActive(true);
            }
        }
    } 

    private void OnTriggerExit(Collider other){
        //Pick Up Instructions Disappear After Exiting Collider
        PickupText.SetActive(false);
    }
    #endregion
}
    