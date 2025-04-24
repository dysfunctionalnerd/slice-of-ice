using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void SelectLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }

   public void QuitGame()
    {
        Application.Quit();
    }
}
