using UnityEngine;
using UnityEngine.UI; // Это нужно для работы с текстом

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;       // Переменная для хранения очков
    public TMPro.TMP_Text scoreText;

    void Start()
    {
        score = 0;                     // При старте игры очки равны 0
        UpdateScoreUI();               // Обновляем текст на экране
    }

    // Эту функцию мы будем вызывать из других скриптов, когда разрезаем фрукт
    public static void AddScore(int points)
    {
        score += points;               // Добавляем очки

        // Находим этот скрипт в игре и обновляем текст
        ScoreManager instance = FindObjectOfType<ScoreManager>();
        if (instance != null)
        {
            instance.UpdateScoreUI();
        }
    }

    // Эта функция просто меняет текст на экране
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Очки: " + score;
        }
    }
}
