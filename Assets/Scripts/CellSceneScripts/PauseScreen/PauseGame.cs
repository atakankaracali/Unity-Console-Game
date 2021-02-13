using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseCanvas;
    public Button quitButton, continueButton;


    void Update()
    {
        //Escape tusu basildiysa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Pause Menusu aktif ise deaktif edilir 
            if (pauseCanvas.activeSelf)
            {
                pauseCanvas.SetActive(false);
                Time.timeScale = 1f;
            }//Pause Menusu deaktif ise aktif edilir 
            else
            {
                pauseCanvas.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        quitButton.onClick.AddListener(quitClickEvent);
        continueButton.onClick.AddListener(continueClickEvent);
    }

    private void continueClickEvent()
    {
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);

    }

    private void quitClickEvent()
    {
        Application.Quit();
    }

}
