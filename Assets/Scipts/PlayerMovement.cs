using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2Int PlayerCoordinates;
    Rigidbody2D rigid;
    bool isMoving = false;

    public List<HitDirection> rayDirections;
    public Vector3 newPosition;
    public float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = .5f;
        //SetCoordinateStart();

        //rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isMoving)
        {
            
            if (transform.position == newPosition)
            {
                isMoving = false;
            }
            Movement();
        }
        else
        {
            InputMovement();
        }

    }

    private void FixedUpdate()
    {
        CheckMovement();
    }

    void SetCoordinateStart()
    {
        transform.position = new Vector2((int)transform.position.x, (int)transform.position.y);
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed);

    }

    void CheckMovement()
    {
        foreach (var rayDirection in rayDirections)
        {
            rayDirection.hit = Physics2D.Raycast(transform.position, rayDirection.direction, 1000f);

            if (rayDirection.hit)
            {
                rayDirection.targetPosition = rayDirection.hit.transform.position;
                rayDirection.distance = Vector3.Distance(transform.position, rayDirection.targetPosition);

                rayDirection.canMove = true;
                rayDirection.isPushable = false;

                if (rayDirection.hit.collider.tag == "WallBlock" || rayDirection.hit.collider.tag == ("IceBlock"))
                {
                    if (rayDirection.distance == 1f)
                    {
                        rayDirection.canMove = false;

                        if (rayDirection.hit.collider.tag == ("IceBlock"))
                        {
                            rayDirection.isPushable = true;
                        }
                        else
                        {
                            rayDirection.isPushable = false;
                        }
                    }
                }
            }
        }
    }

    public void InputMovement()
    {
        foreach (var rayDirection in rayDirections)
        {
            if (rayDirection.canMove && Input.GetKeyDown(rayDirection.input))
            {
                if (rayDirection.hit.collider.tag == "StopTile")
                {
                    newPosition = rayDirection.targetPosition;
                }
                else
                {
                    newPosition = new Vector3(
                     rayDirection.targetPosition.x - rayDirection.direction.x,
                     rayDirection.targetPosition.y - rayDirection.direction.y,
                     0
                     );
                }

                isMoving = true;
            }
            else if (rayDirection.isPushable == true && isMoving == false && Input.GetKeyDown(rayDirection.input))
            {
                rayDirection.hit.collider.gameObject.GetComponent<IceBlock>().CheckMovement(rayDirection.direction);
            }
        }

    }

    private void OnDrawGizmos()
    {

        foreach (var rayDirection in rayDirections)
        {

            rayDirection.hit = Physics2D.Raycast(transform.position, rayDirection.direction, 1000f);

            Gizmos.color = Color.yellow;
            if (rayDirection.hit.collider == null)
            {
                Gizmos.DrawLine(transform.position, rayDirection.direction * 1000f);
                rayDirection.isHit = false;
            }
            else if (rayDirection.hit.collider != null)
            {
                if (rayDirection.hit.collider.tag == ("IceBlock"))
                {
                    Gizmos.color = Color.blue;

                    if (rayDirection.isPushable)
                    {
                        Gizmos.color = Color.green;
                    }

                }
                else if (rayDirection.hit.collider.tag == ("WallBlock"))
                {
                    Gizmos.color = Color.black;

                }
                rayDirection.isHit = true;
                Gizmos.DrawLine(transform.position, rayDirection.hit.point);
            }



        }
    }
}

[System.Serializable]
public class HitDirection
{
    public Vector3 direction;
    public RaycastHit2D hit;
    public Vector2 targetPosition;
    public float distance;
    public bool isPushable;
    public bool isHit;
    public bool canMove;
    public KeyCode input;
}
