using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(FloatValue), menuName = "GameGears/" + nameof(FloatValue), order = 0)]
public class FloatValue : ScriptableObject
{
    public event Action<float> OnUpdate;
    public float Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                OnUpdate?.Invoke(value);
            }
        }
    }
    [SerializeField]
    private float _value;
}
