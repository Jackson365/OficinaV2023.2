using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text healthText;
    public static GameController instance;

    public GameObject gameOverObj;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int value)
    {
        healthText.text = "x "  + value.ToString();
    }

    public void GameOver()
    {
        gameOverObj.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("boss1");
    }
}
