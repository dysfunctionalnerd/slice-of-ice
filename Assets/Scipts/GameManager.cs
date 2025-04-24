using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int turnCount;
    public TextMeshProUGUI CountText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        { 
        Restart();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnMenu();
        }
    }

    public void TurnCountUpdate ()
    {
        turnCount++;
        CountText.text = turnCount.ToString();
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
