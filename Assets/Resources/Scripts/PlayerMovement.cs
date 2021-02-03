
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool wasJustClicked = true;
    bool canMove;
    Vector2 playerSize;
    Rigidbody2D rb;

    public Transform BoundaryHolder;

    Boundary playerBoundary;



    struct Boundary
    {
        public float UP, Down, Left, Right;


        public Boundary(float up,float down,float left, float right)
        {
            UP = up;
            Down = down;
            Left = left;
            Right = right;
        }

    }


    void Start()
    {
        playerSize = GetComponent<SpriteRenderer>().bounds.extents;
        rb = GetComponent<Rigidbody2D>();

        playerBoundary = new Boundary(BoundaryHolder.GetChild(0).position.y,
                                      BoundaryHolder.GetChild(1).position.y,
                                      BoundaryHolder.GetChild(2).position.x,
                                      BoundaryHolder.GetChild(3).position.x);


    }

    void Update()
    {

        if(Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (wasJustClicked)
            {
                wasJustClicked = false;

                if((mousePos.x >= transform.position.x && mousePos.x < transform.position.x + playerSize.x ||
                    mousePos.x <= transform.position.x && mousePos.x > transform.position.x - playerSize.x) && 
                   ( mousePos.y >= transform.position.y && mousePos.y < transform.position.y + playerSize.y ||
                    mousePos.y <= transform.position.y && mousePos.y > transform.position.y - playerSize.y))
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }

            }

            if (canMove)
            {
                Vector2 clampMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerBoundary.Left, playerBoundary.Right),
                                                    Mathf.Clamp(mousePos.y, playerBoundary.Down, playerBoundary.UP));
                rb.MovePosition(clampMousePos);
            }
             
        }
        else
        {
            wasJustClicked = true;
        }
        
    }
}
