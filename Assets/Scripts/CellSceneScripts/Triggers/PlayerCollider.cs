using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    public GameObject eventPrefab;
    public GameObject failedCanvas;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Karakterin herhangi bir dusman ile carpismasi durumunda
        //Oldun canvasini aktif eder ve zamani durdurur
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Debug.Log("Collided");
            Instantiate(eventPrefab);
            failedCanvas.SetActive(true);

            Time.timeScale = 0f;

            Button yenidenBasla = GameObject.Find("Restart").GetComponent<Button>();
            yenidenBasla.onClick.AddListener(DoorTrigger.RestartScene);
        }
    }


}
