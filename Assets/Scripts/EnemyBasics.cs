﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasics : MonoBehaviour
{

    protected Animator anim;
    protected Rigidbody2D rbEnemy;
    protected AudioSource death;

    protected virtual void Start() 
    {
        anim = GetComponent<Animator>();
        rbEnemy = GetComponent<Rigidbody2D>();
        death = GetComponent<AudioSource>();
    }

    public void JumpedOn()
    {
        anim.SetTrigger("Death_Enemy");
        rbEnemy.velocity = Vector2.zero;
    }

    private void DeathEnemy()
    {
        Destroy(this.gameObject);
    }

}