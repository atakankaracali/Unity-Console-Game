using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    private GameObject player;

    //Oyun basladiginda class'a ait genel ozelliklerin tanimlanmasi
    private void Start()
    {
        setCollider<PolygonCollider2D>();
        setSprite("Ghost");

        rb2d.mass = 100;
        rb2d.freezeRotation = true;
        rb2d.gravityScale = 0;

        spRender.flipX = true;
        spRender.sortingOrder = 3;

        transform.localScale = new Vector3(0.6f, 0.6f, 1);

        player = GameObject.Find("Player");
    }

    //Her frame'de calisacak metod.
    private void FixedUpdate()
    {
        //Ghost'un karakterin pozisyonuna gore yonunu belirlemesi
        direction = (player.transform.position.x - transform.position.x < 0) ? -1 : 1;
        if (direction == 1)
        {
            spRender.flipX = false;
        }
        else
        {
            spRender.flipX = true;
        }
        MovementPattern();
    }

    protected override void MovementPattern()
    {
        rb2d.velocity = new Vector2(speed * direction, rb2d.velocity.y);

    }

}
