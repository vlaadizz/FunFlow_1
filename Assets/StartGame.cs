using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void PlayGame()
    {
        // Загружаем сцену с игрой
        SceneManager.LoadScene("SampleScene");
    }
}
