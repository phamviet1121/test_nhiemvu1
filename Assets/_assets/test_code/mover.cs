using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    float speed = 5f;
    public Transform camara;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveX, moveY, 0f);
        transform.Translate(moveDirection * speed * Time.deltaTime);
        camara.position =new Vector3(transform.position.x,transform.position.y+3,-10);
    }
}
