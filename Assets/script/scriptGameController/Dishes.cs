using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[Serializable]
[System.Serializable]
public class Dishes 
{
    public int id ;
    public string dishName;
    public int price;
    public int level;
    public int priceToUpgrade;
    public Sprite dishSprite;
    public string story;
    public float processFood;
    public bool isUnLock;
}
