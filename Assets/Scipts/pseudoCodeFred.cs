using UnityEngine;
using System.Collections.Generic;


public class pseudoCodeFred : MonoBehaviour
{
    Vector2 direction = Vector3.left;

    Vector3 targetPosition;
    public float moveSpeed;
    public RaycastHit2D hit;

    public bool isPushable;
    public float distance;

    string iceBlock = "IceBlock";
    string wallBlock = "WallBlock";

    public List<Vector3> Directions = new List<Vector3>();

   

    void Start()
    {
        Directions.Add(Vector3.up);
        Directions.Add(Vector3.left);
        Directions.Add(Vector3.right);
        Directions.Add(Vector3.down);

    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
    }

    void UpdateMovement()
    {
        //if (isPushable && targetPosition == )
        //{
        //    hit.collider.GetComponent<pesudoCodeBlockFred>().SlideDirection(direction);
        //}
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed);



    }

    void CheckMovement()
    {



        hit = Physics2D.Raycast(transform.position, direction, 10000);

        if (hit)
        {
            distance = Vector3.Distance(transform.position, hit.transform.position);

            if (distance <= 2 && hit.collider.tag == iceBlock)
            {
                isPushable = true;
            }
            else
                isPushable = false;
        }
        else
            isPushable = false;

        
    }

    void InputMovement()
    {

    }


    private void OnDrawGizmos()
    {
        hit = Physics2D.Raycast(transform.position, direction, 10000);
        Gizmos.color = Color.yellow;
        
        if (hit.collider == null)
        {
            Gizmos.DrawLine(transform.position, direction * 100000);
        }
        else if(hit.collider != null)
        {
            

            if (hit.collider.tag != null)
            {
                if (hit.collider.tag == "WallBlock")
                    Gizmos.color = Color.black;
                else if (hit.collider.tag == "IceBlock")
                    Gizmos.color = Color.blue;
                    if (isPushable)
                        Gizmos.color = Color.cyan;
            }

            Gizmos.DrawLine(transform.position, hit.transform.position);
        }
      
    }
}
