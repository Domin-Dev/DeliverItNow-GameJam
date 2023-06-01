using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField]  Plant sunflower;
    [SerializeField]  Plant tomatoes;


    [SerializeField] GameObject waterParticle;

    public Plant GetSunFlower()
    {
        return tomatoes;
    }
    
    public GameObject GetWaterParticle()
    {
        return waterParticle;
    }




}
