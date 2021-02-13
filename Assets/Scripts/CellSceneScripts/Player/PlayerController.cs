using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer sp;
    private Animator animator;

    private float moveSpeed = 5f;
    private float jumpForce = 250f;

    private float horizontal;

    // Ilk frame'den once cagrilir.
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2d.freezeRotation = true;

    }

    // Her frame icin bir defa cagrilir.
    void Update()
    {
        //A,D veya sag ve sol ok tuslari inputunu alir (-1 / 1 arasi bir deger)
        horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            sp.flipX = false;


        }
        if (horizontal < 0)
        {
            sp.flipX = true;
        }


        rb2d.velocity = new Vector2(horizontal * moveSpeed, rb2d.velocity.y);

        //Bosluk tusu basildiysa ve karakter yerde ise 
        if (Input.GetKeyDown(KeyCode.Space) && rb2d.velocity.y == 0)
        {
            //Y ekseninde jumpForce kadar bi kuvvet uygulanir
            rb2d.AddForce(Vector2.up * jumpForce);
        }
        setAnimationState();
    }

    
    //Animator componentin , animasyon durumunu set eder
    //karakterin hareket edip etmemesine ve ziplayip ziplamamasina gore
    //uygun animasyonu set eder.
    void setAnimationState()
    {
        if (horizontal == 0)
        {
            animator.SetBool("isMoving", false);
        }
        if (rb2d.velocity.y == 0)
        {
            animator.SetBool("isJumping", false);
        }

        if(Mathf.Abs(horizontal)>0 && rb2d.velocity.y == 0)
        {
            animator.SetBool("isMoving", true);
        }

        if (rb2d.velocity.y > 0)
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isJumping", true);
        }
        
    }


}
