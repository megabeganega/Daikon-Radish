using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject CamUnderBed;
    public GameObject Canvas;
   // public GameObject CamBehindPainting;
   // public GameObject CamUnderCouch;
    public GameObject PlayerCamera;
    public int Manager;

    void Start()
    {
        Canvas.SetActive(false);
    }
    public void ManageCamera()
    {
        if(Manager == 0)
        {
            CamUnderBedActive();
            Manager = 1;
        }
        else
        {
            PlayerCameraActive();
            Manager = 0;
        }
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
        CamUnderBed.SetActive(false);
   //     CamBehindPainting.SetActive(false);
   //     CamUnderCouch.SetActive(false);
        PlayerCamera.SetActive(true);
    }
}
