using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyCloseWindow : MonoBehaviour
{
    #region Variables
    // event
    public static Action OnWindowClosed;
    public static bool isAction;

    public GameObject Instruction;
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public bool Action = false;
    public static bool AllWindowsClosed = true;
    bool wasinvoked;
    //[SerializeField] GameObject TriggerWindowOpen;
    public StalkerWindowOpen stalkerWindowOpen;

    #endregion 

    #region Unity Method
    //hidden mesh triggers instruction ui when player enters proximity of door
    void Start()
    {
        Instruction.SetActive(false);
        Debug.Log(stalkerWindowOpen.WindowOpened);
    }

    void OnTriggerEnter(Collider collision)
    {
        //Collider detects Player
        if (collision.transform.tag == "Player")
        {
            Instruction.SetActive(true);
            Action = true;
            isAction = false;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Action = false;
        isAction = false;
    }
    
    void TheWindowCloses(){
        Instruction.SetActive(false);
        AnimeObject.GetComponent<Animator>().Play("WindowClose");
        ThisTrigger.SetActive(true);
        Action = false;
        stalkerWindowOpen.WindowOpened = false; 
        
    }
    
    void TheWindowCloses2(){
        if(!wasinvoked){
        OnWindowClosed?.Invoke(); 
        wasinvoked = true;}
        //If player closes window stalker opened after all windows closed, closedwindowcounter adds by 1
        if(stalkerWindowOpen.WindowOpened){
           OnWindowClosed?.Invoke();
        }
        
    }
    #endregion

    #region window close
    //Press E = Window close
  //  void WindowOpened(){
    //    StalkerWindowOpen.WindowOpened = false;
    //}
    #endregion window close
    #region CloseWindow 
    void Update()
    {
        
    
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
               // Debug.Log(stalkerWindowOpen.WindowOpened);
                TheWindowCloses2();
                TheWindowCloses();
                isAction = true;
                Debug.Log("Even Bigger");
                return;
                //StalkerWindowOpen.WindowOpened = false;}
                }
                
    }
            }
    //While action == true WindowOpened();
#endregion 
}

    

