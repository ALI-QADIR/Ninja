using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Tooltip("List of target game objects")] public List<GameObject> targets;

    [SerializeField, Tooltip("Spawn Rate of the targets")] private float _spawnRate = 1f;
    [SerializeField, Tooltip("Score text")] private TextMeshProUGUI _scoreText;

    private int _score;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnTarget());
        _score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
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
}