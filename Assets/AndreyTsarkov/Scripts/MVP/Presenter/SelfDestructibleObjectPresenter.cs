using System;
using UnityEngine;

public class SelfDestructibleObjectPresenter : MonoBehaviour
{
    public event Action OnBeforeDestroy;

    [SerializeField]
    private float _timeBeforeDestruction;

    private void Start() => Invoke("selfDestruct", _timeBeforeDestruction);

    private void selfDestruct()
    {
        OnBeforeDestroy?.Invoke();
        Destroy(gameObject);
    }
}
