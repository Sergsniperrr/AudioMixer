using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private string _mixerVariableName;

    private float _currentVolume;
    private float _muteSoundsValue = -85f;

    public void ChangeValue(float volume)
    {
        int volumeMultiplier = 20;

        _mixerGroup.audioMixer.GetFloat(_mixerVariableName, out float currentVolume);

        if (currentVolume != _muteSoundsValue)
            _mixerGroup.audioMixer.SetFloat(_mixerVariableName, Mathf.Log10(volume) * volumeMultiplier);
    }

    public void ToggleAllSounds(bool enabled)
    {
        if (enabled)
        {
            _mixerGroup.audioMixer.SetFloat(_mixerVariableName, _currentVolume);
        }
        else
        {
            _mixerGroup.audioMixer.GetFloat(_mixerVariableName, out _currentVolume);
            _mixerGroup.audioMixer.SetFloat(_mixerVariableName, _muteSoundsValue);
        }
    }
}
