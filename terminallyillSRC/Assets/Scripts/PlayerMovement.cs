using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveInput;
    
    public int health = 100;
    public int spawnersDestroyed = 0;

    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI keysText;
    [SerializeField] GameObject deathText;
 
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

        if (health < 0)
        {
            deathText.SetActive(true);
            StartCoroutine(die());
            
        }

        healthText.text = "Health: " + health;
        keysText.text = "Keys out of 4: " + spawnersDestroyed;

        if (Input.GetKeyDown(KeyCode.L))
        {Application.Quit(); UnityEditor.EditorApplication.isPlaying = false; }

    }

    IEnumerator die()
    { yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    private bool canBeHurt = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 5;
        }

        else if (collision.gameObject.CompareTag("FinalDoor") && spawnersDestroyed >= 4)
        { 
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            spawnersDestroyed++;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        canBeHurt = false;
    }

    IEnumerator getHurt()
    {
        if (canBeHurt) { health -= 1; }
        yield return new WaitForSeconds(1);
        canBeHurt = true;
    }
}
