using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficChange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cart"))
        {
            JointMotor2D jointMotor2D = new JointMotor2D();
            WheelJoint2D wheelJoint2D = collision.transform.parent.GetChild(1).GetComponent<WheelJoint2D>();
            jointMotor2D.motorSpeed = - wheelJoint2D.motor.motorSpeed;
            jointMotor2D.maxMotorTorque = 10000;

            wheelJoint2D.motor = jointMotor2D;
            wheelJoint2D = collision.transform.parent.GetChild(2).GetComponent<WheelJoint2D>();
            wheelJoint2D.motor = jointMotor2D;

            collision.transform.parent.GetChild(3).GetComponent<SpriteRenderer>().flipX = (jointMotor2D.motorSpeed < 0);

        }
    }
}
