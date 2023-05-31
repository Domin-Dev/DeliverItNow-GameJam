using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] bool canGrown;
    public int wateringCounter = 0;
    public Plant plant;

    List<Transform> plantList = new List<Transform>();


    public void Planting(Plant plant)
    {
        this.plant = plant;
        wateringCounter++;
        plantList.Add(Instantiate(plant.seedling,transform.position + new Vector3(0,0.16F) ,Quaternion.identity,transform).transform);
        canGrown = false;
    }
    public void Watering()
    {
        if (wateringCounter == 1)
        {
            Destroy(plantList[0].gameObject);
            plantList[0] =Instantiate(plant.plant, transform.position + new Vector3(0, 0.16F), Quaternion.identity, transform).transform;
        }else
        {
            plantList.Add(Instantiate(plant.stem, plantList[0].position, Quaternion.identity, transform).transform);
            plantList[0].position += new Vector3(0, 0.16F);
        }


        wateringCounter++;


    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && plantList.Count > 0)
        {
            plantList[0].GetComponent<PolygonCollider2D>().enabled = true;
        }
    }
    public bool CanGrown()
    {
        return canGrown;
    }
}

