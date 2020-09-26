using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void HealthChangeDelegate(float currentHealth, float maxHealth, float delta); //Определяю делегат явно, потому что тут три флоата, надо чтоб не путались назвать каждый

public class PlayerModel : MonoBehaviour, IEnumerable<Stat>, IEnumerable<Buff>
{
    public event HealthChangeDelegate OnHealthChange;
    public event Action<PlayerModel> OnModelUpdate;
    public event Action<float> OnAttack;

    public Stat this[int statIndex]
    {
        get => _stats[statIndex];
        private set => _stats[statIndex] = value;
    }

    [SerializeField]
    private GameModelValue _gameModel;

    [SerializeField]
    private FloatValue _chanceOfBuff;

    [SerializeField]
    private BoolValue _allowBuffs;

    private List<Buff> _buffs = new List<Buff>(); //Мы заранее не знаем сколько будет баффов и будут ли вообще

    //А вот кол-во статов мы знаем заранее
    private Stat[] _stats; //Тут мы храним текущие значения
    private Stat[] _initialStats; //А тут изначальные (потому что значения могут меняться по ходу боя и нам надо иногда знать изначальную инфу, как, например, со здоровьем)

    private void Start()
    {
        _gameModel.OnModelUpdate += model => initialize(model.stats, model.buffs);

        void initialize(Stat[] stats, Buff[] buffs)
        {
            _buffs.Clear();
            _initialStats = new Stat[stats.Length];

            cloneStats(stats, _initialStats);
            if (_allowBuffs.Value)
                for (int i = 0; i < buffs.Length; i++)
                {
                    if (UnityEngine.Random.Range(0f, 1f) < _chanceOfBuff.Value)
                    {
                        _buffs.Add(buffs[i]);
                        for (int j = 0; j < buffs[i].stats.Length; j++)
                            _initialStats[buffs[i].stats[j].statId].value += buffs[i].stats[j].value;
                    }
                    else
                        continue;
                }

            var initialDelta = _stats == default ? 0 : _initialStats[StatsId.LIFE_ID].value - _stats[StatsId.LIFE_ID].value;

            _stats = new Stat[stats.Length];
            cloneStats(_initialStats, _stats);

            OnModelUpdate?.Invoke(this);
            OnHealthChange?.Invoke(_initialStats[StatsId.LIFE_ID].value, _initialStats[StatsId.LIFE_ID].value, initialDelta);
        }

        void cloneStats(Stat[] from, Stat[] to)
        {
            for (int i = 0; i < from.Length; i++)
                to[i] = from[i].Clone();
        }
    }

    public void PerformAttack()
    {
        if (_stats[StatsId.LIFE_ID].value > 0)
            OnAttack?.Invoke(_stats[StatsId.DAMAGE_ID].value);
    }

    internal void AcceptHealthDelta(float delta)
    {
        //мы получаем изменение hp, но оно может быть больше чем мы можем принять, поэтому сначала вычисляем реальное значение дельты
        var newLife = Mathf.Clamp(this[StatsId.LIFE_ID].value + delta, 0, _initialStats[StatsId.LIFE_ID].value); //Столько будет у нас жизни после применения дельты
        var realDelta = newLife - this[StatsId.LIFE_ID].value; //Вот столько мы можем принять
        this[StatsId.LIFE_ID].value = newLife;
        OnHealthChange?.Invoke(this[StatsId.LIFE_ID].value, _initialStats[StatsId.LIFE_ID].value, realDelta);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator<Stat> IEnumerable<Stat>.GetEnumerator()
    {
        for (int i = 0; i < _stats.Length; i++)
            yield return _stats[i];
    }

    IEnumerator<Buff> IEnumerable<Buff>.GetEnumerator()
    {
        for (int i = 0; i < _buffs.Count; i++)
            yield return _buffs[i];
    }
}
