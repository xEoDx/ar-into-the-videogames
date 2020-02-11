using System.Linq;
using UnityEngine;

public class BasketballPool
{
    private GameObject basketballPrefab;

    [Range(1, 20)] private int basketballPoolSize = 10;

    private readonly Basketball[] _basketBallPool;
    private readonly Transform _parentBasketballObjectTransform;

    public BasketballPool(GameObject basketballPrefab, int basketballPoolSize, Transform parentObjectTransform = null)
    {
        this.basketballPrefab = basketballPrefab;
        this.basketballPoolSize = basketballPoolSize;

        _basketBallPool = new Basketball[basketballPoolSize];
        _parentBasketballObjectTransform = parentObjectTransform;
    }

    public void Init()
    {
        for (int i = 0; i < basketballPoolSize; i++)
        {
            var basketballGameObject = GameObject.Instantiate(basketballPrefab, _parentBasketballObjectTransform);
            _basketBallPool[i] = basketballGameObject.GetComponent<Basketball>();
        }
    }

    public void ShootBall(float speed)
    {
        var basketball = _basketBallPool.First(o => !o.IsActive());
        if (basketball != null)
        {
            basketball.Shoot(speed);
        }
    }
}