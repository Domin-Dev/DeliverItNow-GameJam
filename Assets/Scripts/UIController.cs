using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    Sounds sounds;
    private void Start()
    {
        sounds = FindObjectOfType<Sounds>();
    }

    public void ChangeScene(int index)
    {
        Time.timeScale = 1;
        sounds.PlaySound(2);
        SceneManager.LoadScene(index);

    }
    
    public void Restart()
    {       
        Time.timeScale = 1;
        sounds.PlaySound(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        sounds.PlaySound(2);
        Application.Quit();
    }
}
