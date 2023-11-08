using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class Boss2 : MonoBehaviour
{
    public float speed;
    public float walkTime;
    public bool walkRigth = true;
    public int health = 8;
    private float tempTiro;
    public float tempTiroMax = 2;
    public GameObject prefabDeTiro;

    private float timer;
    private Animator anim;

    private Rigidbody2D rig;

    private bool ataqueEmAndamento = false;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameController.instance.UpdateLives(health);

    }

    IEnumerator SequenciaAtaque()
    {

        GetComponent<Animator>().Play("attack");
        yield return new WaitForSeconds(0.3f);

        //aqui que vai instanciar o tiro
        GameObject clone = Instantiate(prefabDeTiro, transform.GetChild(0).position, Quaternion.identity);
        if (!walkRigth)
        {
            clone.transform.Rotate(Vector3.up, 180);
        }

        yield return new WaitForSeconds(0.1f);
        GetComponent<Animator>().Play("walk");
        tempTiro = 0;
        ataqueEmAndamento = false;
        StopCoroutine(SequenciaAtaque());
    }


    void FixedUpdate()
    {
        timer += Time.deltaTime;
        tempTiro += Time.deltaTime;

        if (timer >= walkTime)
        {
            walkRigth = !walkRigth;
            timer = 0f;
        }

        if (tempTiro >= tempTiroMax && !ataqueEmAndamento)
        {
            ataqueEmAndamento = true;
            StartCoroutine(SequenciaAtaque());
        }

        if (ataqueEmAndamento)
        {
            rig.velocity = Vector2.zero;
        }
        else
        {
            if (walkRigth)
            {
                transform.eulerAngles = new Vector2(0, 0);
                rig.velocity = Vector2.right * speed;
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
                rig.velocity = Vector2.left * speed;
            }
        }
    }

    public void Damage(int dano)
    {
        health -= dano;
        anim.SetTrigger("hurt");
        GameController.instance.UpdateLives(health);

        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Boss3");
        }

        if (health <= 3)
        {
            EntrarComportamento2();
        }

    }

    public void EntrarComportamento2()
    {
        tempTiroMax *= 7f;
        speed += 15;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.StartsWith("Magic"))
        {
            Damage(1);
            Destroy(col.gameObject);
        }
    }
}

   
