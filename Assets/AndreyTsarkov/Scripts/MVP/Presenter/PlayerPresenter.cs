using UnityEngine;
using UnityEngine.UI;

public class PlayerPresenter : MonoBehaviour
{
    [SerializeField]
    private PlayerModel _model;
    [SerializeField]
    private PlayerView _view;

    [SerializeField]
    private Button _attackButton;

    private void Start()
    {
        _attackButton.onClick.AddListener(_model.PerformAttack);

        _model.OnAttack += _ => _view.PerformPunch();
        _model.OnHealthChange += _view.ShowHealthChange;
        _model.OnHealthChange += _view.ShowHealthChange;
    }
}
