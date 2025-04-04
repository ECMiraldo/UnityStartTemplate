using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneSwitcher.Instance.StartGameplaySession();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
