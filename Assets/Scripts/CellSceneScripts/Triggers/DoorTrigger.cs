using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public GameObject choicesCanvas, doorObstacle,leftIndicator;
    public GameObject failedCanvas, tunnelTrigger, arrowPNG;


    public Button firstButton, secondButton, thirdButton;
    private bool hasAnswered = false,enemyCreated=false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Sadece hala bir secenegin secilmemis olma durumunda calisir
        if (other.CompareTag("Player") && !hasAnswered)
        {
                //3 secim kanvasini aktif eder ve buttonlara listener ekler
                choicesCanvas.SetActive(true);
                firstButton.onClick.AddListener(firstButtonClickEvent);
                secondButton.onClick.AddListener(secondButtonClickEvent);
                thirdButton.onClick.AddListener(thirdButtonClickEvent);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Alandan cikilma durumunda secenekler kaybolur
            choicesCanvas.SetActive(false);
        }
    }


    protected virtual void firstButtonClickEvent()
    {
        hasAnswered = true;

        choicesCanvas.SetActive(false);
        doorObstacle.SetActive(false);
        //Ilk button tiklanma durumunda ghostu yaratir
        if (!enemyCreated)
        {
            enemyCreated = true;
            EnemiesFactory.CreateGhost();
        }

    }

    protected virtual void secondButtonClickEvent()
    {
        hasAnswered = true;

        leftIndicator.SetActive(true);
        ////Parametre olarak aldigi coroutine'i baslatir
        StartCoroutine(setFalseAfter(leftIndicator, 1f));
        choicesCanvas.SetActive(false);
        tunnelTrigger.SetActive(true);
        arrowPNG.SetActive(true);
    }

    protected virtual void thirdButtonClickEvent()
    {
        hasAnswered = true;

        choicesCanvas.SetActive(true);
        failedCanvas.SetActive(true);

        Time.timeScale = 0f;

        Button resButton = GameObject.Find("Restart").GetComponent<Button>();
        resButton.onClick.AddListener(RestartScene);
    }

    public static void RestartScene()
    {
        //Suan aktif olan sahneyi tekrar yukler
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        Time.timeScale = 1f;
    }

    //Parametre olarak aldigi GO'yu belli bir sure sonra deaktif eder
    public IEnumerator setFalseAfter(GameObject gbObject,float minutes)
    {
        yield return new WaitForSeconds(minutes);
        gbObject.SetActive(false);
    }


}
