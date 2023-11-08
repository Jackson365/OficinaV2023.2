using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamControl : MonoBehaviour
{
    public Text healthText;
    public static GamControl instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    void Update()
    {
        
    }
    // Update is called once per frame
    public void UpdateLives(int value)
    {
        healthText.text = "x "  + value.ToString();
    }
}
