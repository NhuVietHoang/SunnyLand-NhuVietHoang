using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBasics
{
    [SerializeField] private LayerMask isGround;
    public Collider2D coll;


    private float jumpLenght = 5f;
    private float jumpHeight = 5f;
    private float leftCap = 34.9f;
    private float rightCap = 51.82f;
    //private float jumpForce = 2;
    private bool facingLeft = true;


    protected override void Start() 
    {
        base.Start();
        coll = GetComponent<Collider2D>();
    }


    private void Update()
    {
        if (anim.GetBool("Jumping"))
        {
            if (rbEnemy.velocity.y < .1)
            {
                anim.SetBool("Falling", true);
                anim.SetBool("Jumping", false);

            }
        }

        if (coll.IsTouchingLayers(isGround) && anim.GetBool("Falling"))
        {
            anim.SetBool("Falling", false);
        }

    }

    private void MoveEnemy()
    {
        if (facingLeft)
        {
            if (transform.position.x > leftCap)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                if (coll.IsTouchingLayers(isGround))
                {
                    rbEnemy.velocity = new Vector2(-jumpLenght, jumpHeight);
                    anim.SetBool("Jumping", true);
                }

            }
            else
            {
                facingLeft = false;
            }


        }

        else
        {

            if (transform.position.x < rightCap)
            {
                // Enemy'nin doğru yere baktığından emin ol değilse düzelt
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                // frog yerdeyse zıplasın test et
                if (coll.IsTouchingLayers(isGround))
                {
                    rbEnemy.velocity = new Vector2(jumpLenght, jumpHeight);
                    anim.SetBool("Jumping", true);

                    //rbEnemy.AddForce(new Vector2(-jumpLenght,jumpHeight)*jumpForce,ForceMode2D.Impulse);
                }
            }

            //eğer değilse sağa döneeğiz
            else
            {
                facingLeft = true;
            }


        }
    }


}
