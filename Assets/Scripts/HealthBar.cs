using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Health _health;

    private int _changeValue;

    private void Start()
    {
        _health = GetComponent<Health>();

        _changeValue = 10;
    }
    public void SetHandleValueDamage()
    {
        _health.ChangeVolume(_health.GetCurrentHealthValue() + _changeValue);
    }

    public void SetHandleValueHeal()
    {
        _health.ChangeVolume(_health.GetCurrentHealthValue() - _changeValue);
    }
}
