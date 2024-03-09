using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float scrollSpeed;
    [SerializeField]
    MeshRenderer topGround, bottomGround;
    // Start is called before the first frame update
    void Start()
    {
        ScaleBackground();
    }

    // Update is called once per frame
    void Update()
    {
        ScrollingBackground();
    }

    void ScaleBackground()
    {
        float height = Camera.main.orthographicSize * 2f;
        float width = height * Camera.main.aspect;
        transform.localScale = new Vector3(width, height, 1f);
    }
    void ScrollingBackground()
    {
        topGround.material.mainTextureOffset = new Vector2(scrollSpeed * Time.time, 0f);
        bottomGround.material.mainTextureOffset = new Vector2(scrollSpeed * Time.time, 0f);
    } 
}
