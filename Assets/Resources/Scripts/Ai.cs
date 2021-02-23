using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private Rigidbody2D puckRb;

    private Vector2 startingPos;

    public Transform aiPlayerBoundaryHolder;
    private Boundary aiBoundary;

    public Transform puckBoundaryHolder;
    private Boundary puckBoundary;

    private Vector2 targetPos;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        puckRb = GetComponent<Rigidbody2D>();
        startingPos = rb.position;

        aiBoundary = new Boundary(aiPlayerBoundaryHolder.GetChild(0).position.y,
                                      aiPlayerBoundaryHolder.GetChild(1).position.y,
                                      aiPlayerBoundaryHolder.GetChild(2).position.x,
                                      aiPlayerBoundaryHolder.GetChild(3).position.x);

        puckBoundary = new Boundary(puckBoundaryHolder.GetChild(0).position.y,
                                      puckBoundaryHolder.GetChild(1).position.y,
                                      puckBoundaryHolder.GetChild(2).position.x,
                                      puckBoundaryHolder.GetChild(3).position.x);







    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
