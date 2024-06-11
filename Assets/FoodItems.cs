using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class FoodItems : MonoBehaviour
{

    [SerializeField] GameObject Info;
    [SerializeField] GameObject Info1;
    [SerializeField] Sprite FoodPic;
    [SerializeField] SpriteRenderer FoodRenderer;
    [SerializeField] TextMeshProUGUI textFood0;
    
    [SerializeField] GameObject textMoTa;
    [SerializeField] GameObject textNguyenLieu;
    [SerializeField] GameObject textCheBien;
   [SerializeField] GameObject popUp;
   [SerializeField] GameObject HiddenObjectButton;
   [SerializeField] GameObject HidenCoins;
    [SerializeField] ScrollRect contentScroll;
   [SerializeField] GameObject hiddenButtonClose;
  

    private TextMeshProUGUI mota, nguyenlieu, chebien;
    private Transform motaT, nguyenlieuT, chebienT;


   public static FoodItems instance;
   public static bool isOn = false;

    private string id;
    private void OnMouseDown()
    {
        string foodID = gameObject.name;
        int foodIDInt;

        
        if (int.TryParse(foodID, out foodIDInt))
        {
            Debug.Log("Parsed successfully: " + foodIDInt);
        }
        if (!isOn && gameController.instance.DishesList[foodIDInt].isUnLock)
        {
            mota= textMoTa.GetComponent<TextMeshProUGUI>();
            nguyenlieu= textNguyenLieu.GetComponent<TextMeshProUGUI>();
            chebien= textCheBien.GetComponent<TextMeshProUGUI>();
            motaT= textMoTa.GetComponent<Transform>();
            nguyenlieuT= textNguyenLieu.gameObject.GetComponent<Transform>();
            chebienT= textCheBien.gameObject.GetComponent<Transform>();
            HidenCoins.SetActive(false);
            isOn = true;
            Info.SetActive(true);
            Info1.SetActive(true);
            
            id = foodID;
            Debug.Log(foodID);
            //SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            Sprite food = Resources.Load<Sprite>("FoodsDish/" + foodID);
            textFood0.text = Resources.Load<TextAsset>("text/" + foodID).text;

            var temp = Resources.Load<TextAsset>("text/" + foodID + "-1");
            mota.text = temp.text;

            nguyenlieu.text = Resources.Load<TextAsset>("text/" + foodID + "-2").text;
            chebien.text = Resources.Load<TextAsset>("text/" + foodID + "-3").text;
            mota.enabled = false;
            chebien.enabled = false;
            nguyenlieu.enabled = false;



            FoodRenderer.sprite = food;
        }
       
}
    public void getInfo(int idtext)
    {
       Debug.Log(id+ " " +gameObject.name);
       Debug.Log(id+ "asdasf " +gameObject.name);
        btnClose.isOn = true;
        if(gameObject.name.Equals(id))
        {
            if (idtext == 1)
            {
               hiddenButtonClose.SetActive(false);
                HiddenObjectButton.SetActive(false);
                popUp.SetActive(true);
                Debug.Log("text1");
                contentScroll.content = (RectTransform)motaT;

                mota.enabled = true;
                nguyenlieu.enabled = false;
                chebien.enabled = false;

            }
            else if (idtext == 2)
            {
               hiddenButtonClose.SetActive(false);
                popUp.SetActive(true);
                HiddenObjectButton.SetActive(false);
                Debug.Log("text2");
                contentScroll.content = (RectTransform)nguyenlieuT;
                mota.enabled = false;
                nguyenlieu.enabled = true;
                chebien.enabled = false;
            }
            else
            {
               hiddenButtonClose.SetActive(false);
                popUp.SetActive(true);
                HiddenObjectButton.SetActive(false);
                contentScroll.content = (RectTransform)chebienT;
                Debug.Log("text3");
                mota.enabled = false;
                nguyenlieu.enabled = false;
                chebien.enabled = true;
            }
        }
          
        

    }
   
    

}
