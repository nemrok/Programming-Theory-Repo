using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text healthText;
    [SerializeField]
    private GameObject gameOver;
    private int score;
    private int health;
    private bool isGameOver;
    public bool IsGameOver
    {
        get {return isGameOver;}
        private set {isGameOver = value;}
    }

    private void Start() 
    {
        Reset();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public static GameManager Instance()
    {
        return instance;
    }

    public void Reset()
    {
        score = 0;
        health = 100;
        isGameOver = false;
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;
    }

    public void AddScorePoints(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void RemoveHealth(int amount)
    {
        health -= amount;

        if (health < 1)
        {
            health = 0;
            isGameOver = true;
        }

        healthText.text = "Health: " + health;

        if (IsGameOver)
        {
            StartCoroutine("LoadTitleMenu");
        }    
    }

    public void AddHealth(int amount)
    {
        health += amount;

        if (health > 100)
        {
            health = 100;
        }

        healthText.text = "Health: " + health;
    }

    IEnumerator LoadTitleMenu()
    {   
        gameOver.SetActive(true);

        while(!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        
        SceneManager.LoadScene(0);
    }
}
