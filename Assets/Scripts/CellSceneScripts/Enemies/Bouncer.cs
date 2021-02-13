using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : Enemy
{

    //Oyun basladiginda class'a ait genel ozelliklerin tanimlanmasi
    private void Start()
    {
        setCollider<CircleCollider2D>();       
        gameObject.GetComponent<CircleCollider2D>().radius = 1;

        setSprite("EyeBall");

        transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }

    //Her frame'de calisacak metod.
    private void FixedUpdate()
    {
        MovementPattern();

    }

    //Bouncer'in sola ve asagi yukari dogru hareketi
    protected override void MovementPattern()
    {
        rb2d.velocity = new Vector2(1 * direction, rb2d.velocity.y);
        rb2d.AddForce(new Vector2(-150, 0));

        //Sadece yere degdigi zaman yeniden zipla
        if (rb2d.velocity.y == 0)
        {
            rb2d.AddForce(new Vector2(0, 400));

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tunnelLeft"))
        {
            Destroy(gameObject);
        }
    }
}