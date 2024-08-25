using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyCloseWindow : MonoBehaviour
{
    #region Variables
    public static Action OnWindowClosed;

    public GameObject Instruction;
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public bool Action = false;
    #endregion 

    #region instruction ui
    //hidden mesh triggers instruction ui when player enters proximity of door
    void Start()
    {
        Instruction.SetActive(false);

    }

    void OnTriggerEnter(Collider collision)
    {
        //Collider detects Player
        if (collision.transform.tag == "Player")
        {
            Instruction.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Action = false;
    }
    #endregion

    #region window close
    //Press E = Window close
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                Instruction.SetActive(false);
                AnimeObject.GetComponent<Animator>().Play("WindowClose");
                ThisTrigger.SetActive(false);
                Action = false;
                OnWindowClosed?.Invoke();
            }
        }

    }
    #endregion 
}
