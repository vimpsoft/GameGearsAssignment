using UnityEngine;

public class BuffPresenter : CharacteristicPresenterBase<Buff>
{
    public override void Initialize(Buff characteristic)
    {
        _image.sprite = Resources.Load<Sprite>($"Icons/{characteristic.icon}"); //Это можно было бы вынести в базовый класс, но тогда нужно было бы объединять Buff и Stat в один интерфейс, не уверен, что предполагается изменение кода, предоставленного для задания
        _text.text = characteristic.title;
    }
}