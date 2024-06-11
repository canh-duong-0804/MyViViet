using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public Transform freespot;

    [Range(0f, 5f)] public float speed = 4f;


   



    public void SetFreeSpot(Transform tr)
    {
        freespot = tr;
       // Debug.Log("check customer: "+gameObject.name);

    }
    //private bool avoidStatusLoop = false;
   
    void Start()
    {




    }
    void Update()
    {
        MoveCustomerToTable();

    }

    private void MoveCustomerToTable()
    {
        //avoidStatusLoop = true;
        
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,freespot.transform.position, 4f * Time.deltaTime);

      

    }



  

    
}
