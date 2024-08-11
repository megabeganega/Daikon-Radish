using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    #region Variables
    //"SerializeField" creates inspector, private ensures no class can access this code
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Vector2 Sensitivities;

    private Vector2 XYRotation;
    #endregion

   
    #region Mouse Movement
    //Basic Mouse Movement
    void Update()
    {
        Vector2 MouseInput = new Vector2 
        {
            x = Input.GetAxis("Mouse X"),    
            y = Input.GetAxis("Mouse Y")
        };

        XYRotation.x -= MouseInput.y * Sensitivities.y;
        XYRotation.y += MouseInput.x * Sensitivities.x;

        XYRotation.x = Mathf.Clamp(XYRotation.x, -90f, 90f);

        transform.eulerAngles = new Vector3(0f, XYRotation.y, 0f);
        PlayerCamera.localEulerAngles = new Vector3(XYRotation.x, 0f, 0f);
        
    }
    #endregion
}