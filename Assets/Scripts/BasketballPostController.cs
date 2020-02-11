﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballPostController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Basket!");   
        }
    }
}