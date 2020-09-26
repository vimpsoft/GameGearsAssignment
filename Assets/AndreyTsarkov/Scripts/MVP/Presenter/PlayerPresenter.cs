using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour
{
    [SerializeField]
    private GameModelValue _gameModel;
    [SerializeField]
    private PlayerModel _model;

    [SerializeField]
    private BoolValue _allowBuffs;

    private void Start()
    {
        _gameModel.OnModelUpdate += model => _model.Initialize(model.stats, model.buffs, _allowBuffs.Value);
    }
}
