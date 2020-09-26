using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(GameModelValue), menuName = "GameGears/" + nameof(GameModelValue), order = 0)]
public class GameModelValue : ScriptableObject
{
    public event Action<Data> OnModelUpdate;
    public Data Value;
    
    public void Initialize(TextAsset text)
    {
        Value = JsonUtility.FromJson<Data>(text.text);
        OnModelUpdate?.Invoke(Value);
    }
}
