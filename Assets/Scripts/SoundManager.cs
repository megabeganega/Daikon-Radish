using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    #region Variables
    [SerializeField] Slider volumeSlider;
    #endregion
    // Start is called before the first frame update
    #region Methods
    void Start(){
        //set music volume to 100% with no previous data
        if(!PlayerPrefs.HasKey("Volume")){
            PlayerPrefs.SetFloat("Volume", 1);
            Load(); 
        }
        else{Load();}
    }

    public void ChangeVolume(){
        //sets volume to slider ui
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load(){
        //set volume slider = volume "Key Name"
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    private void Save(){
        //saves player volume preference
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
    #endregion
}