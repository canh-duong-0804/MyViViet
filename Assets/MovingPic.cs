using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingPic : MonoBehaviour
{
    public float speed = 3f;
    private float elapsedTime = 0f;
    public float sceneChangeDelay = 6f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        elapsedTime += Time.deltaTime;

        
        if (elapsedTime >= sceneChangeDelay)
        {
          
            SceneManager.LoadScene("SampleScene");
        }

    }
}
