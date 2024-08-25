using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClosedWindowCounter : MonoBehaviour
{
    #region Variables
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private int numberOfWindows;

    private int windowsClosed;
    #endregion

    #region Unity Methods
    private void Start(){
        windowsClosed = -1;
        IncreaseCounter();
    }

    // subscribes to event
    private void OnEnable(){
        PressKeyCloseWindow.OnWindowClosed += IncreaseCounter;
    }

    // unsubscribes to event
    private void OnDisable(){
        PressKeyCloseWindow.OnWindowClosed -= IncreaseCounter;
    }
    #endregion

    #region Counter Methods
    // increases the number of windows closed text
    private void IncreaseCounter(){
        windowsClosed++;
        counterText.text = $"{windowsClosed}/{numberOfWindows} closed windows";
    }
    #endregion
}
