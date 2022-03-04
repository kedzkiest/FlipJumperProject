using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // ============ UI =================
    // Score in Game
    public int score = 0;
    // Text of UI
    //public Text scoreText;
    public TextMeshProUGUI scoreText;
    // Text of Final Score
    //public Text finalScore;
    public TextMeshProUGUI finalScoreText;
    // tips Text
    public TextMeshProUGUI tipsText;

    // GameObject to Show "Game Over" when the game ends

    // Restart button
    public Button restartButton;

    public Button titleButton;

    // Start is called before the first frame update
    void Start()
    {
        // subscribe the delegate of "RestartButton.onClick"
        restartButton.onClick.AddListener(OnRestartButtonDown);
        titleButton.onClick.AddListener(OnTitleButtonDown);
        scoreText.enabled = true;
        Destroy(tipsText, 5f); // use Coroutine
    }

    void OnRestartButtonDown()
    {
        // Click restart button to reload the scene
        SceneManager.LoadScene("Main");
        //isGameOver = false;

        //RestartButton.onClick.AddListener(() =>
        //{
        //    SceneManager.LoadScene(0);
        //    isGameOver = false;
        //});
    }
    
    void OnTitleButtonDown()
    {
        // Click restart button to reload the scene
        SceneManager.LoadScene("Opening");
        //isGameOver = false;

        //RestartButton.onClick.AddListener(() =>
        //{
        //    SceneManager.LoadScene(0);
        //    isGameOver = false;
        //});
    }
    

    public void OnAddScore(int lastReward)
    {
        score += lastReward;
        scoreText.text = "Score:  " + score;
    }

    /// <summary>
    /// End the game
    /// </summary>
    public void OnGameOver()
    {
        //EnableInput = false;
        scoreText.enabled = false;
        finalScoreText.text = "Final Score:  " + score;
        restartButton.gameObject.SetActive(true);
        titleButton.gameObject.SetActive(true);
        finalScoreText.gameObject.SetActive(true);
        //GameOver.SetActive(true);
        //isGameOver = true;
    }
}
