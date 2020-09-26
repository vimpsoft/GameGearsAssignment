using UnityEngine;
using UnityEngine.UI;

public abstract class CharacteristicPresenterBase<T> : MonoBehaviour
{
    [SerializeField]
    protected Image _image;
    [SerializeField]
    protected Text _text;

    public abstract void Initialize(T characteristic);
}