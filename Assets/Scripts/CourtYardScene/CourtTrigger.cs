using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CourtTrigger : DoorTrigger
{
    public GameObject youWon;
    //Sahneler arasi gecis animasyonuna sahip GameObject
    public GameObject fade;

    private void Start()
    {
        EnemiesFactory.CreateWizard();
        fade.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Collider alanina giren wizard ise
        if (collision.CompareTag("Wizard"))
        {
            //Secim kanvasi aktif edilir
            choicesCanvas.SetActive(true);
            fade.SetActive(false);

            firstButton.onClick.AddListener(firstButtonClickEvent);
            secondButton.onClick.AddListener(secondButtonClickEvent);
            thirdButton.onClick.AddListener(thirdButtonClickEvent);
        }
    }

    //DoorTriggerdan kalitilmis button Eventlerinin override edilmesi
    protected override void firstButtonClickEvent()
    {
        failedCanvas.SetActive(true);
        Time.timeScale = 0f;

        resButton().onClick.AddListener(RestartScene);
    }
    protected override void secondButtonClickEvent()
    {
        failedCanvas.SetActive(true);
        Time.timeScale = 0f;

        resButton().onClick.AddListener(RestartScene);
    }
    protected override void thirdButtonClickEvent()
    {
        youWon.SetActive(true);

        Time.timeScale = 0f;
        resButton().onClick.AddListener(RestartGame);
        Button exitButton = GameObject.Find("Exit").GetComponent<Button>();
        //Oyundan cik buttonu secilme durumunda oyunu kapatir
        exitButton.onClick.AddListener(Application.Quit);

    }

    //Oyunu ilk sahneden itibaren baslatir
    private void RestartGame()
    {
        Wizard.collide = false;
        SceneManager.LoadScene("Scenes/CellScene");
        Time.timeScale = 1f;

    }

    //Yakalandin ve Kazandin kanvaslarindaki Yeniden Baslat buttonuna
    //erisip , geriye buttonu donduren metod
    private Button resButton()
    {
        Wizard.collide = false;
        Button resButton = GameObject.Find("Restart").GetComponent<Button>();

        return resButton;
    }
    


}


