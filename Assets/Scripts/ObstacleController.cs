using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    float speed;
    public PolygonCollider2D obstacleCollider;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
        obstacleCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleApproach();
        if (gameObject.transform.position.x <= -15)
        {
            Destroy(gameObject);
        }

        if (PlayerPrefs.GetInt("Buff") == 1)
        {
            obstacleCollider.enabled = false;
        } else
        if (PlayerPrefs.GetInt("Buff") == 0)
        {
            obstacleCollider.enabled = true;
        }
    }

    void ObstacleApproach()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("IsDead", 1);
        }
    }
}
