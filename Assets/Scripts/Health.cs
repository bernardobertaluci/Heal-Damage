using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Health : MonoBehaviour
{
    private Slider _slider;

    private float _rate;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _rate = 10f;
    }   

    public float GetCurrentHealthValue()
    {
        return _slider.value;
    }

    public IEnumerator HandleChanging(float value)
    {
        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _rate * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }
}
