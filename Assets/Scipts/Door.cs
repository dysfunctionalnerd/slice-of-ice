using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    //public List<Button> buttons;
    public Button[] buttons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttons = FindObjectsByType<Button>(FindObjectsSortMode.None);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
