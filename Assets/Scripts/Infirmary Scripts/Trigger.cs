using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public GameObject PasswordInput;
    private GameObject arrowPNG;
    public GameObject fade;

    private void Start()
    {
        arrowPNG = GameObject.Find("Arrow");
        fade.SetActive(true);
            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Kullanici E ye tikladiysa
            if (Input.GetKey(KeyCode.E))
            { 
                arrowPNG.SetActive(false);
                fade.SetActive(false);
                //Input Fieldi aktif et
                PasswordInput.SetActive(true);

            }

        }
    }
}

