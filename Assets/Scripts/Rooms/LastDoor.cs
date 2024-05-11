using UnityEngine;
using UnityEngine.SceneManagement;

public class LastDoor : MonoBehaviour
{
    [SerializeField] private string gameCompletionSceneName = "GameCompletionScene";    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FinishGame();
        }
    }

    private void FinishGame()
    {
        
        Debug.Log("Game Finished!");
        SceneManager.LoadScene(gameCompletionSceneName); 
    }
}
