using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{


    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(GameController.gameController.Level < i + 1)
            {
                transform.GetChild(i).GetComponent<Button>().interactable = false;
            }
            else
            {

                int x = i;
                transform.GetChild(i).GetComponent<Button>().interactable = true;
                transform.GetChild(i).GetComponent<Button>().onClick.AddListener(() => { SceneManager.LoadScene(x + 2); });
            }
            transform.GetChild(i).GetChild(0).GetComponent<Text>().text = (i + 1).ToString();

        }
    }
}
