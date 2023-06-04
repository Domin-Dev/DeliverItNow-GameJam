using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    Vector3 startPosition;
    Rigidbody2D rigidbody2D;

    Transform wheel1;
    Transform wheel2;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        wheel1 = transform.GetChild(1);
        wheel2 = transform.GetChild(2);
    }

    public void Change()
    {
        JointMotor2D jointMotor2D = new JointMotor2D();
        WheelJoint2D wheelJoint2D = transform.GetChild(1).GetComponent<WheelJoint2D>();
        jointMotor2D.motorSpeed = -wheelJoint2D.motor.motorSpeed;
        jointMotor2D.maxMotorTorque = 10000;

        wheelJoint2D.motor = jointMotor2D;
        wheelJoint2D = transform.GetChild(2).GetComponent<WheelJoint2D>();
        wheelJoint2D.motor = jointMotor2D;

        transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = (jointMotor2D.motorSpeed < 0);

    }

    public void Switch()
    {
        wheel1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        wheel2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        rigidbody2D.velocity = Vector2.zero;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position = startPosition;

        bool isTrue = !wheel1.GetComponent<WheelJoint2D>().useMotor;
        wheel1.GetComponent<WheelJoint2D>().useMotor = isTrue;
        wheel2.GetComponent<WheelJoint2D>().useMotor = isTrue;
        if(isTrue)
        {
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            rigidbody2D.bodyType = RigidbodyType2D.Static;
        }
    }

    void Update()
    {

       if(transform.position.y < -2 || transform.position.y > 20)
        {
            FindObjectOfType<CameraController>().Switch();
        }

       if ( Mathf.Abs(transform.rotation.z) > 0.8f)
       {
            Debug.Log(transform.rotation.z);

   //         float z = Mathf.Lerp(transform.localRotation.z, 0, Time.deltaTime * 80);
 //          transform.rotation = new Quaternion(0, 0, z, 0);
       }
    }
}
