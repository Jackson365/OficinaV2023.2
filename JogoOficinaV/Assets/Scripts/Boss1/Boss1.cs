
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

    public string Boss2;

    public int damage = 1;

    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
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

    public void Damage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            SceneManager.LoadScene("Boss2");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           
            collision.gameObject.GetComponent<Player>().Damage(damage);
        }
    }
}
