using UnityEngine;

public class GameOverState : BaseState
{
    public GameOverState() : base() { }
    public override void Enter()
    {
        // GameManager.Instance.gameOver.SetActive(true);

        // if (GameManager.Instance.player.currentHealth <= 0)
        // {
        //     GameManager.Instance.winner.text = "You Lost!";
        // }
        // else
        // {
        //     GameManager.Instance.winner.text = "You Won!";
        // }
    }

    public override void Exit()
    {

    }

    public override void Update()
    {

    }
}
