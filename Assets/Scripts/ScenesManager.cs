using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField]
    int highScore;
    [SerializeField]
    TextMeshProUGUI highScoreText;
    [SerializeField]
    AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        bgm.Play();
    }

    private void Update()
    {
        UpdateHighScore();
    }

    // Update is called once per frame
    public void LoadGameScene(string sceneName)
    {
        bgm.Stop();
        SceneManager.LoadScene(sceneName);
    }

    void UpdateHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = highScore.ToString();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }    

    public void QuitGame()
    {
        Application.Quit();
    }
}
