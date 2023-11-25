using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] Transform transform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cart"))
        {
            Cursor.visible = true;
            FindObjectOfType<Sounds>().PlaySound(4);
            transform.gameObject.SetActive(true);
            if((SceneManager.GetActiveScene().buildIndex - 1) == GameController.gameController.Level)
            {
              if(GameController.gameController.Level < 12)  GameController.gameController.Level++;
            }
            Time.timeScale = 0;

        }
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        if (GameController.gameController.Level != SceneManager.GetActiveScene().buildIndex - 1) SceneManager.LoadScene(GameController.gameController.Level + 1);
        else if (SceneManager.GetActiveScene().buildIndex - 1 <= GameController.gameController.Level) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene(0);

    }

}
