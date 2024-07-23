using UnityEngine;

/// <summary>
/// Класс управляет очками, включая обновление и делегирование операций загрузки/сохранения ScoreLoader.
/// /// </summary>
public class Score : MonoBehaviour
{
    private int score;
    private ScoreLoader scoreLoader;
    
    private void Awake()
    {
        scoreLoader = new ScoreLoader();
        score = scoreLoader.LoadScore();
    }
    
    public void IncreaseScore()
    {
        score++;
        Debug.Log("Клик!");
    }

    public void SaveScore()
    {
        scoreLoader.SaveScore(score);
    }

    private void OnApplicationQuit()
    {
        SaveScore();
    }

    public int GetScore()
    {
        return score;
    }
}
