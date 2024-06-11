using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scaleBackground : MonoBehaviour
{
    [SerializeField] private CanvasScaler canvasScaler;  // Tham chiếu đến Canvas chứa Image
    [SerializeField] private Image targetImage;  // Tham chiếu đến Image cần thay đổi kích thước

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
            
            canvasScaler.referenceResolution = new Vector2 (width, height);
        }
        else
        {
            Debug.LogError("RectTransform not found on target image!");
        }
        
    }
}
