using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private string _mixerVariableName;

    private float _currentVolume;
    private float _muteSoundsValue = -80f;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(ChangeValue);
        _toggle.onValueChanged.AddListener(ToggleAllSounds);
    }

    public void ChangeValue(float volume)
    {
        int volumeMultiplier = 20;

        if (_toggle.enabled)
            _mixerGroup.audioMixer.SetFloat(_mixerVariableName, Mathf.Log10(volume) * volumeMultiplier);
    }

    public void ToggleAllSounds(bool enabled)
    {
        if (enabled)
        {
            _mixerGroup.audioMixer.SetFloat(_mixerVariableName, _currentVolume);
            _slider.interactable = true;
        }
        else
        {
            _mixerGroup.audioMixer.GetFloat(_mixerVariableName, out _currentVolume);
            _mixerGroup.audioMixer.SetFloat(_mixerVariableName, _muteSoundsValue);
            _slider.interactable = false;
        }
    }
}
