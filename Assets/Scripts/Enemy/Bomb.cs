using UnityEngine;

public class Bomb : MonoBehaviour
{
    private BombsController _bombController;

    private IDamageable _target;

    private float _radiusDetected;

    private float _timeToExplosion;

    private float _currentTimeToExplosion;

    private float _damage;

    public void Initialize(BombsController bombController, IDamageable target, float damage, float radiusDetected, float timeToExplosion)
    {
        _bombController = bombController;
        _target = target;
        _damage = damage;
        _radiusDetected = radiusDetected;
        _timeToExplosion = timeToExplosion;

        _currentTimeToExplosion = _timeToExplosion;
    }

    public void Update()
    {
        if (CheckDetection())
            Explosion();

    }

    private void Explosion()
    {
        _currentTimeToExplosion -= Time.deltaTime;

        if (_currentTimeToExplosion <= 0)
        {
            _bombController.ExplosionEffect(transform.position);
            _target.TakeDamage(_damage);
            Destroy(gameObject);
        }      
    }

    private bool CheckDetection()
    {
        if (_target == null)
            return false;

        if(Vector3.Distance(_target.Position, transform.position) <= _radiusDetected)
            return true;

        _currentTimeToExplosion = _timeToExplosion;
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, _radiusDetected);
    }
}
