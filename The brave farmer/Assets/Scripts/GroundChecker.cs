using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    bool isGrounded;
    Transform cubeTransform;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Plant"))
        {
            isGrounded = true;

            if(cubeTransform != collision.transform)
            {
                if(cubeTransform != null)
                {
                    cubeTransform.GetComponent<SpriteRenderer>().color = Color.white;
                }
                cubeTransform = collision.transform;
                cubeTransform.GetComponent<SpriteRenderer>().color = new Color32(212,212,212,255);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ground") || collision.CompareTag("Plant"))
        {
            isGrounded = false;
            if (cubeTransform != null)
            {
                cubeTransform.GetComponent<SpriteRenderer>().color = Color.white;
            }
            cubeTransform = null;
        }
    }



    public bool IsGrounded()
    {
        return isGrounded;
    }

    public bool CanGrow()
    {
        if (cubeTransform != null && cubeTransform.parent != null && cubeTransform.parent.tag == "Cube")
        {
            Cube cube = cubeTransform.GetComponent<Cube>();
            if (cube.wateringCounter < 1 &&  cube.CanGrown())
            {
                Vector2 position = cubeTransform.position;
                cube.Planting(cubeTransform.parent.GetComponent<GroundController>().sunflower);
                return true;
            }
            else if(cube.wateringCounter > 0)
            {
                cube.Watering();
                return true;
            }
            else
                return false;
        }
        else
            return false;
        
    }


}
