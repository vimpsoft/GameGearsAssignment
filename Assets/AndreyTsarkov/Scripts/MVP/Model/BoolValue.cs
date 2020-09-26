using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(BoolValue), menuName = "GameGears/" + nameof(BoolValue), order = 0)]
public class BoolValue : ScriptableObject
{
    public event Action<bool> OnUpdate;
    public bool Value
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
    private bool _value;
}
