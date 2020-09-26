using UnityEngine;

public class BattleModel : MonoBehaviour
{
    [SerializeField]
    private PlayerModel _player1;
    [SerializeField]
    private PlayerModel _player2;

    private void Start()
    {
        _player1.OnAttack += dmg => attack(_player1, _player2, dmg);
        _player2.OnAttack += dmg => attack(_player2, _player1, dmg);
        
        void attack(PlayerModel attacker, PlayerModel victim, float dmg)
        {
            //Умножаем пришедший урон на значение нашей брони и получаем финальное кол-во урона
            var healthLost = dmg * victim[StatsId.ARMOR_ID].value / 100f;
            var lifeStolen = healthLost * attacker[StatsId.LIFE_STEAL_ID].value / 100f;
            victim.AcceptHealthDelta(-healthLost);
            attacker.AcceptHealthDelta(lifeStolen);
        }
    }
}
