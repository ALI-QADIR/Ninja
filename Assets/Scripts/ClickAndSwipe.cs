using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class ClickAndSwipe : MonoBehaviour
{
    private GameManager _gameManager;
    private Camera _camera;
    private Vector3 _mousePos;
    private TrailRenderer _trail;
    private BoxCollider _collider;
    private bool _swiping = false;

    private void Awake()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _camera = Camera.main;
        _trail = GetComponent<TrailRenderer>();
        _collider = GetComponent<BoxCollider>();
        _trail.enabled = false;
        _collider.enabled = false;
    }

    private void UpdateMousePos()
    {
        _mousePos = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        transform.position = _mousePos;
    }

    private void UpdateComponents()
    {
        _trail.enabled = _swiping;
        _collider.enabled = _swiping;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _swiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _swiping = false;
                UpdateComponents();
            }
            if (_swiping)
            {
                UpdateMousePos();
            }
        }
    }
}