
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool wasJustClicked = true;
    bool canMove;
    Rigidbody2D rb;

    public Transform redPlayerBoundaryHolder;

    Boundary playerBoundary;

    Collider2D playerCollider;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();

        playerBoundary = new Boundary(redPlayerBoundaryHolder.GetChild(0).position.y,
                                      redPlayerBoundaryHolder.GetChild(1).position.y,
                                      redPlayerBoundaryHolder.GetChild(2).position.x,
                                      redPlayerBoundaryHolder.GetChild(3).position.x);


    }


    void Update()
    {

        if(Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (wasJustClicked)
            {
                wasJustClicked = false;

                if(playerCollider.OverlapPoint(mousePos))
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
                                                    Mathf.Clamp(mousePos.y, playerBoundary.Down, playerBoundary.Up));
                rb.MovePosition(clampMousePos);
            }
             
        }
        else
        {
            wasJustClicked = true;
        }
        
    }
}
