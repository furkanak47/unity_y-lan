using UnityEngine;
using UnityEngine.SceneManagement;

public class WallCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("snake"))
        {
            Debug.Log("Duvara çarptı!");
            
            // Soru sayfasına geçiş yap
            SceneManager.LoadScene("EndScene");
        }
    }
}

