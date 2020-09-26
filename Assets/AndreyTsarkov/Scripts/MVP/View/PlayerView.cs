using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private PlayerPanelHierarchy _hierarchy;
    [SerializeField]
    private RectTransform _healtContainer;
    [SerializeField]
    private Transform _player3DModelTransform;

    [SerializeField]
    private GameObject _healthBubblePrefab;

    [SerializeField]
    private float _healthBubbleStartHeight = 2f;

    [SerializeField]
    private HealthBarView _healthBarView;

    private void Start()
    {
        _healthBarView.transform.SetParent(_healtContainer);
        _healthBarView.transform.localPosition = Vector3.zero;
        _healthBarView.transform.localScale = Vector3.one;
        _healthBarView.transform.localRotation = Quaternion.identity;
    }

    internal void PerformPunch() => _hierarchy.character.SetTrigger("Attack");
    internal void ShowHealthChange(float currentHealth, float maxHealth, float delta)
    {
        _healthBarView.ShowHealth(currentHealth / maxHealth, ((int)currentHealth).ToString());

        if (delta != 0)
        {
            var healthChangedPresenter = Instantiate(_healthBubblePrefab).GetComponent<HealthChangedPresenter>();
            healthChangedPresenter.Initialize(delta);
            healthChangedPresenter.transform.position = _player3DModelTransform.position + Vector3.up * _healthBubbleStartHeight;

            _hierarchy.character.SetInteger("Health", (int)currentHealth);
        }
    }
}
