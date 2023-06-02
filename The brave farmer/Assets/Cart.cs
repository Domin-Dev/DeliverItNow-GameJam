using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    Vector3 startPosition;
    Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void Update()
    {
       if(transform.position.y < -2 || transform.position.y > 20)
        {
            transform.GetChild(1).GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.GetChild(2).GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            rigidbody2D.velocity = Vector2.zero;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.position = startPosition;

        }
    }
}
