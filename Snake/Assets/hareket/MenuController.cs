using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Oyun Başlat Butonuna tıklama işlemi
    public void PlayGame()
    {
        // Oyun sahnesinin adını buraya yazın
        SceneManager.LoadScene("GameScene"); 
    }

    // Çıkış Butonuna tıklama işlemi
    public void QuitGame()
    {
        // Editor içinde çalışıyorsanız, bu kod oyunu kapatmaz. Build alıp çalıştırmalısınız.
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    
}
