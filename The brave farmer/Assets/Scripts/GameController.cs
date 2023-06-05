using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    static public GameController gameController;

    public int Level;

    private void Start()
    {
        if(gameController != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Level = 1;
            gameController = this;
        }
        // Cursor.visible = false;

        DontDestroyOnLoad(this.gameObject);
    }





}
