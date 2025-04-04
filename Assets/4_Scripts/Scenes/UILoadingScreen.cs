using UnityEngine;
using UnityEngine.UI;

public class UILoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private Slider slider;

    private void Awake()
    {
        canvas.SetActive(false);
    }

    public void Show()
    {
        canvas.SetActive(true);
    } 

    public void UpdateValue(float val)
    {
        slider.value = val;
    }

    public void Hide()
    {
        canvas.SetActive(false);
    }
}
