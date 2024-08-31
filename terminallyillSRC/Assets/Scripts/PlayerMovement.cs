using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.velocity = moveInput * moveSpeed;

        if (moveInput.x < 0)
        {
            if (moveInput.y > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 45);
            }

            else if (moveInput.y < 0) { transform.eulerAngles = new Vector3(0, 0, 135); }
            else { transform.eulerAngles = new Vector3(0, 0, 90); }
        }

        else if (moveInput.x > 0)
        {
            if (moveInput.y > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, -45);
            }

            else if (moveInput.y < 0) { transform.eulerAngles = new Vector3(0, 0, -135); }
            else { transform.eulerAngles = new Vector3(0, 0, -90); }
        }

        else
        {
            if (moveInput.y > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            else if (moveInput.y < 0) { transform.eulerAngles = new Vector3(0, 0, 180); }

        }

    }
}
