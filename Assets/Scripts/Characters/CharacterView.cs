using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private readonly int IsRunningKey = Animator.StringToHash("isRunning");
    private readonly int DamageKey = Animator.StringToHash("TakeDamage");
    private readonly int DieKey = Animator.StringToHash("Die");

    private readonly string BaseLayer = "Base Layer";
    private readonly string InguredLayer = "InguredLayer";

    private int _indexBaseLayer;
    private int _indexInguredLayer;

    [SerializeField] private Animator _animator;

    [SerializeField] private Character _character;

    [SerializeField] private PointFlag _targetPointFlagPrefab;

    private void Awake()
    {
        _indexBaseLayer = _animator.GetLayerIndex(BaseLayer);
        _indexInguredLayer = _animator.GetLayerIndex(InguredLayer);
    }

    private void Update()
    {
        if (_character.CurrentVelocity.magnitude > 0.05f)
            StartRunning();
        else
            StopRunning();

        ShowDestinationMarker();
    }

    public void TakeDamage()
    {
        _character.StopMove();

        _animator.SetTrigger(DamageKey);

        if (_character.Health <= 90)
        {
            _animator.SetLayerWeight(_indexInguredLayer, 1);
            _animator.SetLayerWeight(_indexBaseLayer, 0);
        }

        if (_character.Health <= 0)
        {
            _animator.SetTrigger(DieKey);
        }
            
    } 

    private void ResumeMove()
    {
        _character.ResumeMove();
    }

    private void StartRunning()
    {
        _animator.SetBool(IsRunningKey, true);
    }

    private void StopRunning()
    {
        _animator.SetBool(IsRunningKey, false);
    }

    private void ShowDestinationMarker()
    {
        if(_character.CurrentVelocity.magnitude > 0.05f)
        {
            PointFlag targetPointFlag = Instantiate(_targetPointFlagPrefab, _character.CurrentTarget, Quaternion.identity);
            targetPointFlag.Initialize(_character.CurrentTarget);
        }
       
    }
}

