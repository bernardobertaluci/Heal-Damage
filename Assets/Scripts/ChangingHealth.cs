using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingHealth : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    private int _healthValue = 10;
    private int _damageValue = 10;

    public void TakeDamage()
    {
        _healthBar.SetHandleValueDamage(_damageValue);
    }

    public void TakeHeal()
    {
        _healthBar.SetHandleValueHeal(_healthValue);
    }
}
