using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Неплохо бы конечно тут сделать уточнение какие именно Т мы хотим видеть, но это надо будет делать
/// интерфейс и менять код классов Buff и Stat, а я не уверен, что в задании имеется в виду менять фреймворк.
/// </summary>
/// <typeparam name="T"></typeparam>
public class PlayerCharasteristicViewBase<T> : MonoBehaviour
{
    [SerializeField]
    private PlayerPanelHierarchy _playerPanelHierarchy;
    [SerializeField]
    private GameObject _characteristicPrefab;

    private List<GameObject> _showedCharacteristics = new List<GameObject>();

    internal void DrawCharacteristics(IEnumerable<T> characteristics)
    {
        for (int i = 0; i < _showedCharacteristics.Count; i++)
            Destroy(_showedCharacteristics[i]);
        _showedCharacteristics.Clear();

        foreach (var characteristic in characteristics)
        {
            var newCaracteristicPresenter = Instantiate(_characteristicPrefab).GetComponent<CharacteristicPresenterBase<T>>();
            newCaracteristicPresenter.transform.SetParent(_playerPanelHierarchy.statsPanel);
            _showedCharacteristics.Add(newCaracteristicPresenter.gameObject);

            newCaracteristicPresenter.Initialize(characteristic);
        }
    }
}
