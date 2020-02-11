using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class BasketballGameController : MonoBehaviour
{
    [SerializeField] private Transform imageTargetObject;
    
    [SerializeField] private GameObject basketballPrefab;

    [SerializeField, Range(1, 20)] private int poolSize = 10;

    private BasketballPool _basketballPool;

    private ShootData _shootData;

    void Start()
    {
        _basketballPool = new BasketballPool(basketballPrefab, poolSize, imageTargetObject);
        _basketballPool.Init();
        _shootData = new ShootData();
    }

    public void ApplyDirection(int direction)
    {
        _shootData.shootDirection = (ShootData.Direction) direction;
    }

    public void ApplySpeed(float speed)
    {
        _shootData.shootSpeed = speed;
    }

    public void Shoot()
    {
        var shootDirection = _shootData.GetShootDirection();
        _basketballPool.ShootBall(shootDirection, _shootData.shootSpeed);
    }

    public class ShootData
    {
        public enum Direction
        {
            N = 1,
            NE = 2,
            E = 3,
            NW = 4,
            W = 5,

            COUNT,
            INVALID
        }

        public Direction shootDirection;
        public float shootSpeed;

        public Vector3 GetShootDirection()
        {
            Vector3 direction = Vector3.zero;

            var compensationFactor = 0.2f;
            switch (shootDirection)
            {
                case Direction.N:
                    direction = Vector3.forward + Vector3.up * compensationFactor;
                    break;
                case Direction.NE:
                    direction = Vector3.forward + Vector3.up * compensationFactor + Vector3.right;
                    break;
                case Direction.NW:
                    direction = Vector3.forward + Vector3.up * compensationFactor + Vector3.left;
                    break;
                case Direction.W:
                    direction = Vector3.forward + Vector3.up * compensationFactor + Vector3.left;
                    break; 
                case Direction.E:
                    direction = Vector3.forward + Vector3.up * compensationFactor + Vector3.right;
                    break;
            }

            return direction;
        }
        
    }
}