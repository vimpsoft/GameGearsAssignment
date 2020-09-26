using UnityEngine;

public class BuffsPresenter : MonoBehaviour
{
    [SerializeField]
    private PlayerModel _playerModel;

    [SerializeField]
    private BuffsView _view;

    private void Start() => _playerModel.OnModelUpdate += _view.DrawBuffs;
}
