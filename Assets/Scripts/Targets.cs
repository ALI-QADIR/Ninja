using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Targets : MonoBehaviour
{
    [SerializeField] private float _minSpeed = 12f;
    [SerializeField] private float _maxSpeed = 16f;
    [SerializeField] private float _maxTorque = 10f;
    [SerializeField] private float _xRange = 4f;
    [SerializeField] private float _ySpawnPos = -6f;

    private Rigidbody _targetRb;

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

    // Update is called once per frame
    private void Update()
    {
    }
}