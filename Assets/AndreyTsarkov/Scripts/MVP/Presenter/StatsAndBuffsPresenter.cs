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

    private void Start()
    {
        _playerModel.OnModelUpdate += _view.DrawStatsAndBuffs;

        //Когда меняется значение жизни нам надо обновлять вид StatView
        //По-нормальному надо бы в класс Stat заделать эвент изменения и подписывать его 
        //в StatPresenter на обновление вьюхи, но раз уж я не меняю предоставленный код, то просто перестраиваем всю вьюху
        _playerModel.OnHealthChange += (_, __, ___) => _view.DrawStatsAndBuffs(_playerModel);
    }
}
