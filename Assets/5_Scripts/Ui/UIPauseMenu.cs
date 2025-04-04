using UnityEngine;
using UnityUtils;

public class UIPauseMenu : Singleton<UIPauseMenu>
{
    [SerializeField] private GameObject screen;
    public void OnEnable()
    {
        PlayerInputManager.Instance.onESCPressed += OnESCPressed;
    }
    private void OnDisable()
    {
        PlayerInputManager.Instance.onESCPressed -= OnESCPressed;
    }
    public void OnESCPressed()
    {
        screen.SetActive(!screen.activeInHierarchy);
    }

    public void ReturnToMainMenu()
    {
        SceneSwitcher.Instance.ReturnToMainMenu();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
