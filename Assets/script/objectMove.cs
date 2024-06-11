using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMove : MonoBehaviour
{


    [SerializeField]
    float moveSpeed = 5f;
    Rigidbody2D rb;
    Touch touch;
    Vector3 touchPosition, whereToMove;
    bool isMoving = false;
    float previousDistanceToTouchPos, currentDistanceToTouchPos;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Here");
        if (isMoving)
        {
            Debug.Log("Here1");
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        }
        if (Input.touchCount > 0)
        {
            Debug.Log("Here2");
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Here3");
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                touchPosition = Camera.main.ScreenToViewportPoint(touch.position);
                touchPosition.z = 0;
                whereToMove = (touchPosition - transform.position).normalized;
                rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);

            }
        }
        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            Debug.Log("Here5");
            isMoving = false;
            rb.velocity = Vector2.zero;

        }
        if (isMoving)
        {
            Debug.Log("Here6");
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        }

    }
}