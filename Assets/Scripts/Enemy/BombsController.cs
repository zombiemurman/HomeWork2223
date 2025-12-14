using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombsController : MonoBehaviour
{
    [SerializeField] Character _character;

    [SerializeField] private List<Bomb> _bombs;

    [SerializeField] private ParticleSystem _explosionEffectPrefab;

    [SerializeField] private float _bombDamage;
    [SerializeField] private float _bombRadiusDetected;
    [SerializeField] private float _bombTimeToExplosion;

    [SerializeField] private MusicPlayer _musicPlayer;

    private void Awake()
    {
        foreach (Bomb bomb in _bombs)
            bomb.Initialize(this, _character, _bombDamage, _bombRadiusDetected, _bombTimeToExplosion);
    }

    public void ExplosionEffect(Vector3 position)
    {
        Instantiate(_explosionEffectPrefab, position, Quaternion.identity);
        _musicPlayer.BombSound();
    }
}
