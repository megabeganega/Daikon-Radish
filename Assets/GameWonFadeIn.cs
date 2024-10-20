using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonFadeIn : MonoBehaviour
{
    public Animator DarkSequence;
    // Start is called before the first frame update
    void Start()
    {
        //Shows the mouse again
        Cursor.visible = true;
        //Unlocks Cursors
        Cursor.lockState = CursorLockMode.None;
        DarkSequence.GetComponent<Animator>().Play("DarkSequence1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
