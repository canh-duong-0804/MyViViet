using UnityEngine;

public class WaiterScript : MonoBehaviour
{
    private GameObject currentOrder;

    public void TakeOrder(GameObject order)
    {
        currentOrder = order;
        // Di chuyển đến vị trí của khách hàng
        transform.position = order.transform.position;
        // Nhận order từ khách hàng, hiển thị giao diện hoặc thực hiện các hành động khác
    }
}