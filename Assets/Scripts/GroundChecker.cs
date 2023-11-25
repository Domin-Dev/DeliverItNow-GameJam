using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    bool isGrounded;
    Transform cubeTransform;
    GroundController groundController;
    Error error;

    private void Start()
    {
        error = FindObjectOfType<Error>();
        groundController = FindObjectOfType<GroundController>().GetComponent<GroundController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Cube") || collision.CompareTag("Cart"))
        {
            isGrounded = true;

            if(cubeTransform != collision.transform && collision.transform.tag == "Cube")
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
        if (collision.transform.CompareTag("Ground") || collision.CompareTag("Cart") || collision.CompareTag("Cube"))
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

    public bool CanHit()
    {
        if (cubeTransform != null)
        {
            if (cubeTransform.GetComponent<Cube>().wateringCounter > 0)
            {
                cubeTransform.GetComponent<Cube>().Hit();
                groundController.AddWater();
                return true;
            }
            else 
            {
                error.SetError("no plant!");
                return false;
            }
        }
        else
        {
            error.SetError("no plant!");
            return false;
        }
    }
    public bool CanGrow()
    {
        if (cubeTransform != null)
        {
            Cube cube = cubeTransform.GetComponent<Cube>();
            if (cube.wateringCounter < 1 &&  cube.CanGrown() && groundController.WaterCounter > 0)
            {
                Vector2 position = cubeTransform.position;
                cube.Planting(groundController.GetSeeds());
                groundController.SubtractWater();
                return true;
            }
            else if(cube.wateringCounter > 0 && groundController.WaterCounter > 0)
            {
                cube.Watering();
                groundController.SubtractWater();
                return true;
            }
            else if(groundController.WaterCounter <= 0)
            {
                error.SetError("no water!");
            }else if(cube.wateringCounter == 0)
            {
                error.SetError("no plant!");
            }else
            {
                error.SetError("no soil!");
            }

                return false;
        }
        else
        {
            error.SetError("no plant!");
            return false;
        }

        
    }


}
