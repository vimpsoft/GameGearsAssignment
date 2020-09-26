using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Text _text;

    public void ShowHealth(float value, string text)
    {
        _image.fillAmount = value;
        _text.text = text;
    }
}
