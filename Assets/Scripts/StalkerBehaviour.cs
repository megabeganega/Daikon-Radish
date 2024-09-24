using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StalkerBehaviour : MonoBehaviour
{
    #region Variables
    [SerializeField] private float firstStageTime;
    [SerializeField] private List<Vector3> stalkerPositions = new();
    [SerializeField] private float deathtimeRemaining; //Time before Stalker kills player

    public string scenename;
    private float timeRemaining;
    private bool AllWindowsClosed;
    private bool StalkerAtWindow;
    private bool EndOfStageOne;
    private bool startStageOne; // will call for the enemy to start teleporting
    #endregion

    #region Unity Methods
    private void Start(){
        timeRemaining = firstStageTime;
        AllWindowsClosed = false;
        StalkerAtWindow = false;
        EndOfStageOne = false;
    }

    // subscribing to events
    private void OnEnable(){
        ClosedWindowCounter.OnAllWindowsClosed += StartFirstStage;
    }

    private void OnDisable(){
        ClosedWindowCounter.OnAllWindowsClosed -= StartFirstStage;
    }

    private void Update(){
        if(!startStageOne){return;} // returns if all windows are not initially closed
        if(EndOfStageOne){return;}

        // while stage one is active
        timeRemaining -= Time.deltaTime;
        if(!StalkerAtWindow){
            StartCoroutine(TeleportToRandomWindowRoutine());
            return;
        }

        Debug.Log(timeRemaining);
        if(timeRemaining >= 0){return;} // returns if fisrt stage is still active
        Debug.Log(timeRemaining);
        EndFirstStage();
    }
    #endregion

    #region Stalker Methods
    private void StartFirstStage(){
        Debug.Log("Start First Stage");
        startStageOne = true;
        AllWindowsClosed = true;
        StalkerAtWindow = false;
    }

    private void WindowsClosed(){

    }

    private void EndFirstStage(){
        Debug.Log("End First Stage");
        startStageOne = false;
        EndOfStageOne = true;
        AllWindowsClosed = true;
        StalkerAtWindow = false;
        StopCoroutine("TeleportToRandomWindowRoutine");
    }

    private IEnumerator TeleportToRandomWindowRoutine(){
        AllWindowsClosed = false;
        StalkerAtWindow = true;
        transform.position = stalkerPositions[Random.Range(0,8)];
        //window open in StalkerWindowOpen.cs
        yield return new WaitForSeconds(5); 
        Debug.Log(AllWindowsClosed);
        if(AllWindowsClosed == false){
            //jumpinwindowlogic   
            Debug.Log("Stalker in Building + Jumpscares");
            //Loads Jumpscare Scene
            SceneManager.LoadScene(scenename);
        }
    
    }
    
   
   // {
        //Jumpscare Plays    
    
}   

#endregion

