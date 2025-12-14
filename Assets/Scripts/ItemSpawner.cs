using System.Collections;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Character _character;

    [SerializeField] private Medkit _ItemPrefab;

    [SerializeField] private float _timeSpawn;

    [SerializeField] private float _distanceSpawn;

    [SerializeField] private int _restoringHealh;

    private Coroutine _spawnProcess;

    private bool _spawnActive;

    private float _yOffset = 0.5f;

    private NavMeshPath _pathToTarget;

    private void Awake()
    {
        _spawnActive = true;
        _pathToTarget = new NavMeshPath();
    }

    private void Update()
    {
        StartProcess();
    }

    private void StartProcess()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _spawnActive = !_spawnActive;
        }

        if (_spawnActive == false && _spawnProcess != null)
        {
            StopCoroutine(_spawnProcess);
            _spawnProcess = null;
        }

        if (_spawnActive && _spawnProcess != null)
            return;

        _spawnProcess = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeSpawn);

            Vector3 distanceSpawn = new Vector3(
                _character.Position.x + _distanceSpawn, 
                _character.Position.y + _yOffset, 
                _character.Position.z + _distanceSpawn);

            if (_character.TryGetPath(distanceSpawn, _pathToTarget))
            {
                Medkit item = Instantiate(_ItemPrefab, distanceSpawn, Quaternion.identity);
                item.Initialize(_character, _restoringHealh);
            }

            yield return null;
        }
    }
}
