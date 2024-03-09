using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        CoinApproach();
        if (gameObject.transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }

    void CoinApproach()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.instance.coin++;
            GameController.instance.tempCoin++;
            GameController.instance.coinSfx.Play();
            GameController.instance.score += 5;
            Destroy(gameObject);
        }
    }
}
