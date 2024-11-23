using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeMusic  : SliderAbstact
{
    protected override void OnSliderValueChanged(float value)
    {
        SoundManager.Instance.VolumeMusicUpdating(value);
    }
}
