using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoruSayfasiController : MonoBehaviour
{
    public Text questionText;
    public Button blackButton;
    public Button whiteButton;

    public int blackTotalChickenCount;
    public int whiteTotalChickenCount;

    public void Start()
    {
        // Get the total chicken counts from the BoxControllers
        blackTotalChickenCount = FindObjectOfType<BoxController>().blacktotalChickenCount;
        whiteTotalChickenCount = FindObjectOfType<beyaztavuksayisi>().whitetotalChickenCount;

        // Display the question
        questionText.text = "Where were there more chickens?";
        
        // Add listeners to the buttons
        blackButton.onClick.AddListener(OnBlackButtonClick);
        whiteButton.onClick.AddListener(OnWhiteButtonClick);
    }

    public void OnBlackButtonClick()
    {
        if (blackTotalChickenCount > whiteTotalChickenCount)
        {
            // More chickens in the black half
            Debug.Log("Tebrikler! Siyah yarida daha fazla tavuk vardi.");
            // Go to the end scene or perform any other action
            SceneManager.LoadScene("EndScene");
        }
       else
        {
            // More chickens in the white half
            Debug.Log("Hata! Beyaz yarıda daha fazla tavuk vardı.");
            // Go to the end scene or perform any other action
            SceneManager.LoadScene("EndScene");
        }
    }

   public void OnWhiteButtonClick()
    {
        if (whiteTotalChickenCount > blackTotalChickenCount)
        { 
           
            Debug.Log("Tebrikler! Beyaz yarida daha fazla tavuk vardi");
          
            SceneManager.LoadScene("EndScene");
        }
       else
        {
                        // More chickens in the black half
            Debug.Log("Hata! Siyah yarıda daha fazla tavuk vardı.");
            // Go to the end scene or perform any other action
            SceneManager.LoadScene("EndScene");
        }
    }
}
