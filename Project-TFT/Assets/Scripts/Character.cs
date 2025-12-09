using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackCooldown;

    private float currentHealth;
    private bool isAlive = true;

    public bool ShouldAttackNext { get; private set; }

    void Start()
    {
        currentHealth = _maxHealth;
        ShouldAttackNext = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            isAlive = false;
            Destroy(gameObject);
        }
    }

    public IEnumerator Attack(Character enemyTarget)
    {
        ShouldAttackNext = false;
        while (isAlive)
        {
            if (enemyTarget == null)
            {
                ShouldAttackNext = true;
                yield break;
            }

            Debug.Log(enemyTarget.name);
            enemyTarget.TakeDamage(_damage);


            yield return new WaitForSeconds(_attackCooldown);
        }


    }
}
