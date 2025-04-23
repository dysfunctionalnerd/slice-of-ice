using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IceBlock : MonoBehaviour
{
    public List<HitDirection> rayDirections;
    public bool isMoving;
    public Vector3 newPosition;
    public float speed;
    public float distance;




// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Movement();
            if (transform.position == newPosition)
            {
                isMoving = false;
            }
        }
    }

    private void FixedUpdate()
    {
        
    }
    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed);

    }



    public void CheckMovement(Vector3 direction)
    {
        gameObject.layer = 2;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1000f);

        if (hit)
        { 
            
            newPosition = hit.transform.position;
            distance = Vector3.Distance(transform.position, newPosition);

            if (hit.collider.tag != "StopTile") 
            {
                newPosition = new Vector3(
                newPosition.x - direction.x,
                newPosition.y - direction.y,
                0);
            }
                        
            isMoving = true;
            if (hit.collider.tag == "WallBlock" ||  hit.collider.tag == "IceBlock")
            {
                if (distance == 1)
                {
                    isMoving = false;
                }
            }
        }

        gameObject.layer = 0;
    }
}



