using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Targets : MonoBehaviour
{
    [Header("Target Specifics")]
    public int pointValue;

    [SerializeField, Tooltip("Particle system to be played on explosion")] private ParticleSystem _explosionParticle;

    [Header("Physics Settings")]
    [SerializeField] private float _minSpeed = 12f;

    [SerializeField] private float _maxSpeed = 16f;
    [SerializeField] private float _maxTorque = 10f;
    [SerializeField] private float _xRange = 4f;
    [SerializeField] private float _ySpawnPos = -6f;

    private Rigidbody _targetRb;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
        _targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos);
    }

    private void OnMouseDown()
    {
        if (!_gameManager.isGameActive) return;
        Destroy(gameObject);
        Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
        _gameManager.UpdateScore(pointValue);
        if (gameObject.CompareTag("Bad"))
            _gameManager.LoseLife();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sensor"))
        {
            if (!gameObject.CompareTag("Bad"))
                _gameManager.LoseLife();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}