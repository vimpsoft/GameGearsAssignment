using System.Collections.Generic;
using UnityEngine;

public class StatsView : MonoBehaviour
{
    [SerializeField]
    private PlayerPanelHierarchy _playerPanelHierarchy;
    [SerializeField]
    private GameObject _statPrefab;

    private List<GameObject> _showedStats = new List<GameObject>();

    public void DrawStats(IEnumerable<Stat> stats)
    {
        for (int i = 0; i < _showedStats.Count; i++)
            Destroy(_showedStats[i]);
        _showedStats.Clear();

        foreach (var stat in stats)
        {
            var newStatPresenter = Instantiate(_statPrefab).GetComponent<StatPresenter>();
            newStatPresenter.transform.SetParent(_playerPanelHierarchy.statsPanel);
            _showedStats.Add(newStatPresenter.gameObject);

            newStatPresenter.Initialize(stat);
        }
    }
}
