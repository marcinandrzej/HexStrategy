using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderValues : MonoBehaviour
{
    [SerializeField] private Text textToUpdate = null;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate{Test();}) ;
    }

    private void Test()
    {
        textToUpdate.text = Math.Floor(slider.value * 10).ToString();
    }
}
