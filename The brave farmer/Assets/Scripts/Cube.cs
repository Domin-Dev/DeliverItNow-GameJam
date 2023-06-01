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
        plantList.Add(Instantiate(plant.plant1,transform.position + new Vector3(0,0.16F) ,Quaternion.identity,transform).transform);
        canGrown = false;
        Instantiate(transform.parent.GetComponent<GroundController>().GetWaterParticle(), transform.position + new Vector3(0, 0.16f,0), Quaternion.identity,transform);
    }
    public void Watering()
    {
        wateringCounter++;

        if(wateringCounter % 2  == 0)
        {
            Vector3 position = plantList[0].position;
            Destroy(plantList[0].gameObject);
            plantList[0] = Instantiate(plant.plant2, position, Quaternion.identity, transform).transform;
        }else
        {
            Vector3 position = plantList[0].position + new Vector3(0,0.16f,0);
            Destroy(plantList[0].gameObject);
            plantList[0] = Instantiate(plant.plant1, position, Quaternion.identity, transform).transform;
            plantList.Add(Instantiate(plant.stem, position - new Vector3(0, 0.16f, 0), Quaternion.identity, transform).transform);

        }
        Instantiate(transform.parent.GetComponent<GroundController>().GetWaterParticle(), transform.position + new Vector3(0, 0.16f,0), Quaternion.identity,transform);

    }

    public void Hit()
    {
        wateringCounter--;

        if (wateringCounter > 1)
        {
            if (wateringCounter % 2 == 0)
            {
                Vector3 position = plantList[0].position - new Vector3(0,0.16f,0);
                Destroy(plantList[0].gameObject);
                plantList[0] = Instantiate(plant.plant2, position, Quaternion.identity, transform).transform;
                GameObject obj = plantList[plantList.Count - 1].gameObject;
                plantList.RemoveAt(plantList.Count - 1);
                Destroy(obj);
               
            }
            else
            {
                Vector3 position = plantList[0].position;
                Destroy(plantList[0].gameObject);
                plantList[0] = Instantiate(plant.plant1, position, Quaternion.identity, transform).transform;         

            }
        }else if(wateringCounter >= 0)
        {
            if(wateringCounter == 0)
            {
                Destroy(plantList[0].gameObject);
                plantList.Clear();
                canGrown = true;
            }else if(wateringCounter == 1)
            {
                Vector3 position = plantList[0].position;
                Destroy(plantList[0].gameObject);
                plantList[0] = Instantiate(plant.plant1, position, Quaternion.identity, transform).transform;
            }
                 
        }


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

