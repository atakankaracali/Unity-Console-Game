using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy<T> where T : Enemy
{
    public GameObject GameObject;
    public T ScriptComponent;

    public Enemy()
    {
        GameObject = new GameObject("DefaultName");
        ScriptComponent = GameObject.AddComponent<T>();
    }

    public Enemy(string name)
    {
        GameObject = new GameObject(name);
        ScriptComponent = GameObject.AddComponent<T>();
    }
    
}

public abstract class Enemy : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    protected SpriteRenderer spRender;
    protected Collider2D collider;


    protected float speed;
    protected int direction;

    //Enemy'den kalitim yapan siniflarin override etmesi gereken yurume sekli
    protected abstract void MovementPattern();


    private void Awake()
    {
        rb2d = gameObject.AddComponent<Rigidbody2D>();
        spRender = gameObject.AddComponent<SpriteRenderer>();

        gameObject.tag = "Enemy";
    }

    //Enemy icin yapici
    public void Initialize(float speed, int direction, Vector3 position)
    {
        this.speed = speed;
        this.direction = direction;
        transform.position = position;
    }

    public void Initialize(float speed, Vector3 position)
    {
        this.speed = speed;
        transform.position = position;
    }

    public void Initialize(Vector3 position)
    {
        transform.position = position;
    }

    protected void setCollider<T>() where T : Collider2D
    {
        collider = gameObject.AddComponent<T>();
        collider.sharedMaterial = (PhysicsMaterial2D)Resources.Load("PhysicsMaterials/Friction");
    }

    protected void setSprite(string name)
    {
        spRender.sprite = Resources.Load<Sprite>(name);
    }

    protected void setTag(string name)
    {
        gameObject.tag = name;
    }
}
