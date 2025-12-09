using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    private BaseState _currentState;

    public bool canDrag;
    public bool canAttack;
    // public Player player;
    // public Enemy enemy;

    public Button endTurn;
    // public GameObject gameOver;
    // public TMP_Text winner;

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

        _currentState = new PlayerTurnState();
    }

    void Start()
    {
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState.Update();
    }

    public void FixedUpdate()
    {
        //_currentState.FixedUpdate();
    }


    public void ChangeState(BaseState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void StartCombat()
    {
        ChangeState(new CombatState());
    }

    public void Play()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
