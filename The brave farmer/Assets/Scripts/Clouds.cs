using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField] Sprite cloudSprite;
    [SerializeField] float cloudSpeed;
    Transform playerTransform;
    List<Transform> cloudList = new List<Transform>();


    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        transform.position = new Vector3(playerTransform.position.x + 10, transform.position.y, 0);
        MakeClouds();
    }


    
    private void MakeClouds()
    {
        float x = transform.position.x;
        while (Mathf.Abs(playerTransform.position.x - x) < 15)
        {
            Transform obj = new GameObject("Clouds", typeof(SpriteRenderer)).transform;
            obj.SetParent(transform);
            obj.GetComponent<SpriteRenderer>().sprite = cloudSprite;
            obj.transform.position = new Vector3(x,Random.RandomRange(transform.position.y - 0.2f, transform.position.y), transform.position.z);
            x = x - 2.5f;
            cloudList.Add(obj);
        }

    }

    private void Update()
    {
        foreach (Transform item in cloudList)
        {
            item.position += new Vector3(-1 *cloudSpeed * Time.deltaTime, 0, 0);
            if(item.position.x < -15)
            {
                item.position = new Vector3(10, item.position.y, 0);
            }
        }
       
    }

}
