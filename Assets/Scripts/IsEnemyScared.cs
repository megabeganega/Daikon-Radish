using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemyScared : MonoBehaviour
{
    public static bool isEnemyScared;
    
    void Start(){
        isEnemyScared = false;
    }

    void Update(){
        if(!StalkerBehaviour.stageonecommence){return;}
        if(PressKeyCloseWindow.isAction == true){
            Debug.Log("ST JOHNS");
            isEnemyScared = true;
            }
    }
}
