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
    public bool EndOfStageOne;
    private bool startStageOne; // will call for the enemy to start teleporting
    public static bool stageonecommence;
    [SerializeField] private Animator FadeInOut;
    public GameObject KeyInstructionsAndLocations;

    #endregion

    #region Unity Methods
    private void Start(){
        timeRemaining = firstStageTime;
        AllWindowsClosed = false;
        StalkerAtWindow = false;
        EndOfStageOne = false;
        stageonecommence = false;
        KeyInstructionsAndLocations.SetActive(false);
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
        // returns if fisrt stage is still active
        if(timeRemaining >= 0){return;} 
        EndFirstStage();
    }
    #endregion

    #region Stalker Methods
    private void StartFirstStage(){
        startStageOne = true;
        AllWindowsClosed = true;
        StalkerAtWindow = false;
        stageonecommence = true;
    }


    private void EndFirstStage(){
        startStageOne = false;
        EndOfStageOne = true;
        AllWindowsClosed = true;
        StalkerAtWindow = false;
        StopCoroutine("TeleportToRandomWindowRoutine");
        stageonecommence = false;
        StartCoroutine(KeyInstructions());
    }

    private IEnumerator TeleportToRandomWindowRoutine(){
        StalkerAtWindow = true;
        yield return new WaitForSeconds(10);
        AllWindowsClosed = false;   
        //Prevents error where Player can't close window as enemy Teleported to the same place
        transform.position = new Vector3(1000,10000,1000);
        //So Tp2 doesn't overide Tp1
        yield return new WaitForSeconds(1);
        transform.position = stalkerPositions[Random.Range(0,8)];
        //window open in StalkerWindowOpen.cs
        yield return new WaitForSeconds(10);
        if(AllWindowsClosed == true){
            //resets functions
            yield break;
        }
            //jumpinwindowlogic   
            //Loads Jumpscare Scene
            SceneManager.LoadScene(scenename);
        }

    private IEnumerator KeyInstructions(){
        //Waitisi 10 Seconds
        yield return new WaitForSeconds(10);
        KeyInstructionsAndLocations.SetActive(true);
    }
}
#endregion

