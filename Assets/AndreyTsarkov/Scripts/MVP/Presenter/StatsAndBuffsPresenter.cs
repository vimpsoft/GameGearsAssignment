using UnityEngine;

/// <summary>
/// StatsAndBuffs нужен для того, чтобы проконтролировать очередность заполнения статов и баффов.
/// Можно было бы и не контролировать, тогда можно было бы сделать отдельные презентеры для статов и для баффов,
/// но тогда для контроля очередности надо было бы менять ui-лейаут, а лучше не трогать фреймворк, если есть
/// такая возможность
/// </summary>
public class StatsAndBuffsPresenter : MonoBehaviour
{
    [SerializeField]
    private PlayerModel _playerModel;

    [SerializeField]
    private StatsAndBuffsView _view;

    private void Start() => _playerModel.OnModelUpdate += _view.DrawStatsAndBuffs;
}
