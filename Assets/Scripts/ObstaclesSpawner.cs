using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] tree = new GameObject[3];
    public int minTime, maxTime;
    [SerializeField]
    GameObject coin;
    [SerializeField]
    GameObject buff;

    // Start is called before the first frame update
    void Start()
    {
        minTime = 2;
        maxTime = 6;
        Invoke("SpawnObstaclesOnTopGround", 2f);
        Invoke("SpawnObstaclesOnBottomGround", 2f);
        Invoke("SpawnRowOfCoins", 7f);
        Invoke("SpawnBuff", 60f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstaclesOnTopGround()
    {
        Vector3 temp = transform.position;

        int gachaObstacle = Random.Range(0, 15);
        if (gachaObstacle == 14)
        {
            temp.y = 1.4f;
            Instantiate(tree[2], temp, Quaternion.identity);
        } else
        if (gachaObstacle <= 13 && gachaObstacle >= 6 )
        {
            temp.y = 1.5f;
            Instantiate(tree[0], temp, Quaternion.identity);
        }
        else
        {
            temp.y = 1.6f;
            Instantiate(tree[1], temp, Quaternion.identity);
        }

        Invoke("SpawnObstaclesOnTopGround", Random.Range(minTime, maxTime));
    }
    void SpawnObstaclesOnBottomGround()
    {
        Vector3 temp1 = transform.position;

        int gachaObstacle = Random.Range(0, 15);
        if (gachaObstacle == 14 || gachaObstacle == 13)
        {
            temp1.y = -3.6f;
            Instantiate(tree[2], temp1, Quaternion.identity);
        }
        else
        if (gachaObstacle < 13 && gachaObstacle >= 6)
        {
            temp1.y = -3.5f;
            Instantiate(tree[0], temp1, Quaternion.identity);
        }
        else
        {
            temp1.y = -3.4f;
            Instantiate(tree[1], temp1, Quaternion.identity);
        }

        Invoke("SpawnObstaclesOnBottomGround", (int)Random.Range(minTime, maxTime));
    }

    void SpawnRowOfCoins()
    {

        int gachaCoin = Random.Range(0, 4);
        if (gachaCoin < 2)
        {
            Invoke("SpawnCoin1", 0f);
            Invoke("SpawnCoin1", 0.3f);
            Invoke("SpawnCoin1", 0.6f);
            Invoke("SpawnCoin1", 0.9f);
        }
        else if (gachaCoin >= 2)
        {
            Invoke("SpawnCoin2", 0f);
            Invoke("SpawnCoin2", 0.3f);
            Invoke("SpawnCoin2", 0.6f);
            Invoke("SpawnCoin2", 0.9f);
        }

        Invoke("SpawnRowOfCoins", (int)Random.Range(3, 6));
    }

    void SpawnCoin1()
    {
        Vector3 temp = transform.position;
        temp.y = 3;
        Instantiate(coin, temp, Quaternion.identity);
    }

    void SpawnCoin2()
    {
        Vector3 temp = transform.position;
        temp.y = -2;
        Instantiate(coin, temp, Quaternion.identity);
    }

    void SpawnBuff()
    {
        Vector3 temp = transform.position;

        int gachaBuff = Random.Range(0, 4);
        if (gachaBuff < 2)
        {
            temp.y = 3; temp.z = -1;
            Instantiate(buff, temp, Quaternion.identity);
        }
        else if (gachaBuff >= 2)
        {
            temp.y = -2; temp.z = -1;
            Instantiate(buff, temp, Quaternion.identity);
        }

        Invoke("SpawnBuff", (int)Random.Range(90, 100));
    }
}
