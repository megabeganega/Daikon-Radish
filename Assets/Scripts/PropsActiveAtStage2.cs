using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsActiveAtStage2 : MonoBehaviour
{
    #region Variables
    public StalkerBehaviour stalkerbehaviour;
    #endregion

    void Update(){
        //Trigger is enabled only when first stage ends, until then its disabled
        if(!stalkerbehaviour.EndOfStageOne){
            GetComponent<BoxCollider> ().isTrigger = false;
        }
        if(stalkerbehaviour.EndOfStageOne){
            GetComponent<BoxCollider> ().isTrigger = true;
        }
    }
}
