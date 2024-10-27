using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : MonoBehaviour
{
    #region Method
    public void Change(){
    //Changes fullscreen setting
    Screen.fullScreen = !Screen.fullScreen;
    }
    #endregion
}
