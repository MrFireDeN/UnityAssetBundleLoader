using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Управляет функциональностью счетчика кликов, включая обновление счета, 
/// сохранение и загрузку счета, а также взаимодействие с пользовательским интерфейсом.
/// </summary>
public class ClickCounterScript : MonoBehaviour
{
    private int score = 0;
    private string saveFilePath;

    [SerializeField] private TMP_Text clickCounterText;
    [SerializeField] private Button clickButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private string mainMenuSceneName;
    
    /// <summary>
    /// Вызывается при загрузке экземпляра скрипта.
    /// Инициализирует путь к файлу сохранения и загружает сохраненный счет.
    /// </summary>
    private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "score.txt");
        LoadScore();
        UpdateScoreText();
    }
    
    /// <summary>
    /// Вызывается, когда объект становится включенным и активным.
    /// Добавляет слушателей событий для кнопок.
    /// </summary>
    private void OnEnable()
    {
        clickButton.onClick.AddListener(OnClick);
        mainMenuButton.onClick.AddListener(BackToMainMenu);
    }

    /// <summary>
    /// Вызывается, когда объект становится отключенным.
    /// Удаляет слушателей событий с кнопок.
    /// </summary>
    private void OnDisable()
    {
        clickButton.onClick.RemoveListener(OnClick);
        mainMenuButton.onClick.RemoveListener(BackToMainMenu);
    }

    /// <summary>
    /// Увеличивает счет на единицу, обновляет отображаемый счет и сохраняет его.
    /// </summary>
    private void OnClick()
    {
        score++;
        UpdateScoreText();
    }

    /// <summary>
    /// Сохраняет текущий счет и загружает сцену главного меню.
    /// </summary>
    private void BackToMainMenu()
    {
        SaveScore();
        SceneManager.LoadScene(mainMenuSceneName);
    }

    /// <summary>
    /// Вызывается, когда приложение собирается выйти из игры.
    /// Сохраняет текущий счет.
    /// </summary>
    private void OnApplicationQuit()
    {
        SaveScore();
    }

    /// <summary>
    /// Обновляет отображаемый текст оценки.
    /// </summary>
    private void UpdateScoreText()
    {
        clickCounterText.text = score.ToString();
    }

    /// <summary>
    /// Сохраняет текущий счет в файл.
    /// </summary>
    private void SaveScore()
    {
        Debug.Log("Сохранение очков...");
        File.WriteAllText(saveFilePath, score.ToString());
    }
    
    /// <summary>
    /// Загружает сохраненную оценку из файла.
    /// Если файл не существует или его содержимое недействительно, оценка будет установлена в 0.
    /// </summary>
    private void LoadScore()
    {
        if (File.Exists(saveFilePath))
        {
            string scoreString = File.ReadAllText(saveFilePath);
            if (int.TryParse(scoreString, out int loadedScore))
            {
                score = loadedScore;
            }
            else
            {
                Debug.LogWarning("Ошибка при открытии файла. Кол-во очков установлено на 0.");
                score = 0;
            }
        }
    }
}
