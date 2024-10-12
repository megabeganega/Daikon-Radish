using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUnderSofa : MonoBehaviour
{
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
    public GameObject CouchTrigger;
    // Start is called before the first frame update

   [SerializeField] private Animator FadeInOut;
    [SerializeField] private Animator Couchani;
    void Start()
    {
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
        //Prevents Player from lifting object if they already have key
        if (!ExitBed && Key.activeSelf == false)
        {
            if(other.gameObject.tag == "Reach")
            {
                //enters trigger shows instructions
                LookUnderBedInstruction.SetActive(true);
                ReachBed = true;
            }
        }
    }

     private void OnTriggerExit(Collider other)
    {
        //Pick Up Instructions Disappear After Exiting Collider
        LookUnderBedInstruction.SetActive(false);
        ReachBed = false;
       
    }

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



    void Update()
    {
        if  (ReachBed && Input.GetKey(KeyCode.E))
        {
            StartCoroutine(GoUnderCouch());
        }
        if  (!PlayerCamera.activeSelf && ExitBed == true && Input.GetKey(KeyCode.E))
        {
            StartCoroutine(GetKeyGetOutCouch());
            return;
            
        }
    }

    private IEnumerator GoUnderCouch()
    {
        //animation fade in fade out
        if (!ExitBed) {
            Player.SetActive(false);
            FadeInOut.GetComponent<Animator>().Play("DarknessToLightExitBed");
            //waits 1 second otherwise cam change before animation
            LookUnderBedInstruction.SetActive(false);
            CamUnderCouchActive();
            yield return new WaitForSeconds(1);
            Couchani.GetComponent<Animator>().Play("LiftSofa");
            GrabKeyAndExitInstruction.SetActive(true);
            ExitBed = true;
            //break
            yield break;
        }
    }

    private IEnumerator GetKeyGetOutCouch()
    {
        Player.SetActive(true);
        FadeInOut.GetComponent<Animator>().Play("DarknessToLightExitBed2");
        //PlayerCameraActive();
        PlayerCamera.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        CamUnderBed.SetActive(false);
        GrabKeyAndExitInstruction.SetActive(false);
        Key.SetActive(true);
        GrabKeyAndExitInstruction.SetActive(false);
        Couchani.GetComponent<Animator>().Play("SofaDown");
        yield break;
    }
}
