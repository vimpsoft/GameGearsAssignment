﻿using System;
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

    private Stat[] _stats;
    private Buff[] _buffs;

    public void Initialize(Stat[] stats, Buff[] buffs, bool allowBuffs)
    {
        _buffs = buffs;

        _stats = new Stat[stats.Length];
        for (int i = 0; i < stats.Length; i++)
            _stats[i] = stats[i].Clone();
        if (allowBuffs)
            for (int i = 0; i < buffs.Length; i++)
                for (int j = 0; j < buffs[i].stats.Length; j++)
                    _stats[buffs[i].stats[j].statId].value += buffs[i].stats[j].value;

        OnModelUpdate?.Invoke(this);
    }

    //public IEnumerator<Stat> GetEnumerator()
    //{
    //    for (int i = 0; i < _stats.Length; i++)
    //        yield return _stats[i];
    //}

    //public IEnumerator<Buff> GetEnumerator()
    //{
    //    for (int i = 0; i < _buffs.Length; i++)
    //        yield return _buffs[i];
    //}

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
        for (int i = 0; i < _buffs.Length; i++)
            yield return _buffs[i];
    }
}