using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    Transform player;
    Transform cart;
    Transform ground;
    CinemachineVirtualCamera cameraV;
    [SerializeField] Transform pause;

    Sounds sounds;
    private void Start()
    {
        sounds = FindObjectOfType<Sounds>();
        ground = FindObjectOfType<GroundController>().transform;
        cameraV = transform.GetComponent<CinemachineVirtualCamera>();
        player = FindObjectOfType<PlayerMovement>().transform;
        cart = FindObjectOfType<Cart>().transform;
        isPlayer = true;
    }

    bool isPlayer;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            sounds.PlaySound(2);
            Switch();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
           
            sounds.PlaySound(2);
            if (pause.gameObject.activeSelf)
            {
                pause.gameObject.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
            }
            else
            {
                pause.gameObject.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
            }

        }
    }

    public void Switch()
    {
        cart.GetComponent<Cart>().Switch();
        isPlayer = !isPlayer;
        if (isPlayer)
        {
            player.gameObject.SetActive(true);

            for (int i = 0; i <ground.childCount; i++)
            {
                ground.GetChild(i).GetComponent<Cube>().SetCollider(false);
            }
            cameraV.Follow = player;
            player.GetComponent<PlayerMovement>().ResetPosition();
        }
        else
        {
            cameraV.Follow = cart;
            for (int i = 0; i < ground.childCount; i++)
            {
                ground.GetChild(i).GetComponent<Cube>().SetCollider(true);
            }
            player.gameObject.SetActive(false);

        }

    }

}
