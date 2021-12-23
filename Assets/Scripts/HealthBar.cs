using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private int _healValue;
    private int _damageValue;

    private IEnumerator _currentCoroutine;

    private void Start()
    {
        _damageValue = 10;
        _healValue = 10;
    }

    public void SetHandleValueDamage()
    {
        ChangeHandle(_health.GetCurrentHealthValue() + _damageValue);
    }

    public void SetHandleValueHeal()
    {
        ChangeHandle(_health.GetCurrentHealthValue() - _healValue);
    }

    private void ChangeHandle(float value)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = _health.HandleChanging(value);

        StartCoroutine(_currentCoroutine);
    }  
}
