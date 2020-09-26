using System;
using System.Collections.Generic;
using UnityEngine;

public class BuffsView : MonoBehaviour
{
    [SerializeField]
    private PlayerPanelHierarchy _playerPanelHierarchy;
    [SerializeField]
    private GameObject _statPrefab;

    private List<GameObject> _showedStats = new List<GameObject>();

    internal void DrawBuffs(IEnumerable<Buff> buffs)
    {
        for (int i = 0; i < _showedStats.Count; i++)
            Destroy(_showedStats[i]);
        _showedStats.Clear();

        foreach (var buff in buffs)
        {
            var newStatPresenter = Instantiate(_statPrefab).GetComponent<BuffPresenter>();
            newStatPresenter.transform.SetParent(_playerPanelHierarchy.transform);
            _showedStats.Add(newStatPresenter.gameObject);

            newStatPresenter.Initialize(buff);
        }
    }
}
