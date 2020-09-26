using UnityEngine;
using UnityEngine.UI;

public class StatPresenter : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Text _title;

    public void Initialize(Stat model)
    {
        _image.sprite = Resources.Load<Sprite>($"Icons/{model.icon}");
        _title.text = model.value.ToString(model.value % 1 == 0 ? default : "N2");
    }
}
