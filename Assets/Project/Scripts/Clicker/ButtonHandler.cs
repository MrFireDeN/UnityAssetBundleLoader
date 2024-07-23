using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Класс обрабатывает события нажатия и навигации по главному меню.
/// </summary>
public class ButtonHandler : MonoBehaviour
{
    [Header("Навигация")]
    [SerializeField] private Button clickButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private string mainMenuSceneName;

    [Header("Очки")]
    [SerializeField] private Score score;
    [SerializeField] private ClickerUI clickerUI;

    private void Start()
    {
        clickButton.onClick.AddListener(OnClick);
        mainMenuButton.onClick.AddListener(BackToMainMenu);
    }

    private void OnClick()
    {
        score.IncreaseScore();
        clickerUI.UpdateScoreText();
    }

    private void BackToMainMenu()
    {
        score.SaveScore();
        SceneManager.LoadScene(mainMenuSceneName);
    }

    private void OnDestroy()
    {
        clickButton.onClick.RemoveListener(OnClick);
        mainMenuButton.onClick.RemoveListener(BackToMainMenu);
    }
}
