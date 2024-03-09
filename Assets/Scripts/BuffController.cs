using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    int timer;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        BuffApproach();
        if (gameObject.transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }

    void BuffApproach()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("Buff", 1);
            GameController.instance.ActiveBuff();
            Destroy(gameObject);
        }
    }

}
