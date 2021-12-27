using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    public event UnityAction HealthChanged;

    private float _health;
    private int _healValue = 10;
    private int _damageValue = 10;

    public float HealthValue => _health;

    public void TakeDamage()
    {
        if (_health + _damageValue <= _healthBar.maxValue)
        { 
            _health += _damageValue;
            HealthChanged?.Invoke();
        }           
    }

    public void TakeHeal()
    {
        if (_health - _healValue >= _healthBar.minValue)
        {
            _health -= _healValue;
            HealthChanged?.Invoke();
        }         
    }
}
