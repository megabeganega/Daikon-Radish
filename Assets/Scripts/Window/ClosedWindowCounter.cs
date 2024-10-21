using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClosedWindowCounter : MonoBehaviour
{
    #region Variables
    public static Action OnAllWindowsClosed;

    //Can't be accessed by other classes but shows up in inspector
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private int numberOfWindows;
    public static ClosedWindowCounter current;

    private int windowsClosed;
    public int WindowsClosed => windowsClosed;
    #endregion

    #region Unity Methods
    private void Awake(){
        current = this;
    }
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
    // increases the number of windows closed (text)
    private void IncreaseCounter(){
        windowsClosed++;
        counterText.text = $"{windowsClosed}/{numberOfWindows} closed windows";

        if(windowsClosed >= numberOfWindows){
            OnAllWindowsClosed?.Invoke();
        }
    }
    public void DecreaseCounter(){
        windowsClosed--;  
        counterText.text = $"{windowsClosed}/{numberOfWindows} closed windows";
    }
    #endregion
}

