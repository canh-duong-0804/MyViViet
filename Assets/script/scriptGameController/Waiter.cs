using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiter : MonoBehaviour
{
    private Transform goToKitchen;
   
    [Range(0f, 5f)] public float speed = 4f;

    public static Waiter instance;
    public string testWaiter;   
    private void Start()
    {
       instance = this;
    }


    private void Update()
    {
        if (testWaiter.Equals("MoveWaiterToTable"))
        {
            MoveWaiterToTable();
           
        }
        
    }

   
   
    public void SetFreeSpot1(Transform transform)
    {
        goToKitchen = transform;
        MoveWaiterToTable();
      

    }
    private void MoveWaiterToTable()
    {

       
       gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, goToKitchen.transform.position, 2f * Time.deltaTime);
    }
}
