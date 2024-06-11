
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonUpgradeLevelFoodController : MonoBehaviour
{
    List<Dishes> dishes;

    float coinsMinimumToUpgrade = 10f;
    [SerializeField] private TMP_Text textFood0;
    [SerializeField] private TMP_Text textFood1;
    [SerializeField] private TMP_Text textFood2;
    [SerializeField] private TMP_Text textFood3;
    [SerializeField] private TMP_Text textFood4;
    [SerializeField] private TMP_Text textFood5;
    // [SerializeField] private Image coins;
    [SerializeField] private Sprite dishSprite;
    public static bool isOn = false;
 


    void Start()
    {
        
        textFood0.text = "" + gameController.instance.DishesList[0].price;
        textFood1.text = "" + gameController.instance.DishesList[1].price;
        textFood2.text = "" + gameController.instance.DishesList[2].price;
        textFood3.text = gameController.instance.DishesList[3].isUnLock ? "" + gameController.instance.DishesList[3].price.ToString() : "Lock";
        textFood4.text = gameController.instance.DishesList[4].isUnLock ? "" + gameController.instance.DishesList[4].price.ToString() : "Lock";
        textFood5.text = gameController.instance.DishesList[5].isUnLock ? "" + gameController.instance.DishesList[5].price.ToString() : "Lock";



    }
    void Update()
    {
        textFood0.text = "" + gameController.instance.DishesList[0].price;
        textFood1.text = "" + gameController.instance.DishesList[1].price;
        textFood2.text = "" + gameController.instance.DishesList[2].price;
        textFood3.text = gameController.instance.DishesList[3].isUnLock ? "" + gameController.instance.DishesList[3].price.ToString() : "Lock";
        textFood4.text = gameController.instance.DishesList[4].isUnLock ? "" + gameController.instance.DishesList[4].price.ToString() : "Lock";
        textFood5.text = gameController.instance.DishesList[5].isUnLock ? "" + gameController.instance.DishesList[5].price.ToString() : "Lock";

    }
    private void OnMouseDown()
    {




        int idFood = int.Parse(gameObject.name.Replace("UpBtn", ""));
        

        if (!gameController.instance.DishesList[idFood].isUnLock && gameController.instance.coinsRestaurant > 200)
        {
            
            gameController.instance.DishesList[idFood].isUnLock = true;


        }

        if (!isOn && gameController.instance.DishesList[idFood].isUnLock && gameController.instance.DishesList[idFood].level<20)
        {
            //isOn = true;

            if (gameController.instance.coinsRestaurant > gameController.instance.DishesList[idFood].price)
            {
             

                gameController.instance.coinsRestaurant = gameController.instance.coinsRestaurant - gameController.instance.DishesList[idFood].price;
                gameController.instance.DishesList[idFood].level += 1;
                gameController.instance.DishesList[idFood].price += 20;

                coinsMinimumToUpgrade = gameController.instance.DishesList[idFood].price + 20;
            }
         
          




        }
        textFood0.text = "" + gameController.instance.DishesList[0].price;
        textFood1.text = "" + gameController.instance.DishesList[1].price;
        textFood2.text = "" + gameController.instance.DishesList[2].price;
        textFood3.text = gameController.instance.DishesList[3].isUnLock ? "" + gameController.instance.DishesList[3].price.ToString() : "Lock";
        textFood4.text = gameController.instance.DishesList[4].isUnLock ? "" + gameController.instance.DishesList[4].price.ToString() : "Lock";
        textFood5.text = gameController.instance.DishesList[5].isUnLock ? "" + gameController.instance.DishesList[5].price.ToString() : "Lock";
    }
}
