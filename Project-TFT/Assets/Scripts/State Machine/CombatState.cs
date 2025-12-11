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
        if (GameManager.Instance.winner != "")
        {
            GameManager.Instance.ChangeState(new GameOverState());
        }
    }
}
