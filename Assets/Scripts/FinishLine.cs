using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private const string PlayerTag = "Player";
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoAudioClips playerWinning;
    [SerializeField] private ParticleSystem Winning;

    private GameManager _gameManager;
    
    // Why are we checking if the player reaches the finish line here? So, we do not
    // have to check for every time the player collides with something for a finish line.
    
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(PlayerTag)) return;
        audioSource.Play();
        Winning.Play();
        Invoke("LoadNextLevel", audioSource.clip.length);
    }

    private void LoadNextLevel(){
        _gameManager.LoadNextLevel();
    }
}
