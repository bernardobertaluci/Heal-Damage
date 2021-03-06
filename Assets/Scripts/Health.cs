using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    public Action<float> HealthChanged;

    private float _health;
    private int _healValue = 11;
    private int _damageValue = 11;

    private void Start()
    {
        _health = _healthBar.value;
    }
    public void TakeDamage()
    {
        if (_health > _healthBar.minValue)
        {
            _health = Mathf.Max(_health - _damageValue, _healthBar.minValue);

            HealthChanged?.Invoke(_health);
        }
    }

    public void TakeHeal()
    {
        if(_health < _healthBar.maxValue)
        {
            _health = Mathf.Min(_health + _healValue, _healthBar.maxValue);

            HealthChanged?.Invoke(_health);
        }  
    }
}
