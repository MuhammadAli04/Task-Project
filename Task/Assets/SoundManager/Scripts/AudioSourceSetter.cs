using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceSetter : MonoBehaviour
{
    public AudioSourceType sourceType;
    private float[] _currentVolume;
    private AudioSource[] _audioSrc ;
    private float[] _initialVolume; // Initial Volume Set In Editor
    
    //Constants
    private const float MAXVol = 1f;
    private const float Percent = 100;
    private const float Tolerance = 0.000001f;

    private void Start()
    {
        _audioSrc = GetComponents<AudioSource>();
        if (_audioSrc.Length == 0) return;
        _initialVolume = new float[_audioSrc.Length];
        _currentVolume = new float[_audioSrc.Length];
        
        for(var i = 0; i < _audioSrc.Length; i++)
        {
            _initialVolume[i] = _audioSrc[i].volume;
            _currentVolume[i] = _initialVolume[i];
        }
        
    }


    // Update is called once per frame
    private void Update()
    {
        if (_audioSrc.Length == 0) return;

        Debug.Log(Prefs.SoundVolume);
        var volVal = Prefs.SoundVolume;
        
        var perVal = Percent - volVal / MAXVol * Percent;

        for (var i = 0; i < _audioSrc.Length; i++)
        {
            _currentVolume[i] = _initialVolume[i] - perVal/Percent * _initialVolume[i];

            if (Math.Abs(_audioSrc[i].volume - _currentVolume[i]) > Tolerance)
            {
                _audioSrc[i].volume = _currentVolume[i];
            }
        }
        
        
    }
    
    public enum AudioSourceType
    {
        SoundSource
    }
    
}
 