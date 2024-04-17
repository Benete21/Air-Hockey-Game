using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movment : MonoBehaviour
{
    bool clicked = true;
    bool moved = true;
    Rigidbody2D rb;
    Vector2 startingPosition;
    Collider2D playerCollider;
    public Transform BoundarysPlayer;
    Boundary playerBoundary;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        playerCollider = GetComponent<Collider2D>();
        playerBoundary = new Boundary(BoundarysPlayer.GetChild(0).position.y,
                                      BoundarysPlayer.GetChild(1).position.y,
                                      BoundarysPlayer.GetChild(2).position.x,
                                      BoundarysPlayer.GetChild(3).position.x);

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (clicked)
            {
                clicked = false;

                if (playerCollider.OverlapPoint(mousePos))
                {
                    moved = true;
                }
                else
                {
                    moved = false;
                }
            }
            if (moved)
            {
                Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerBoundary.Left, playerBoundary.Right), Mathf.Clamp(mousePos.y, playerBoundary.Down, playerBoundary.Up));
                rb.MovePosition(clampedMousePos);
            }
        }
        else
        {
            clicked = true;
        } 
    }
    public void ResetPosition()
    {
        rb.position = startingPosition;
    }
}

