public class GameOverState : BaseState
{
    public GameOverState() : base() { }
    public override void Enter()
    {
        GameManager.Instance.gameOver.SetActive(true);

        GameManager.Instance.winText.text = $"{GameManager.Instance.winner} won!";
    }

    public override void Exit()
    {

    }

    public override void Update()
    {

    }
}
