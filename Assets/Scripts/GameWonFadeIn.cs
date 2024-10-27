using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonFadeIn : MonoBehaviour
{
    #region Variables
    public Animator DarkSequence;
    #endregion
    // Start is called before the first frame update
    #region Start
    void Start(){
        //Shows the mouse again
        Cursor.visible = true;
        //Unlocks Cursors
        Cursor.lockState = CursorLockMode.None;
        DarkSequence.GetComponent<Animator>().Play("DarkSequence1");
    }
    #endregion
}
