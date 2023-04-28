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

    [Header("Audio")]
    [SerializeField, Tooltip("Background Music")] private AudioSource _backgroundMusic;

    public bool isGameActive;

    private int _score;
    private int _lives = 3;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void StartGame(float difficulty)
    {
        _mainMenu.SetActive(false);
        _spawnRate /= difficulty;
        _scoreText.gameObject.SetActive(true);
        _livesText.gameObject.SetActive(true);
        isGameActive = true;
        _score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives();
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

    public void SetAudio(float volume)
    {
        _backgroundMusic.volume = volume;
    }
}