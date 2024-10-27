using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInstructionsFalse : MonoBehaviour
{
    #region Variables
    public GameObject KeyInstructions;
    public GameObject Key;
    #endregion
    // Start is called before the first frame update
    #region Update
    void Update()
    {
        //Checks if the player has key equipped
        if(Key.activeSelf == true){
            KeyInstructions.SetActive(false);
        }
    }
    #endregion
}
