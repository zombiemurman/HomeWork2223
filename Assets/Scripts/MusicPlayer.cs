using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _bombSound;

    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private TMP_Text _musicButtonText;
    [SerializeField] private TMP_Text _soundsButtonText;

    private AudioHandler _audioHandler;

    private bool _isMusicOn;

    private bool _isSoundsOn;

    private void Awake()
    {
        _isMusicOn = true;
        _isSoundsOn = true;
        _audioHandler = new AudioHandler(_audioMixer);
    }

    private void Update()
    {
        UpdateTextButton();
    }

    public void BombSound()
    {
        _audioSource.PlayOneShot(_bombSound);
    }

    public void OffOnMusic()
    {
        _isMusicOn = !_isMusicOn;
        if (_isMusicOn)
            _audioHandler.OnMusic();
        else
            _audioHandler.OffMusic();
    }

    public void OffOnSounds()
    {
        _isSoundsOn = !_isSoundsOn;
        if (_isSoundsOn)
            _audioHandler.OnSounds();
        else
            _audioHandler.OffSounds();
    }

    private void UpdateTextButton()
    {
        if(_audioHandler.IsMusicOn())
            _musicButtonText.text = "Music On";
        else
            _musicButtonText.text = "Music Off";

        if(_audioHandler.IsSoundOn())
            _soundsButtonText.text = "Sounds On";
        else
            _soundsButtonText.text = "Sounds Off";
    }
}
