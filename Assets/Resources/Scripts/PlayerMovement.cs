
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool wasJustClicked = true;
    bool canMove;
    Vector2 playerSize;
    Rigidbody2D rb;

    public Transform redPlayerBoundaryHolder;

    Boundary playerBoundary;


    void Start()
    {
        playerSize = GetComponent<SpriteRenderer>().bounds.extents;
        rb = GetComponent<Rigidbody2D>();

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
