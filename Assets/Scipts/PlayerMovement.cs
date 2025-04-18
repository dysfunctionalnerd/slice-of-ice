using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2Int PlayerCoordinates;

    Rigidbody2D rigid;

    bool isMoving = true;
    Vector3 TargetPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetCoordinateStart();
        TargetPosition = new Vector2(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Movement();
            if (transform.position == TargetPosition)
            {
                isMoving = false;
            }
        }
    }

    void SetCoordinateStart()
    {
        transform.position = new Vector2((int)transform.position.x, (int)transform.position.y);
    }

    void Movement()
    {
        

       //transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime);

       transform.position = Vector3.MoveTowards(transform.position, TargetPosition, .7f);

         
    }

    


}
