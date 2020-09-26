using UnityEngine;

/// <summary>
/// Тут мы делаем так, чтобы вьюха на канвасе находилась там, где находится объект в ворлдспейсе
/// </summary>
public class WorldSpaceUIPositionFollowerView : MonoBehaviour
{
    [SerializeField]
    private Transform _3DTarget;

    [SerializeField]
    private RectTransform _targetParent;
    [SerializeField]
    private RectTransform _targetRectTransform;

    [SerializeField]
    private Vector3 _offset;

    private void Update()
    {
        var point = Camera.main.WorldToScreenPoint(_3DTarget.position + _offset);

        _targetRectTransform.anchoredPosition = new Vector2(point.x, point.y);
    }
}
