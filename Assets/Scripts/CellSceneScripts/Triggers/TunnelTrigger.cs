using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelTrigger : MonoBehaviour
{
    private GameObject arrowPNG;

    public GameObject blackOverlay;

    private bool isDown = false;
    private BoxCollider2D cellCollider;

    private void Start()
    {
        cellCollider = GameObject.Find("Cell").GetComponent<BoxCollider2D>();

        arrowPNG = GameObject.Find("Arrow");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Eger karakter hala collider icinde ise ama dusmediyse
            if (!isDown) { 
                if (Input.GetKey(KeyCode.E))
                {
                    //Karakterin dusebilmesi icin altindaki colliderin saga kaydirilmasi
                    cellCollider.offset = cellCollider.offset + new Vector2(0.55f,0);

                    arrowPNG.SetActive(false);
                    blackOverlay.SetActive(true);

                    isDown = true;

                    //Parametre olarak aldigi coroutine'i baslatir
                    StartCoroutine(createAfter(0.5f));
                    StartCoroutine(createAfter(4));
                    StartCoroutine(createAfter(6));
                    StartCoroutine(createAfter(7));
                    StartCoroutine(createAfter(8));
                }
            }
        }
    }

    //Bouncer'in belli bir sureden sonra yaratilmasini saglayan coroutine
    IEnumerator createAfter(float seconds)
    {
        //Coroutine yurutulmesini verilen saniye boyunca askiya alir
        yield return new WaitForSeconds(seconds);
        EnemiesFactory.CreateBouncer();
    }
}
