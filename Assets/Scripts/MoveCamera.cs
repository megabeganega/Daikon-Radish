using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
   #region Variables
   public Transform cameraPosition;
   #endregion Variables

   #region Update
   private void Update(){
      //move camera position
      transform.position = cameraPosition.position;
   }
   #endregion
}
