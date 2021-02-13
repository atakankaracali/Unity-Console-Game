using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy
{
    public static bool collide = false;

    //Oyun basladiginda class'a ait genel ozelliklerin tanimlanmasi
    void Start()
    {
        setSprite("Wizard");

        spRender.flipX = true;
        spRender.sortingOrder = 3;

        setTag("Wizard");

        this.transform.localScale= new Vector3(1.1724f, 1.1724f, 1.1724f);
        rb2d.freezeRotation = true;

        setCollider<PolygonCollider2D>();
        collider.offset = new Vector2(0.72f, 0f);
    }

    private void Update()
    {
        //Eger BoxCollider ile carpismadiysa MovementPattern calisir 
        if (!collide)
        {
            MovementPattern();
        }
    }

    
    protected override void MovementPattern()
    {
        //Wizard sadece sola dogru her frame'de x degerinden -2 cikararak hareket edecek
        rb2d.AddForce(new Vector2(-2f, 0));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("zeroVelocity"))
        {
            //BoxCollider ile carpistiysa Carpisti true , hizi 0 olur.
            collide = true;
            this.rb2d.velocity = Vector3.zero;
        }
    }
}
