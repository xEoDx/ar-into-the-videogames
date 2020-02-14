using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballPostController : MonoBehaviour
{
    private BasketballGameController _basketballController;
  
    private void Start()
    {
        _basketballController = FindObjectOfType<BasketballGameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            _basketballController.Score();
        }
    }
}