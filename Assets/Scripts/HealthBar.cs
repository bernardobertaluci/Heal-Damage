using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;

    private float _rate;

    private IEnumerator _currentCoroutine;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }
    private void Start()
    {
        _slider = GetComponent<Slider>();
        _rate = 10f;
    }

    private void ChangeHandle(float value)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = HandleChanging(value);

        StartCoroutine(_currentCoroutine);
    }

    private IEnumerator HandleChanging(float value)
    {
        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _rate * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }

    private void OnHealthChanged(float value)
    {
        ChangeHandle(value);
    }
}
