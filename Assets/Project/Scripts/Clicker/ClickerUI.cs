using UnityEngine;
using TMPro;

/// <summary>
/// Класс управляет обновлениями пользовательского интерфейса.
/// </summary>
public class ClickerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text clickCounterText;
    [SerializeField] private Score score;
    
    private void Start()
    {
        UpdateScoreText();
    }
    
    public void UpdateScoreText()
    {
        clickCounterText.text = score.GetScore().ToString();
    }
}
