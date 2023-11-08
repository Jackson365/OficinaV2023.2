using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemheart : MonoBehaviour
{
    public int damage;
    public int healthValue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().IncreaseLife(healthValue);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Boss3")
        {
            col.GetComponent<Boss3>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
