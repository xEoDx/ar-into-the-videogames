using UnityEngine;

public class BasketballGameController : MonoBehaviour
{
    [SerializeField] private Transform imageTargetObject;
    
    [SerializeField] private GameObject basketballPrefab;

    [SerializeField, Range(1, 20)] private int poolSize = 10;

    private BasketballPool _basketballPool;
    private InputController _inputController;
    void Start()
    {
        _inputController = FindObjectOfType<InputController>();
        _inputController.OnSwipe += OnSwipeListener;
        _basketballPool = new BasketballPool(basketballPrefab, poolSize, imageTargetObject);
        _basketballPool.Init();
    }

    private void OnSwipeListener(float speed)
    {
        Shoot(speed);
    }

    public void Shoot(float speed)
    {
        _basketballPool.ShootBall(speed);
    } 
}