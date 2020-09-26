using UnityEngine;
using UnityEngine.UI;

public class BuffPresenter : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Text _title;

    internal void Initialize(Buff model)
    {
        _image.sprite = Resources.Load<Sprite>($"Icons/{model.icon}");
        _title.text = model.title;
    }
}
