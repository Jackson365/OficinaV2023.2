using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
    public float speed;
    public float jumpForce;

    public GameObject magicShot;
    public Transform magicPoint;
    
    private bool isJumping;
    private bool dobleJump;
    private bool isAttack;
    
    private Rigidbody2D rig;
    private Animator anim;

    private float movement;

    public AudioSource shotM;
    public AudioSource JumpP;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        AttackMagic();

      //  GameController.instance.UpdateLives(health);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if (movement > 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("Transitions", 1);   
            }
            
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("Transitions", 1);    
            }
            
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (movement == 0 && !isJumping && !isAttack)
        {
            anim.SetInteger("Transitions", 0);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                anim.SetInteger("Transitions", 2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                dobleJump = true;
                isJumping = true;
                JumpP.Play();
            }
            else
            {
                if (dobleJump)
                {
                    anim.SetInteger("Transitions", 2);
                    rig.AddForce(new Vector2(0, jumpForce * 1), ForceMode2D.Impulse);
                    dobleJump = false;
                    JumpP.Play();
                }
            }
        }
    }

    void AttackMagic()
    {
        StartCoroutine("Attack");
    }

    IEnumerator Attack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isAttack = true;
            anim.SetInteger("Transitions", 3);
            GameObject Magic = Instantiate(magicShot, magicPoint.position, magicPoint.rotation);
            isAttack = false;
            shotM.Play();
            if (transform.rotation.y == 0)
            {
                Magic.GetComponent<MagicShot>().isRight = true;
            }

            if (transform.rotation.y == 180)
            {
                Magic.GetComponent<MagicShot>().isRight = false;
            }
            
            yield return new WaitForSeconds(0.2f);
            anim.SetInteger("Transitions", 0);
        }
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        GameController.instance.UpdateLives(health);

        if(health <= 0)
        {
            //Game Over
        }
    }

    public void IncreaseLife(int value)
    {
        health += value;
        GameController.instance.UpdateLives(health);
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }
}