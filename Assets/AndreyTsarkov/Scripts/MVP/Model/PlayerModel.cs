using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Делаю интерфейсы, чтобы ограничить модифицируемость модели. Для полного счастья надо 
/// бы сделать еще из Stat и Buff структуры, но не буду менять фреймворк.
/// </summary>
public class PlayerModel : MonoBehaviour, IEnumerable<Stat>, IEnumerable<Buff>
{
    public event Action<PlayerModel> OnModelUpdate;

    [SerializeField]
    private GameModelValue _gameModel;

    [SerializeField]
    private FloatValue _chanceOfBuff;
    [SerializeField]
    private BoolValue _allowBuffs;

    private List<Buff> _buffs = new List<Buff>(); //Мы заранее не знаем сколько будет баффов и будут ли вообще
    private Stat[] _stats; //А вот кол-во статов мы знаем заранее

    private void Start()
    {
        _gameModel.OnModelUpdate += model => initialize(model.stats, model.buffs);
        
        void initialize(Stat[] stats, Buff[] buffs)
        {
            _buffs.Clear();
            _stats = new Stat[stats.Length];

            for (int i = 0; i < stats.Length; i++)
                _stats[i] = stats[i].Clone();
            if (_allowBuffs.Value)
                for (int i = 0; i < buffs.Length; i++)
                {
                    if (UnityEngine.Random.Range(0f, 1f) < _chanceOfBuff.Value)
                    {
                        _buffs.Add(buffs[i]);
                        for (int j = 0; j < buffs[i].stats.Length; j++)
                            _stats[buffs[i].stats[j].statId].value += buffs[i].stats[j].value;
                    }
                    else
                        continue;
                }

            OnModelUpdate?.Invoke(this);
        }
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
