using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1 : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rig;
    private bool faceflip;

    public float tempoDeEspera = 10f;
    public string Boss2;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("MudarCena", tempoDeEspera);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void MudarCena()
    {
        SceneManager.LoadScene(Boss2);
    }

    private void Flipenemy()
    {
        if (faceflip)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0,180,0);
        }
    }

        private void OnCollisionEnter2D(Collision2D col)
    {
        if (col != null && !col.collider.CompareTag("boss1") && !col.collider.CompareTag("chao"))
        {
            faceflip = !faceflip;
        }
        
        Flipenemy();
        
    }
}
