using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeSfx : SliderAbstact
{
    protected override void OnSliderValueChanged(float value)
    {
        SoundManager.Instance.VolumeSfxUpdating(value);
    }
}
