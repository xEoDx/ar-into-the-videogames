using UnityEngine;

public class BasketballGameController : MonoBehaviour
{
    [Header("Basketball setup")]
    [SerializeField] private Transform imageTargetObject;
    
    [SerializeField] private GameObject basketballPrefab;

    [SerializeField, Range(1, 20)] private int poolSize = 10;

    [Header("Points configuration")] [SerializeField]
    private int basketballScorePoints = 10;
    [SerializeField]
    private int gameDurationSeconds = 30;

    
    public delegate void OnScoreEvent();

    public event OnScoreEvent OnScore;
    
    private const float MinTimeBetweenShoots = 0.5f;
    
    private float _elapsedTime;
    public float ElapsedTime
    {
        get { return _elapsedTime; }
    }
    
    private float _totalPoints;
    public float TotalPoints
    {
        get { return _totalPoints; }
    }


    private enum State
    {
        AWAITING,
        PLAYING,
        
        COUNT,
        INVALID
    }

    private State _state;
    private BasketballPool _basketballPool;
    private InputController _inputController;

    private float _lastShootTime;
    

    private void Start()
    {
        _state = State.AWAITING; 
        
        _inputController = FindObjectOfType<InputController>();
        _inputController.OnSwipe += OnSwipeListener;
        _basketballPool = new BasketballPool(basketballPrefab, poolSize, imageTargetObject);
        _basketballPool.Init();
    }

    private void Update()
    {
        if (_state == State.PLAYING)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > gameDurationSeconds)
            {
                //TODO trigger game end
                StopGameplay();
            }
        }

        _lastShootTime += Time.deltaTime;
    }


    public void Score()
    {
        _totalPoints += basketballScorePoints;

        OnScore?.Invoke();
    }

    private void OnSwipeListener(float speed)
    {
        if (_lastShootTime > MinTimeBetweenShoots)
        {
            Shoot(speed);
            _lastShootTime = 0;
        }
    }

    public void Shoot(float speed)
    {
        _basketballPool.ShootBall(speed);
    }

    public void StartGameplay()
    {
        _state = State.PLAYING;
    }

    public void StopGameplay()
    {
        _state = State.AWAITING;
    }
}