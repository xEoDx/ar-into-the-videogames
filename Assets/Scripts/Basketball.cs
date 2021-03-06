﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour
{
    private const float AliveTimeThreshold = 3;
    
    private bool _isActive;
    private Rigidbody _rigidbody;
    private Camera _mainCamera;
    private float _elapsedTime;

    private void Start()
    {
        _mainCamera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
        _isActive = false;
        Hide();
    }

    private void Update()
    {
        if (_isActive)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > AliveTimeThreshold)
            {
                Hide();
            }
        }
    }

    public bool IsActive()
    {
        return _isActive;
    }

    public void Shoot(float speed)
    {
        Show();
        var cameraTransform = _mainCamera.transform;
        transform.position = cameraTransform.position + cameraTransform.forward * 0.1f - cameraTransform.up * 0.2f;
        var shootDirection = cameraTransform.forward + cameraTransform.up * 0.5f;

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(shootDirection * speed);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        _isActive = false;
    }

    private void Show()
    {
        _elapsedTime = 0;
        gameObject.SetActive(true);
        _isActive = true;
    }
}
