using UnityEngine;
using System.IO;

/// <summary>
/// Класс занимается загрузкой и сохранением очков в файл.
/// </summary>
public class ScoreLoader : MonoBehaviour
{
    private string saveFilePath;

    public ScoreLoader()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "score.txt");
    }

    public int LoadScore()
    {
        if (File.Exists(saveFilePath))
        {
            string scoreString = File.ReadAllText(saveFilePath);
            if (int.TryParse(scoreString, out int loadedScore))
            {
                return loadedScore;
            }
            else
            {
                Debug.LogWarning("Failed to parse saved score. Resetting to 0.");
                return 0;
            }
        }
        return 0;
    }
    
    public void SaveScore(int score)
    {
        Debug.Log("Сохранение очков...");
        File.WriteAllText(saveFilePath, score.ToString());
    }
}
