using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StalkerBehaviour : MonoBehaviour
{
    #region Variables
    [SerializeField] private float timeRemaining;
    [SerializeField] private List<Vector3> stalkerPositions = new();
    [SerializeField] private float deathtimeRemaining; //Time before Stalker kills player

    private bool AllWindowsClosed;
    private bool StalkerAtWindow;
    private bool EndOfStageOne;
    #endregion

    #region Unity Methods
    private void Start(){
        AllWindowsClosed = false;
        StalkerAtWindow = false;
        EndOfStageOne = false;
    }

    // subscribing to events
    private void OnEnable(){
        ClosedWindowCounter.OnAllWindowsClosed += WhenWindowsClosed;
    }

    private void OnDisable(){
        ClosedWindowCounter.OnAllWindowsClosed -= WhenWindowsClosed;
    }

    private void Update(){
        if(!AllWindowsClosed){return;} // returns if the windows are not yet closed
        if(EndOfStageOne){return;}
        timeRemaining -= Time.deltaTime;
        deathtimeRemaining -= Time.deltaTime;
        if(!StalkerAtWindow){
            StartCoroutine(TeleportToRandomWindowRoutine());
        }
        if(timeRemaining <= 30){return;} //game timer for first stage ( amount of time remaining for first stage)
        EndOfStageOne = true;
        WhenWindowsClosed();
       // if(StalkerAtWindow){deathtimeRemaining -= Time.deltaTime;}
       // if(deathtimeRemaining <=0)
      //  {
            //transform.position = new Vector3(-99,-99,-99);
      ///  } //teleports stalker far away from player
    }
    #endregion

    #region Stalker Methods
    // change method name
    private void WhenWindowsClosed(){
        AllWindowsClosed = true;
        StalkerAtWindow = false;
        StopCoroutine("TeleportToRandomWindowRoutine");
    }

    private IEnumerator TeleportToRandomWindowRoutine(){
        AllWindowsClosed = false;
        StalkerAtWindow = true;
        transform.position = stalkerPositions[Random.Range(0,8)];
        //window open in StalkerWindowOpen.cs
        yield return new WaitForSeconds(10); 
        if (AllWindowsClosed == false){
            //jumpinwindowlogic   
            Debug.Log("Stalker in Building + Jumpscares");
        }
    
    }
    
   
   // {
        //Jumpscare Plays    
    
}   

#endregion

