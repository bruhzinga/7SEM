using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Player[] players;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private AudioManager audioManager;

    private int score;
    public int Score => score;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            Application.targetFrameRate = 144;
            DontDestroyOnLoad(gameObject);
            audioManager = AudioManager.instance;
            Pause();
        }
    }

    public void Play()
    {
        audioManager.Play("GameStart");

        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;

        foreach (Player player in players)
        {
            player.gameObject.SetActive(true);
            player.enabled = true;
        }

        DestroyObstacles();
    }

    public void GameOver(Player player)
    {
        player.gameObject.SetActive(false); // Deactivate the current player

        // Check if there is another active player
        if (ArePlayersRemaining())
        {
            SetRemainingPlayersInvulnerable(); 
            Invoke("ActivateLastPlayer", 1f); // Activate the last player after 1 second
        }
        else
        {
            playButton.SetActive(true);
            gameOver.SetActive(true);
            audioManager.Play("GameOver");
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;

        foreach (Player player in players)
        {
            player.enabled = false;
        }
    }

    public void IncreaseScore()
    {
        audioManager.Play("Score");
        score++;
        scoreText.text = score.ToString();
    }

  

 private void ActivateLastPlayer()
{
    // Find the last active player and activate it
    foreach (Player player in players)
    {
        if (player.gameObject.activeSelf)
        {
            player.enabled = true; // Enable player input
            player.isInvulnerable = false; // Remove player invulnerability
            break;
        }
    }
}

    private void DestroyObstacles()
    {
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public bool ArePlayersRemaining()
    {
        int activePlayerCount = 0;

        foreach (Player player in players)
        {
            if (player.gameObject.activeSelf)
            {
                activePlayerCount++;
            }
        }

        return activePlayerCount > 0;
    }

    public void SetRemainingPlayersInvulnerable()
{
    foreach (Player player in players)
    {
        if (player.gameObject.activeSelf)
        {
            player.isInvulnerable = true;
        }
    }
}
}
