using System.Linq;
using UnityEngine;

public class AttackNearestEnemy : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private float _speed;

    private GameObject target;
    private DragObject drag;
    private Character character;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drag = GetComponent<DragObject>();
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.Instance.canAttack) return;
        if (drag != null && !drag.isDeployed) return;

        target = FindClosestTarget(_tag);

        if (!target)
        {
            GameManager.Instance.winner = transform.tag;
            return;
        }


        if (Vector3.Distance(transform.position, target.transform.position) < 2f)
        {
            Debug.Log(character.ShouldAttackNext);
            if (character.ShouldAttackNext)
            {
                if (target.TryGetComponent(out Character enemy))
                {
                    StartCoroutine(character.Attack(enemy));
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * _speed);
        }
    }

    private GameObject FindClosestTarget(string trgt)
    {
        GameObject closestGameObject = GameObject.FindGameObjectsWithTag(trgt)
                          .OrderBy(go => Vector3.Distance(go.transform.position, transform.position))
                          .FirstOrDefault();

        if (closestGameObject && closestGameObject.TryGetComponent(out DragObject playerDrag))
        {
            if (!playerDrag.isDeployed)
            {
                closestGameObject = null;
            }
        }

        return closestGameObject;
    }
}
