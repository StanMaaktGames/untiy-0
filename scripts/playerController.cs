using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerController : MonoBehaviour
{

    public float speed = 0;
    public float jumpForce = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject incompleteTextObject;
    public float launchHeight = 5;
    public Vector3 spawnPosition = new Vector3(0, 2, 0);
    public float maxSpeedBoost = 3;
    public int maxCount = 10;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private int canJump = 3;
    private float speedBoost = 1;
    private bool colliding = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
        incompleteTextObject.SetActive(false);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed * speedBoost);
        if (canJump > 0 && Input.GetKey(KeyCode.Space) && rb.velocity.y <= 0) 
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Update()
    {
        if (rb.position.y < -25)
        {
            rb.position = spawnPosition;
            rb.velocity = Vector3.zero;
        }
        if (colliding)
        {
            canJump = 3;
        }
        else
        {
            canJump -= 1;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();	

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
 
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString() + "/" + maxCount.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pick up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        colliding = true;
        if(other.gameObject.CompareTag("launch pad"))
        {
            if(Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * launchHeight / 2 * 3, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(Vector3.up * launchHeight, ForceMode.Impulse);
            }
            return;
        }
        else if (other.gameObject.CompareTag("vertical launch pad"))
        {
            rb.AddForce(0, launchHeight, -launchHeight * 3, ForceMode.Impulse);
        }
        else if(other.gameObject.CompareTag("checkpoint 1"))
        {
            spawnPosition = new Vector3(0, 15, 30);
            return;
        }
        else if(other.gameObject.CompareTag("checkpoint 2"))
        {
            spawnPosition = new Vector3(45, 15, 30);
            return;
        }
        else if (other.gameObject.CompareTag("checkpoint 3"))
        {
            spawnPosition = new Vector3(91, 25, 30);
            return;
        }
        else if (other.gameObject.CompareTag("danger"))
        {
            rb.position = spawnPosition;
            rb.velocity = Vector3.zero;
            return;            
        }
        else if (other.gameObject.CompareTag("speedBoost"))
        {
            speedBoost = maxSpeedBoost;
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            if (count >= maxCount) 
            {
                rb.velocity = Vector3.zero;
                winTextObject.SetActive(true);
            }
            else
            {
                incompleteTextObject.SetActive(true);
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        colliding = false;
        if (other.gameObject.CompareTag("speedBoost"))
        {
            speedBoost = 1;
            return;
        }
    }
}
