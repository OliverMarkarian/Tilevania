using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int playerScore = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] AudioClip GameSound;
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = playerLives.ToString() + " Lives";
        scoreText.text = playerScore.ToString() + " Points";
    }
    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            Invoke("TakeLife",2);
        }
        else
        {
            Invoke("ResetGameSession",2);
            
        }
    }
    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
        FindObjectOfType<ScenePersist>().ResetScenePersist();
    }
    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString() + " Lives";
    }
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString() + " Points";
    }
}
