using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class ClickCounterScript : MonoBehaviour
{
    private int score = 0;
    private string saveFilePath;

    [SerializeField] private TMP_Text clickCounterText;

    [SerializeField] private Button clickButton;
    [SerializeField] private Button mainMenuButton;
    
    [SerializeField] private string mainMenuSceneName;

    private void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "score.txt");
        if (File.Exists(saveFilePath))
        {
            score = int.Parse(File.ReadAllText(saveFilePath));
        }

        UpdateScoreText();

        clickButton.onClick.AddListener(OnClick);
        mainMenuButton.onClick.AddListener(BackToMainMenu);
    }

    private void OnClick()
    {
        score++;
        UpdateScoreText();
    }

    private void BackToMainMenu()
    {
        SaveScore();
        SceneManager.LoadScene(mainMenuSceneName);
    }

    private void OnApplicationQuit()
    {
        SaveScore();
    }

    private void UpdateScoreText()
    {
        clickCounterText.text = score.ToString();
    }

    private void SaveScore()
    {
        Debug.Log("Сохранение очков...");
        File.WriteAllText(saveFilePath, score.ToString());
    }
}
