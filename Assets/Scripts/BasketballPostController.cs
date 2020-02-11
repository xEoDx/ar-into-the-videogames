using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballPostController : MonoBehaviour
{
    public delegate void OnScoreEvent();

    public event OnScoreEvent OnScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (OnScore != null)
            {
                OnScore();
            }
        }
    }
}