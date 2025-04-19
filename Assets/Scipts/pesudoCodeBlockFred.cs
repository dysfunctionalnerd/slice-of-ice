using UnityEngine;

public class pesudoCodeBlockFred : MonoBehaviour
{


    public void SlideDirection(Vector3 direction)
    {
        if (direction == Vector3.up)
        {
            print("Move Up");
        }
        else if (direction == Vector3.down)
        {
            print("Move Down");
        }
        else if (direction == Vector3.left)
        {
            print("Move Left");
        }
        else if (direction == Vector3.right)
        {
            print("Move Left");
        }
    }
}
