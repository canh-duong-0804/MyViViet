using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closePanel : MonoBehaviour
{
    [SerializeField] private GameObject panelText;
   [SerializeField] private GameObject openbuttonpopUp;
   [SerializeField] private GameObject openClose;
    private void OnMouseDown()
    {
        panelText.SetActive(false);
        openbuttonpopUp.SetActive(true);
        btnClose.isOn = false;
        openClose.SetActive(true);
       //popUp.SetActive(true);


    }
}
