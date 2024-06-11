using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scaleGameBackground : MonoBehaviour
{

    [SerializeField] private CanvasScaler canvasScaler; 
    [SerializeField] private Image targetImage;  

    void Start()
    {
        SetImageSize(Screen.width, Screen.height);
    }

    void SetImageSize(float width, float height)
    {
        RectTransform rectTransform = targetImage.GetComponent<RectTransform>();
        if (rectTransform != null)
        {

            rectTransform.sizeDelta = new Vector2(width, height);

            canvasScaler.referenceResolution = new Vector2(width, height);
        }
        else
        {
            Debug.LogError("RectTransform not found on target image!");
        }
    }
}



