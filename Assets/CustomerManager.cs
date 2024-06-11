using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public GameObject conkhach1_front;
    public GameObject conkhach1_sit;

    public void SetActiveFront(bool isActive)
    {
        conkhach1_front.SetActive(isActive);
    }

    public void SetActiveSit(bool isActive)
    {
        conkhach1_sit.SetActive(isActive);
    }

    public void SwitchStates()
    {
        bool isFrontActive = conkhach1_front.activeSelf;
        conkhach1_front.SetActive(!isFrontActive);
        conkhach1_sit.SetActive(isFrontActive);
    }
}
