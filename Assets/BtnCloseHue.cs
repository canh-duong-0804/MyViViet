using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseHue : MonoBehaviour
{
    [SerializeField] private GameObject closePopupText;
    [SerializeField] private GameObject closePopupPanel;
    [SerializeField] private GameObject opencoins;
    public static bool isOn = false;
    private void OnMouseDown()
    {
        if (!isOn)
        {
            closePopupPanel.SetActive(false);
            closePopupText.SetActive(false);
            opencoins.SetActive(true);
            FoodItems1.isOn1 = false;
            ButtonUpgradeLevelFoodController.isOn = false;
        }
    }
}
