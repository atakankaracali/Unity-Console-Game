using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RopeTrigger : MonoBehaviour
{
    private string infirmary = "Scenes/Infirmary";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Karakter alana girdigi anda yeni sahneyi yukler
            SceneManager.LoadScene(infirmary);

        }



    }
}

