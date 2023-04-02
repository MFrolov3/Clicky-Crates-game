using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int scoreValue;
    static private int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI highScoreText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isGameActive;

    void Start()
    {
               
    }

    public void GameOverFunction()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        isGameActive = false;
        if (highScore < scoreValue)
        {
            highScore = scoreValue;
        }
        highScoreText.text = "Your Record: " + highScore.ToString();
        highScoreText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            //UpdateScore(5);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        scoreText.gameObject.SetActive(true);
        scoreValue += scoreToAdd;
        scoreText.text = "Score: " + scoreValue.ToString();
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        scoreValue = 0;
        spawnRate /= difficulty;

        highScoreText.gameObject.SetActive(false);

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
}
