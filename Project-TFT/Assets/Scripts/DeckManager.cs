using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance { get; private set; }

    [SerializeField] private List<GameObject> deckList = new List<GameObject>();

    [SerializeField] private List<Transform> playerHand;

    public int minimumHeroesInHand;

    public int currentHeroesInHand = 0;

    public int maxMana;

    public int currentMana;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SpawnNewHero(GameObject hero)
    {
        Instantiate(hero, playerHand[currentHeroesInHand]);
    }

    public void GenerateRandomHero()
    {
        SpawnNewHero(deckList[Random.Range(0, deckList.Count)]);
        currentHeroesInHand++;
    }


}