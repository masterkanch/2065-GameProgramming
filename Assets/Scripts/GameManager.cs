using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    // Simple singleton script. This is the easiest way to create and understand a singleton script.
    private int PlayerLife = 3;
    public GameObject[] hearts;
    [SerializeField] private LivesDisplay livesDisplay;
    
    private void Awake()
    {
        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {   
        if (PlayerLife == 1)
        {
            MainMenu();
        }
        else if(PlayerLife != 0){
            SceneManager.LoadScene(GetCurrentBuildIndex());
            PlayerLife--;
            Destroy(hearts[PlayerLife].gameObject);
            UpdateLives();
            DOTween.KillAll();
        }
    }

    private void UpdateLives(){
        livesDisplay.UpdateLives(PlayerLife);
    }

    

    public void LoadNextLevel()
    {
        var nextSceneIndex = GetCurrentBuildIndex() + 1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 1;
        }
        
        SceneManager.LoadScene(nextSceneIndex);
        DOTween.KillAll();
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    private int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
