using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUnderBed : MonoBehaviour
{
    public GameObject LookUnderBedInstruction;
    public GameObject CamUnderBed;
    //public GameObject CamBehindPainting;
   // public GameObject CamUnderCouch;
    public GameObject PlayerCamera;
    public int Manager;
    public bool ReachBed;
    public GameObject Player;
    public GameObject Key;
    public GameObject GrabKeyAndExitInstruction;
    private bool ExitBed;
    public GameObject BedTrigger;
    // Start is called before the first frame update

   [SerializeField] private Animator FadeInOut;
    [SerializeField] private Animator Bedani;
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
      //  CamBehindPainting.SetActive(false);
       // CamUnderCouch.SetActive(false);

    }


    private void OnTriggerStay(Collider other)
    {
        if (!ExitBed)
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
     //   CamBehindPainting.SetActive(false);
     //   CamUnderCouch.SetActive(false);
        PlayerCamera.SetActive(false);
    }

    void CamBehindPaintingActive()
    {
        CamUnderBed.SetActive(false);
    //    CamBehindPainting.SetActive(true);
     //   CamUnderCouch.SetActive(false);
        PlayerCamera.SetActive(false);
    }


    void CamUnderCouchActive()
    {
        CamUnderBed.SetActive(false);
    //    CamBehindPainting.SetActive(false);
    //    CamUnderCouch.SetActive(true);
        PlayerCamera.SetActive(false);
    }

    void PlayerCameraActive()
    {
        PlayerCamera.SetActive(true);
        CamUnderBed.SetActive(false);
   //     CamBehindPainting.SetActive(false);
   //     CamUnderCouch.SetActive(false);
    }



    void Update()
    {
        if  (ReachBed && Input.GetKey(KeyCode.E))
        {
            StartCoroutine(GoUnderBed());
        }
        if  (!PlayerCamera.activeSelf && ExitBed == true && Input.GetKey(KeyCode.E))
        {
            StartCoroutine(GetKeyGetOut());
            return;
            
        }
    }

    private IEnumerator GoUnderBed()
    {
        //animation fade in fade out
        if (!ExitBed) {
            Player.SetActive(false);
            Bedani.GetComponent<Animator>().Play("DarknessToLightExitBed");
            //waits 1 second otherwise cam change before animation
            LookUnderBedInstruction.SetActive(false);
            CamUnderBedActive();
            yield return new WaitForSeconds(1);
            FadeInOut.GetComponent<Animator>().Play("LiftBed");
            GrabKeyAndExitInstruction.SetActive(true);
            ExitBed = true;
            //break
            yield break;
        }
    }

    private IEnumerator GetKeyGetOut()
    {
        Player.SetActive(true);
        Bedani.GetComponent<Animator>().Play("DarknessToLightExitBed2");
        //PlayerCameraActive();
        PlayerCamera.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        CamUnderBed.SetActive(false);
        GrabKeyAndExitInstruction.SetActive(false);
        Key.SetActive(true);
        GrabKeyAndExitInstruction.SetActive(false);
        FadeInOut.GetComponent<Animator>().Play("BedDown");
        yield break;
    }
}
