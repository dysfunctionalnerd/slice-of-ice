using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2Int PlayerCoordinates;

    RaycastHit2D hit;

    Rigidbody2D rigid;

    public bool isPushable;

    bool isMoving = true;
    

    public HitDirectionPosition hitDirectionPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetCoordinateStart();
       
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (isMoving)
        //{
        //    Movement();
        //    if (transform.position == TargetPosition)
        //    {
        //        isMoving = false;
        //    }
        //}
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
        

       //transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime);

       transform.position = Vector3.MoveTowards(transform.position, hitDirectionPosition.targetPosition, .7f);

         
    }

    void CheckMovement() 
    {
        hit = Physics2D.Raycast(transform.position, Vector3.up, 1000f);
        
        if (hit)
        {
            hitDirectionPosition.targetPosition = hit.transform.position;
            hitDirectionPosition.distance = Vector3.Distance(transform.position, hitDirectionPosition.targetPosition);

            if (hit.collider.tag == ("IceBlock"))
            {
                if (hitDirectionPosition.distance <= 2)
                {
                    isPushable = true;
                }
                else
                {
                    isPushable = false;                
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        hit = Physics2D.Raycast(transform.position, Vector3.up, 1000f);
        Gizmos.color = Color.white;
       
        if (hit.collider == null)
        {
            Gizmos.DrawLine(transform.position, Vector3.up * 1000f);
        }
        else if (hit.collider != null)
        {
            if (hit.collider.tag == ("IceBlock"))
            {
                Gizmos.color = Color.blue;
               
                if (isPushable)
                {
                    Gizmos.color = Color.green;
                }

            }
            else if (hit.collider.tag == ("WallBlock"))
            {

            }

            Gizmos.DrawLine(transform.position, hit.transform.position);
        }
    }

    [System.Serializable]
    public class HitDirectionPosition
    {
        public Vector2 targetPosition;
        public float distance;
    }



}
