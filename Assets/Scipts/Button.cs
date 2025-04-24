using UnityEngine;

public class Button : MonoBehaviour
{

    public bool isPressed;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressButton()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        isPressed = true;
        animator.SetBool("isPressed", true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isPressed = false;
        animator.SetBool("isPressed", false);
    }
}
