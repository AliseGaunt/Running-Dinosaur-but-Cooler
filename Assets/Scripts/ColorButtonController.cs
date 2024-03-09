using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButtonController : MonoBehaviour
{
    public enum Color
    {
        red,
        blue,
        yellow,
        green
    }
    public Color buttonColor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void changeColor()
    {
        PlayerPrefs.SetString("PlayerColor", buttonColor.ToString());
    }
}
