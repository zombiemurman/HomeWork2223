using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private BombsController _bombController;

    private IDamageable _target;

    private float _radiusDetected;

    private float _timeToExplosion;

    private float _damage;

    private Coroutine _bombTimerProcess;

    public void Initialize(BombsController bombController, IDamageable target, float damage, float radiusDetected, float timeToExplosion)
    {
        _bombController = bombController;
        _target = target;
        _damage = damage;
        _radiusDetected = radiusDetected;
        _timeToExplosion = timeToExplosion;
    }

    public void Update()
    {
        if (CheckDetection() && _bombTimerProcess == null)
            _bombTimerProcess = StartCoroutine(Explosion());

        if(CheckDetection() == false && _bombTimerProcess != null)
        {
            StopCoroutine(_bombTimerProcess);
            _bombTimerProcess = null;
        }
            
    }

    private IEnumerator Explosion()
    {
        float currentTimeToExplosion = 0;

        while (currentTimeToExplosion <= _timeToExplosion)
        {
            currentTimeToExplosion += Time.deltaTime;
            yield return null;
        }

        _bombController.ExplosionEffect(transform.position);
        _target.TakeDamage(_damage);
        Destroy(gameObject);
    
        yield return null;
    }

    private bool CheckDetection()
    {
        if (_target == null)
            return false;

        if(Vector3.Distance(_target.Position, transform.position) <= _radiusDetected)
            return true;

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, _radiusDetected);
    }
}
