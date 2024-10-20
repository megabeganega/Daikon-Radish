using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBoxScript : MonoBehaviour
{
    #region Variables
    public Animator boxOB;
    //GameObject needed to Unlock Box
    public GameObject keyOBNeeded;
    public GameObject openText;
    public GameObject keyMissingText;
    public AudioSource openSound;
    public bool ShowGun;

    public bool inReach;
    public bool isOpen;
    public GameObject ChaserStalker;
    public GameObject WindowStalker;
    #endregion


    #region Start
    void Start()
    {
        inReach = false;
        openText.SetActive(false);
        keyMissingText.SetActive(false);
        ShowGun = false;
        ChaserStalker.SetActive(false);
    }
    #endregion

    #region ColliderDetection
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            keyMissingText.SetActive(false);
        }
    }
    #endregion

    #region Update
    void Update()
    {
        //unlocks
        if (keyOBNeeded.activeInHierarchy == true && inReach && Input.GetButtonDown("Interact"))
        {
            keyOBNeeded.SetActive(false);
            openSound.Play();
            boxOB.SetBool("open", true);
            openText.SetActive(false);
            keyMissingText.SetActive(false);
            isOpen = true;
            ShowGun = true;
            ChaserStalker.SetActive(true);
            WindowStalker.SetActive(false);
        }
        //doesn't unlock, key is missing
        else if (keyOBNeeded.activeInHierarchy == false && inReach && Input.GetButtonDown("Interact"))
        {
            openText.SetActive(false);
            keyMissingText.SetActive(true);
        }
        //Script is disabled + Collider false
        if(isOpen)
        {
            boxOB.GetComponent<BoxCollider>().enabled = false;
            boxOB.GetComponent<OpenBoxScript>().enabled = false;
        }
    }
    #endregion
}
