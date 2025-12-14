using UnityEngine;

public class Medkit : MonoBehaviour
{
    private Character _character;

    private int _healAmount;

    private float _minActionDistance = 1f;

    private void Update()
    {
       if(Vector3.Distance(transform.position, _character.Position) <= _minActionDistance)
            Use();
    }

    public void Initialize(Character character, int healAmount)
    {
        _character = character;
        _healAmount = healAmount;
    }

    public void Use()
    {
        _character.AddHealth(_healAmount);
        Destroy(gameObject);
    }

 
}
