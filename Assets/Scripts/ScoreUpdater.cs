using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreUpdater : MonoBehaviour
{
    private Text _text;
    private BasketballGameController _basketballGameController;
    
    private void Start()
    {
        _text = GetComponent<Text>();
        
        _basketballGameController = FindObjectOfType<BasketballGameController>();
        _basketballGameController.OnScore += OnScoreListener;
        
        UpdateText();
    }

    private void OnScoreListener()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = _basketballGameController.TotalPoints.ToString();
    }
}
