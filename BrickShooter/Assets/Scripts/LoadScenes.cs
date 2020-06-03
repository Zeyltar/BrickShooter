using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSetting()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadShop()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
