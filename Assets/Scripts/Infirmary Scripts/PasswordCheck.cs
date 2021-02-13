using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PasswordCheck : MonoBehaviour
{
    private string password = "3721";
    private string nextScene = "Scenes/CourtYard";

    public Text userInput;
   

    private void CheckPassword()
    {  
        if (userInput.text != null)
        {
            //Kullanicinin girdigi sifre ile tanimlanmis sifre ayni ise
            if (userInput.text == password)
            {
                //Bir sonraki sahneyi yukle
                SceneManager.LoadScene(nextScene);
                
            }
        }

    }

    private void Update()
    {
        //Her frame'de girilen sifrenin dogrulugunu kontrol eder
        CheckPassword();
    }

}





