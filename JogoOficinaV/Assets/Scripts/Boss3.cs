using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class Boss3 : MonoBehaviour
{
    public float speed;
    public float walkTime;
    public bool walkRigth = true;
    public int health;
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

    }

    IEnumerator SequenciaAtaque()
    {
       
        GetComponent<Animator>().Play("Atack");
        yield return new WaitForSeconds(0.2f);
        
        //aqui que vai instanciar o tiro
        GameObject clone = Instantiate(prefabDeTiro, transform.GetChild(0).position, Quaternion.identity);
        if (!walkRigth)
        {
            clone.transform.Rotate(Vector3.up,180 );
        }
        yield return new WaitForSeconds(0.1f);
        GetComponent<Animator>().Play("Idle");
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
        anim.SetTrigger("hit");

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (health <= 3)
        { 
            EntrarComortamento2();
        }
        
    }

    public void EntrarComortamento2()
    {
        tempTiroMax *= 5f;
        speed *= 6;
    }
    
}


