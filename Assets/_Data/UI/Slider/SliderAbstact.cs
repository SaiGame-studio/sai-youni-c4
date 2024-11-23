using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SliderAbstact : SaiBehaviour
{
    [SerializeField] protected Slider slider;

    protected override void Start()
    {
        this.slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);
    }

    protected abstract void OnSliderValueChanged(float value);
}
