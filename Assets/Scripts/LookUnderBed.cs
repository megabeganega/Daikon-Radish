using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUnderBed : MonoBehaviour
{
    #region Variables
    public GameObject LookUnderBedInstruction;
    public GameObject CamUnderBed;
    public GameObject CamBehindPainting;
    public GameObject CamUnderCouch;
    public GameObject PlayerCamera;
    public bool ReachBed;
    public GameObject Player;
    public GameObject Key;
    public GameObject GrabKeyAndExitInstruction;
    private bool ExitBed;
    public GameObject flashlight;
    //Bool Represents if Key Is under object or not
    private bool KeyToBePickedUp;
    [SerializeField] GameObject NoKeyToBePickedUpInstruction;
    // Start is called before the first frame update
    private bool SecondCoroutineNoKey;
    private bool SecondCoroutineKey;
    public AudioSource GetKeySound;


    [SerializeField] private Animator FadeInOut;
    [SerializeField] private Animator Bedani;
    #endregion
    #region Methods
    void Start()
    {
        SecondCoroutineKey = false;
        SecondCoroutineNoKey = false;
        KeyToBePickedUp = false;
        NoKeyToBePickedUpInstruction.SetActive(false);
        flashlight.SetActive(false);
        Key.SetActive(false);
        ExitBed = false;
        GrabKeyAndExitInstruction.SetActive(false);
        Player.SetActive(true);
        LookUnderBedInstruction.SetActive(false);
        PlayerCamera.SetActive(true);
        CamUnderBed.SetActive(false);
        ReachBed = false;
        CamBehindPainting.SetActive(false);
        CamUnderCouch.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        //KeyToBePickedUp = true, if there is KeyToBePickedUp
        if (other.gameObject.tag == "KeyToBePickedUp")
        {
            KeyToBePickedUp = true;
        }
        //Prevents Player from lifting object if they already have key
        if (!ExitBed && Key.activeSelf == false)
        {
            if(other.gameObject.tag == "Reach")
            {
                //enters trigger shows instructions
                LookUnderBedInstruction.SetActive(true);
                ReachBed = true;
                //Coroutine start when ExitBed == false, So Coroutine Can't Be Repeated again
                if (ExitBed == false && Input.GetKeyDown(KeyCode.E) && !KeyToBePickedUp)
                {
                    Debug.Log("GoUnderBedNoKey");
                    StartCoroutine(GoUnderBedNoKey());
                }
                if (ExitBed == false && Input.GetKeyDown(KeyCode.E) && KeyToBePickedUp)
                {
                    //Different Coroutine started when there is a Key to be picked up
                    Debug.Log("GoUnderBedKey");
                    StartCoroutine(GoUnderBedKey());
                }
            }
        }
    }

     private void OnTriggerExit(Collider other)
    {
        //Pick Up Instructions Disappear After Exiting Collider
        LookUnderBedInstruction.SetActive(false);
        ReachBed = false;
       
    }
    //Appropriate Cameras Set True/False
    void CamUnderBedActive()
    {
        CamUnderBed.SetActive(true);
        CamBehindPainting.SetActive(false);
        CamUnderCouch.SetActive(false);
        PlayerCamera.SetActive(false);
    }

    void CamBehindPaintingActive()
    {
        CamUnderBed.SetActive(false);
        CamBehindPainting.SetActive(true);
        CamUnderCouch.SetActive(false);
        PlayerCamera.SetActive(false);
    }


    void CamUnderCouchActive()
    {
        CamUnderBed.SetActive(false);
        CamBehindPainting.SetActive(false);
        CamUnderCouch.SetActive(true);
        PlayerCamera.SetActive(false);
    }

    void PlayerCameraActive()
    {
        PlayerCamera.SetActive(true);
        CamUnderBed.SetActive(false);
        CamBehindPainting.SetActive(false);
        CamUnderCouch.SetActive(false);
    }
    #endregion


    #region Update
    void Update()
    {
        //returns if ExitBed = true Avoids Repeats of the Second Coroutine
        if (ExitBed) {return;}
        //GetKeyDown avoids multiple Coroutines from starting
        if (Input.GetKeyDown(KeyCode.E) && SecondCoroutineNoKey)
            {
                StartCoroutine(GetOutBedNoKey());
            }
        if (Input.GetKeyDown(KeyCode.E) && SecondCoroutineKey)
            {
                GetKeySound.enabled = true;
                StartCoroutine(GetKeyGetOutBed());
            }
    }

    #endregion
    #region IEnumerator
    private IEnumerator GoUnderBedKey()
    {
        Player.SetActive(false);
        flashlight.SetActive(true);
        FadeInOut.GetComponent<Animator>().Play("DarknessToLightExitBed");
        LookUnderBedInstruction.SetActive(false);
        GrabKeyAndExitInstruction.SetActive(true);
        CamUnderBedActive();
        yield return new WaitForSeconds(1);
        Bedani.GetComponent<Animator>().Play("LiftBed");
        //So Player can't mash button and skip cutscene
        yield return new WaitForSeconds(1.2f);
        SecondCoroutineKey = true;
    }

    private IEnumerator GetKeyGetOutBed()
    {
         //Prevents player mashing E so that animation sequence plays again
        ExitBed = true;
        Debug.Log("GeyKeyGetOutBed");
        Key.SetActive(true);
        Player.SetActive(true);
        flashlight.SetActive(false);
        FadeInOut.GetComponent<Animator>().Play("DarknessToLightExitBed");
        GrabKeyAndExitInstruction.SetActive(false);
        PlayerCameraActive();
        yield return new WaitForSeconds(1);
        Bedani.GetComponent<Animator>().Play("BedDown");
        ExitBed = true;
    }
    

    private IEnumerator GoUnderBedNoKey()
    {
        Player.SetActive(false);
        flashlight.SetActive(true);
        FadeInOut.GetComponent<Animator>().Play("DarknessToLightExitBed");
        LookUnderBedInstruction.SetActive(false);
        NoKeyToBePickedUpInstruction.SetActive(true);
        CamUnderBedActive();
        yield return new WaitForSeconds(1);
        Bedani.GetComponent<Animator>().Play("LiftBed");
        //So Player can't mash button and skip cutscene
        yield return new WaitForSeconds(1.2f);
        SecondCoroutineNoKey = true;
    }

    private IEnumerator GetOutBedNoKey()
    {
         //Prevents player mashing E so that animation sequence plays again
        ExitBed = true;
        Debug.Log("GetOutBedNoKey");
        Player.SetActive(true);
        flashlight.SetActive(false);
        FadeInOut.GetComponent<Animator>().Play("DarknessToLightExitBed2");
        NoKeyToBePickedUpInstruction.SetActive(false);
        PlayerCameraActive();
        yield return new WaitForSeconds(1);
        Bedani.GetComponent<Animator>().Play("BedDown");
        ExitBed = true;
        LookUnderBedInstruction.SetActive(false);
    }
    
}
    #endregion


