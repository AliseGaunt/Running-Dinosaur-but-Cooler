using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject[] player = new GameObject[4];
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    int finalScore;
    public int score;
    int timer, Timer;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI yourScoreText;
    public int coin, tempCoin;
    [SerializeField]
    int totalCoin;
    [SerializeField]
    TextMeshProUGUI highScoreText;
    [SerializeField]
    TextMeshProUGUI coinEarnedText;
    [SerializeField]
    TextMeshProUGUI totalCoinText;
    [SerializeField]
    GameObject endGameUI, pauseGameUI;
    [SerializeField]
    GameObject attentionUI;
    public AudioSource bgm, buttonClick, coinSfx, buff, attention, endGame;
    //bool isEasyMode, isIntermediateMode, isHardMode, isHellMode;
    bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        UpdateSound();
        CreatePlayer();
        StartGame();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateCoin();

        if (PlayerPrefs.GetInt("IsDead") == 1)
        {
            EndGame();
        }

        //if (score >= 300) ChangeMode();

        if (PlayerPrefs.GetInt("Buff") == 1)
        {
            DeactiveBuff(Timer);
        }

        if (attentionUI.activeSelf)
        {
            attention.Play();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            isPaused = true;
            bgm.Pause();
            pauseGameUI.SetActive(true);
        }

    }

    private void LateUpdate()
    {
        if (PlayerPrefs.GetInt("IsDead") == 0 && !isPaused && PlayerPrefs.GetInt("Buff") == 0)
        {
            if (score < 1500)
                Time.timeScale = 1f + (score / 300) * 0.3f;
            else
                Time.timeScale = 2.5f;
            //if (isEasyMode) Time.timeScale = 1f;
            //if (isIntermediateMode) Time.timeScale = 1.3f;
            //if (isHardMode) Time.timeScale = 1.6f;
            //if (isHellMode) Time.timeScale = 1.9f;
        }
    }

    void StartGame()
    {
        score = 0;
        timer = 0;
        coin = 0;
        endGameUI.SetActive(false);
        PlayerPrefs.SetInt("IsDead", 0);
        PlayerPrefs.SetInt("Buff", 0);
        //isEasyMode = true;
        //isIntermediateMode = false;
        //isHardMode = false;
        //isHellMode = false;
        isPaused = false;
    }

    void CreatePlayer()
    {
        switch (PlayerPrefs.GetString("PlayerColor"))
        {
            case "red":
                Instantiate(player[0], playerTransform.position, Quaternion.identity);
                break;
            case "blue":
                Instantiate(player[1], playerTransform.position, Quaternion.identity);
                break;
            case "yellow":
                Instantiate(player[2], playerTransform.position, Quaternion.identity);
                break;
            case "green":
                Instantiate(player[3], playerTransform.position, Quaternion.identity);
                break;
            default:
                Instantiate(player[0], playerTransform.position, Quaternion.identity);
                break;
        }
    }

    void UpdateSound()
    {
        bgm.volume = PlayerPrefs.GetInt("BGM")/10f;
        buttonClick.volume = PlayerPrefs.GetInt("SFX")/10f;
        coinSfx.volume = PlayerPrefs.GetInt("SFX")/10f;
        buff.volume = PlayerPrefs.GetInt("SFX")/10f;
        endGame.volume = PlayerPrefs.GetInt("SFX")/10f;
        attention.volume = PlayerPrefs.GetInt("SFX")/10f;

        bgm.Play();
    }    

    void UpdateScore()
    {
        int temp;
        temp = (int)Time.time - timer;
        if (temp >= 2)
        {
            score += 10;
            timer = (int)Time.time;
        }
        scoreText.text = score.ToString();
    }

    void UpdateCoin()
    {
        if (PlayerPrefs.GetInt("IsDead") == 0)
        {
            coinEarnedText.text = coin.ToString();
        }
        else if (PlayerPrefs.GetInt("IsDead") == 1)
            coinEarnedText.text = tempCoin.ToString();
    }

    //void TurnToEasyMode()
    //{
    //    isEasyMode = true;
    //}

    //void TurnToIntermediateMode()
    //{
    //    isEasyMode = false;
    //    isIntermediateMode = true;
    //}

    //void TurnToHardMode()
    //{
    //    isIntermediateMode = false;
    //    isHardMode = true;
    //}

    //void TurnToHellMode()
    //{
    //    isHardMode = false;
    //    isHellMode = true;
    //}

    //void ChangeMode()
    //{
    //    if (score >= 300 && score < 600) TurnToIntermediateMode();
    //    else if (score >= 600 && score < 1200) TurnToHardMode();
    //    else if (score >= 1200) TurnToHellMode();
    //    else if (score < 300) TurnToEasyMode();
    //}

    void DeactiveBuff(int temp)
    {
        if ((int)Time.time - temp >= 18 && (int)Time.time - temp < 20)
        {
            attentionUI.SetActive(true);
            Time.timeScale = (Time.timeScale + 1f + (score / 300) * 0.3f) / 2;
            //if (isIntermediateMode || isHardMode) Time.timeScale = 1.7f;
        } 
        else if ((int)Time.time - temp >= 20 && (int)Time.time - temp < 25)
        {
            Time.timeScale = (Time.timeScale + 1f + (score / 300) * 0.3f) / 2;
            //if (isIntermediateMode) Time.timeScale = 1.5f;
        }
        else if ((int)Time.time - temp >= 25)
        {
            PlayerPrefs.SetInt("Buff", 0);
            attentionUI.SetActive(false);
            Time.timeScale = 1f + (score / 300) * 0.3f;
            //ChangeMode();
        }
    }

    public void ActiveBuff()
    {
        Time.timeScale = 2.8f;
        buff.Play();
        Timer = (int)Time.time;
    }

    public void ResumeGame()
    {
        pauseGameUI.SetActive(false);
        isPaused = false;
        bgm.UnPause();
        Time.timeScale = 1f + (score / 300) * 0.3f;
        //ChangeMode();
    }   
    
    public void EndGame()
    {
        Time.timeScale = 0f;
        bgm.Stop();

        finalScore = score;
        if (PlayerPrefs.GetInt("HighScore") < finalScore)
        {
            PlayerPrefs.SetInt("HighScore", finalScore);
        }

        totalCoin = PlayerPrefs.GetInt("TotalCoin");
        totalCoin += coin;
        coin = 0;
        PlayerPrefs.SetInt("TotalCoin", totalCoin);

        endGameUI.SetActive(true);
        yourScoreText.text = finalScore.ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        totalCoinText.text = PlayerPrefs.GetInt("TotalCoin").ToString();
    }

    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
