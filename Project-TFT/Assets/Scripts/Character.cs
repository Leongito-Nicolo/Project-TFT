using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private Slider _healthSlider;

    private float currentHealth;
    private bool isAlive = true;

    public bool ShouldAttackNext { get; private set; }

    void Start()
    {
        currentHealth = _maxHealth;
        _healthSlider.maxValue = _maxHealth;
        _healthSlider.value = _maxHealth;
        ShouldAttackNext = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        _healthSlider.value = currentHealth;



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
