using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    int isOnFloor;
    Rigidbody2D rb;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        isOnFloor = 1;
        rb = GetComponent<Rigidbody2D>();
        jumpForce = 6;
        isJumping = false;
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("IsDead") == 1)
        {
            GameController.instance.endGame.Play();
            Destroy(gameObject);
        }
    }
    void LateUpdate()
    {
        if (Input.GetAxisRaw("Vertical") == -1 && isOnFloor == 1)
        {
            GoDownwards();
        }
        if (Input.GetAxisRaw("Vertical") == 1 && isOnFloor == 0)
        {
            GoUpwards();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJumping is false)
        {
            Jump();
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime;
        }
    }

    void GoUpwards()
    {
        transform.position = new Vector2(transform.position.x, 1.35f);
        isOnFloor = 1;
    }
    
    void GoDownwards()
    {
        transform.position = new Vector2(transform.position.x, -3.65f);
        isOnFloor = 0;
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = true;
        }
    }

}
