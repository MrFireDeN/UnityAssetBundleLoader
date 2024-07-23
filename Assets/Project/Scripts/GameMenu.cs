using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Обрабатывает действия игрового меню, такие как загрузка игровой сцены или выход из приложения.
/// </summary>
public class GameMenu : MonoBehaviour
{
    /// <summary>
    /// Загружает указанную игровую сцену, если имя сцены действительно.
    /// </summary>
    /// <param name="sceneName">Имя сцены, которую нужно загрузить.</param>
    public void LoadGame(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            try
            {
                SceneManager.LoadScene(sceneName);
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Не удалось загрузить сцену {sceneName}: {ex.Message}");
            }
        }
        else
        {
            Debug.LogWarning("Попытка загрузить сцену с недопустимым именем.");
        }
    }

    /// <summary>
    /// Выход из приложения.
    /// </summary>
    public void Quit()
    {
        Debug.Log("Выход из приложения...");
        Application.Quit();
    }
}