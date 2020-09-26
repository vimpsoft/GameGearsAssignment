using UnityEngine;

public class StatsPresenter : MonoBehaviour
{
    [SerializeField]
    private PlayerModel _playerModel;

    [SerializeField]
    private StatsView _view;

    private void Start() => _playerModel.OnModelUpdate += _view.DrawStats;
}
