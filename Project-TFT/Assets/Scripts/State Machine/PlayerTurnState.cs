using UnityEngine;

public class PlayerTurnState : BaseState
{
    public PlayerTurnState() : base() { }

    public override void Enter()
    {
        GameManager.Instance.endTurn.gameObject.SetActive(true);
        GameManager.Instance.canDrag = true;
        if (DeckManager.Instance.currentHeroesInHand < DeckManager.Instance.minimumHeroesInHand)
        {
            int amount = DeckManager.Instance.minimumHeroesInHand - DeckManager.Instance.currentHeroesInHand;
            for (int i = 0; i < amount; i++)
            {
                DeckManager.Instance.GenerateRandomHero();
            }
        }
    }

    public override void Exit()
    {
        GameManager.Instance.endTurn.gameObject.SetActive(false);
        GameManager.Instance.canDrag = false;
    }

    public override void Update()
    {
        // TODO end turn after time
    }
}
