using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private const float SwipeMagnitudeThreshold = 300;

    public delegate void OnSwipeEvent(float speed);
    public event OnSwipeEvent OnSwipe;
    
    private float _currentSwipeMagnitude;
    private Vector2 _currentSwipe;
    private Vector2 _initialPosition;
    private Vector2 _finalPosition;
    private float _swipeSpeed;
    private float _swipeEndTime;
    private float _swipeInitialTime;


    void Update()
    {
        CheckTouchSwipe();

        CheckMouseSwipe();
    }

    private void CheckMouseSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _swipeInitialTime = Time.time;
            _initialPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _swipeEndTime = Time.time;
            _finalPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            _currentSwipe = new Vector2(_finalPosition.x - _initialPosition.x, _finalPosition.y - _initialPosition.y);

            if (_currentSwipe.magnitude > SwipeMagnitudeThreshold)
            {
                LaunchSwipeEvent();
            }
        }
    }

    private void CheckTouchSwipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                _swipeInitialTime = Time.time;
                _initialPosition = new Vector2(t.position.x, t.position.y);
            }

            if (t.phase == TouchPhase.Ended)
            {
                _swipeEndTime = Time.time;
                _finalPosition = new Vector2(t.position.x, t.position.y);
                _currentSwipe = new Vector3(_finalPosition.x - _initialPosition.x, _finalPosition.y - _initialPosition.y);

                if (_currentSwipe.magnitude > SwipeMagnitudeThreshold)
                {
                    LaunchSwipeEvent();
                }
            }
        }
    }

    private void LaunchSwipeEvent()
    {
        if (OnSwipe != null)
        {
            _swipeSpeed = Mathf.Clamp(30 / Mathf.Abs(_swipeEndTime - _swipeInitialTime), 100, 300);
            Debug.Log("Swipe speed> "+_swipeSpeed);
            OnSwipe(_swipeSpeed);
        }
    }
}