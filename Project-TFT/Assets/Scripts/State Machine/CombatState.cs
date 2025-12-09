using System.Collections;
using UnityEngine;

public class CombatState : BaseState
{
    public CombatState() : base() { }

    public bool hasAttacked = false;

    public override void Enter()
    {
        GameManager.Instance.canAttack = true;
    }

    public override void Exit()
    {
        GameManager.Instance.canAttack = false;
    }

    public override void Update()
    {
        // GameManager.Instance.player.UpdateUI();
        // GameManager.Instance.enemy.UpdateUI();

        // if (hasAttacked)
        // {
        //     if (GameManager.Instance.player.currentHealth <= 0)
        //     {
        //         GameManager.Instance.ChangeState(new GameOverState());
        //     }
        //     else
        //     {
        //         GameManager.Instance.ChangeState(new PlayerTurnState());
        //     }
        // }
    }
}
