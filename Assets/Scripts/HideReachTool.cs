using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideReachTool : MonoBehaviour
{
    #region Variables
    public GameObject ReachTool;
    public GameObject GunInHand;
    #endregion
    
    #region Update
    void Update()
    {
        //If Gun is in playeres hand, reach tool disappears
        if (GunInHand.activeSelf == true)
        {
            ReachTool.SetActive(false);
        }
    }
    #endregion
}
