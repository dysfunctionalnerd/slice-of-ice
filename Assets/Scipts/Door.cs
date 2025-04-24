using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public int totalButtonCount;
    public Button[] buttons;
    public bool isOpen;

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttons = FindObjectsByType<Button>(FindObjectsSortMode.None);
        totalButtonCount = buttons.Length;
    }

    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();
        CheckButtons();
    }

    public void CheckButtons() 
    {
        int buttonCount = 0;
        foreach (Button button in buttons)
        {
            if(button.isPressed == true)
            {
                buttonCount++;
            }
        }

        if (buttonCount == totalButtonCount) 
        { 
            isOpen = true;
            animator.SetBool("isOpen", true);
            GetComponent<Collider2D>().isTrigger = true;
        }
        else
        {
            isOpen = false;
            animator.SetBool("isOpen", false);
            GetComponent<Collider2D>().isTrigger = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(0);
    }

}
