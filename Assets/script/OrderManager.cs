using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField]
    private GameObject customer;

    [SerializeField]
    private GameObject waiter;

    [SerializeField]
    private GameObject kitchen;

    [SerializeField]
    private GameObject orderPrefab;

    private bool orderPlaced = false;
    private GameObject currentOrder;

    void Update()
    {
        if (!orderPlaced && Vector3.Distance(customer.transform.position, transform.position) < 1.5f)
        {
            PlaceOrder();
        }

        if (orderPlaced && Vector3.Distance(waiter.transform.position, currentOrder.transform.position) > 0.1f)
        {
            MoveWaiterToOrder();
        }
    }

    void PlaceOrder()
    {
        currentOrder = Instantiate(orderPrefab, customer.transform.position, Quaternion.identity);
        orderPlaced = true;

        WaiterScript waiterScript = waiter.GetComponent<WaiterScript>();
        if (waiterScript != null)
        {
            waiterScript.TakeOrder(currentOrder);
        }
    }

    void MoveWaiterToOrder()
    {
        waiter.transform.position = Vector3.MoveTowards(waiter.transform.position, currentOrder.transform.position, 5f * Time.deltaTime);

        if (Vector3.Distance(waiter.transform.position, currentOrder.transform.position) < 0.1f)
        {
            SendOrderToKitchen();
        }
    }

    void SendOrderToKitchen()
    {
        currentOrder.transform.SetParent(kitchen.transform); // Di chuy?n order vào nhà b?p
        // X? lý order t?i nhà b?p, ví d?: thông báo cho nhà b?p x? lý order
    }
}



