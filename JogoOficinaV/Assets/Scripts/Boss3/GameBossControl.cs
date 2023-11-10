using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBossControl : MonoBehaviour
{
    public Text healthTexto;

    public static GameBossControl instance;
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
        healthTexto.text = "x" + value.ToString();
    }
}
