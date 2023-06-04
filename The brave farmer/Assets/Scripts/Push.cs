using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{

    bool addForce;

    Rigidbody2D wheel1;
    Rigidbody2D wheel2;
    Transform transformCart;
    private void Start()
    {
        transformCart = GameObject.FindGameObjectWithTag("Cart").transform;
        wheel1 = transformCart.parent.GetChild(1).GetComponent<Rigidbody2D>();
        wheel2 = transformCart.parent.GetChild(2).GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cart"))
        {
            addForce = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cart"))
        {
            addForce = false;
        }
    }

    private void FixedUpdate()
    {
        if(addForce)
        {
            int x;
            if (wheel1.velocity.x < 0) x = -1;
            else x = 1;
            
  //          transformCart.parent.GetComponent<Rigidbody2D>().AddForce(transformCart.parent.GetComponent<Rigidbody2D>().velocity.normalized * 1.5f, ForceMode2D.Impulse);
               wheel1.AddForce(new Vector2(0.4f, wheel1.velocity.y), ForceMode2D.Impulse);
               wheel2.AddForce(new Vector2(0.4f, wheel2.velocity.y), ForceMode2D.Impulse);
        }
    }

    
}
