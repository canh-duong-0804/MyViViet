using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonUpgradeFoodHueController : MonoBehaviour
{
    List<Dishes> dishes;

    float coinsMinimumToUpgrade = 10f;
    [SerializeField] private TMP_Text textFood0;
    [SerializeField] private TMP_Text textFood1;
    [SerializeField] private TMP_Text textFood2;
    [SerializeField] private TMP_Text textFood3;
    [SerializeField] private TMP_Text textFood4;
    
    // [SerializeField] private Image coins;
    [SerializeField] private Sprite dishSprite;
    public static bool isOn = false;
    


    void Start()
    {

        textFood0.text = "" + gameControllerHue.instance.DishesListHue[0].price;
        textFood1.text = "" + gameControllerHue.instance.DishesListHue[1].price;
        textFood2.text = gameControllerHue.instance.DishesListHue[2].isUnLock ? "" + gameControllerHue.instance.DishesListHue[2].price.ToString() : "Lock";
        textFood3.text = gameControllerHue.instance.DishesListHue[3].isUnLock ? "" + gameControllerHue.instance.DishesListHue[3].price.ToString() : "Lock";
        textFood4.text = gameControllerHue.instance.DishesListHue[4].isUnLock ? "" + gameControllerHue.instance.DishesListHue[4].price.ToString() : "Lock";
        //textFood5.text = gameControllerHue.instance.DishesListHue[5].isUnLock ? "" + gameControllerHue.instance.DishesListHue[5].price.ToString() : "Lock";



    }
    void Update()
    {
        textFood0.text = "" + gameControllerHue.instance.DishesListHue[0].price;
        textFood1.text = "" + gameControllerHue.instance.DishesListHue[1].price;
        textFood2.text = gameControllerHue.instance.DishesListHue[2].isUnLock ? "" + gameControllerHue.instance.DishesListHue[2].price.ToString() : "Lock";
        textFood3.text = gameControllerHue.instance.DishesListHue[3].isUnLock ? "" + gameControllerHue.instance.DishesListHue[3].price.ToString() : "Lock";
        textFood4.text = gameControllerHue.instance.DishesListHue[4].isUnLock ? "" + gameControllerHue.instance.DishesListHue[4].price.ToString() : "Lock";
        //textFood5.text = gameControllerHue.instance.DishesListHue[5].isUnLock ? "" + gameControllerHue.instance.DishesListHue[5].price.ToString() : "Lock";

    }
    private void OnMouseDown()
    {




        int idFood = int.Parse(gameObject.name.Replace("UpBtn", ""));


        if (!gameControllerHue.instance.DishesListHue[idFood].isUnLock && gameControllerHue.instance.coinsRestaurant > 200)

        {

            gameControllerHue.instance.DishesListHue[idFood].isUnLock = true;


        }

        if (!isOn && gameControllerHue.instance.DishesListHue[idFood].isUnLock && gameControllerHue.instance.DishesListHue[idFood].level < 20)
        {
            //isOn = true;

            if (gameControllerHue.instance.coinsRestaurant > gameControllerHue.instance.DishesListHue[idFood].price)
            {


                gameControllerHue.instance.coinsRestaurant = gameControllerHue.instance.coinsRestaurant - gameControllerHue.instance.DishesListHue[idFood].price;
                gameControllerHue.instance.DishesListHue[idFood].level += 1;
                gameControllerHue.instance.DishesListHue[idFood].price += 20;

                coinsMinimumToUpgrade = gameControllerHue.instance.DishesListHue[idFood].price + 20;
            }






        }
        textFood0.text = "" + gameControllerHue.instance.DishesListHue[0].price;
        textFood1.text = "" + gameControllerHue.instance.DishesListHue[1].price;
        textFood2.text = gameControllerHue.instance.DishesListHue[2].isUnLock ? "" + gameControllerHue.instance.DishesListHue[2].price.ToString() : "Lock";
        textFood3.text = gameControllerHue.instance.DishesListHue[3].isUnLock ? "" + gameControllerHue.instance.DishesListHue[3].price.ToString() : "Lock";
        textFood4.text = gameControllerHue.instance.DishesListHue[4].isUnLock ? "" + gameControllerHue.instance.DishesListHue[4].price.ToString() : "Lock";
       // textFood5.text = gameControllerHue.instance.DishesListHue[5].isUnLock ? "" + gameControllerHue.instance.DishesListHue[5].price.ToString() : "Lock";
    }
}
