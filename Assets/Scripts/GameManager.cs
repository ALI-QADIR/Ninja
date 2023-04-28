using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Tooltip("List of target game objects")] public List<GameObject> targets;

    [SerializeField, Tooltip("Spawn Rate of the targets")] private float _spawnRate = 1f;

    [Header("UI Elements")]
    [SerializeField, Tooltip("Score text")] private TextMeshProUGUI _scoreText;

    [SerializeField, Tooltip("Score text")] private TextMeshProUGUI _livesText;
    [SerializeField, Tooltip("Game Over text")] private GameObject _gameOver;
    [SerializeField, Tooltip("Game Over text")] private GameObject _mainMenu;
    [SerializeField, Tooltip("Game Over text")] private GameObject _pauseMenu;

    [Header("Audio")]
    [SerializeField, Tooltip("Background Music")] private AudioSource _backgroundMusic;

    public bool isGameActive;

    private bool _isPaused;

    private int _score;
    private int _lives = 3;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void StartGame(float difficulty)
    {
        _mainMenu.SetActive(false);
        _spawnRate /= difficulty;
        _scoreText.gameObject.SetActive(true);
        _livesText.gameObject.SetActive(true);
        isGameActive = true;
        _isPaused = false;
        _score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives();
    }

    public void PauseGame()
    {
        if (_isPaused)
        {
            Time.timeScale = 1;
            _pauseMenu.SetActive(false);
            _isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            _pauseMenu.SetActive(true);
            _isPaused = true;
        }
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _scoreText.text = "Score: " + _score;
    }

    public void UpdateLives()
    {
        _livesText.text = "Lives: " + this._lives;
        if (this._lives <= 0)
        {
            GameOver();
        }
    }

    public void LoseLife()
    {
        this._lives--;
        UpdateLives();
    }

    public void GameOver()
    {
        isGameActive = false;
        _gameOver.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SetAudio(float volume)
    {
        _backgroundMusic.volume = volume;
    }
}