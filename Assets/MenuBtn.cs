using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuBtn : MonoBehaviour
{
   public GameObject menu;
    public GameObject gameScreen;
    public GameObject backGround;
    public GameObject coins;
    //public GameObject informationFoodScreen;
   
   
  
    public void OnMouseDown()
    {
        menu.SetActive(true);
        gameScreen.SetActive(false);
        coins.SetActive(true);
      //  informationFoodScreen.SetActive(false);
        backGround.SetActive(false);
     
    }
}
