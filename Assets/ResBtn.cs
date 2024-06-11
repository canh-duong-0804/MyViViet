using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResBtn : MonoBehaviour
{
    [SerializeField] private GameObject upgradeScreen;
    [SerializeField] private GameObject resScreen;
    [SerializeField] private GameObject resBackGround; 
    [SerializeField] private GameObject coinsUpgrade; 
  //  [SerializeField]public GameObject informationFoodScreen;


    private void OnMouseDown()
    {
        upgradeScreen.SetActive(false);
        resScreen.SetActive(true);
    //    informationFoodScreen.SetActive(false);
        resBackGround.SetActive(true);
        coinsUpgrade.SetActive(false);
     
    }
}
