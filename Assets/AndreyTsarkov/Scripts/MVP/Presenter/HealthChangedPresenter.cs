using UnityEngine;
using UnityEngine.UI;

public class HealthChangedPresenter : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private Color _increaseColor = Color.green;
    [SerializeField]
    private Color _decreaseColor = Color.red;

    public void Initialize(float value)
    {
        _text.color = value >= 0 ? _increaseColor : _decreaseColor;
        _text.text = ((int)value).ToString();
    }
}
