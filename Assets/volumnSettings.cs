using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumnSettings : MonoBehaviour
{
   
    [SerializeField] private Slider musicSLider;


    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolumn"))
        {
            PlayerPrefs.SetFloat("musicVolumn",1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void Load()
    {
        musicSLider.value = PlayerPrefs.GetFloat("musicVolumn");
    }
    public void ChangeVolumn()
    {AudioListener.volume = musicSLider.value;  

    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolumn",musicSLider.value);
    }
}
