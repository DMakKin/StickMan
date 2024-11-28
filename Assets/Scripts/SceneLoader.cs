using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Метод для загрузки сцены по имени
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Метод для загрузки сцены по индексу
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Метод для выхода из игры
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Игра завершена!"); // Для проверки в редакторе
    }
}


