using UnityEngine;

/// <summary>
/// Эта вьюха должна следить за тем, чтобы статы и баффы рисовались в нужном порядке
/// </summary>
public class StatsAndBuffsView : MonoBehaviour
{
    [SerializeField]
    private StatsView _statsView;
    [SerializeField]
    private BuffsView _buffsView;

    internal void DrawStatsAndBuffs(PlayerModel playerModel)
    {
        _statsView.DrawCharacteristics(playerModel); //Сначала заполняем статсы
        _buffsView.DrawCharacteristics(playerModel); //потом баффы
    }
}
