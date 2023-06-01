using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cart"))
        {
            collision.transform.parent.GetChild(1).GetComponent<WheelJoint2D>().useMotor = true;
            collision.transform.parent.GetChild(2).GetComponent<WheelJoint2D>().useMotor = true;
        }
    }
}
