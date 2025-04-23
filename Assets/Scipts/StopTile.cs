using UnityEngine;

public class StopTile : MonoBehaviour
{
    
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
       gameObject.layer = 2;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.layer = 0;
    }

}
