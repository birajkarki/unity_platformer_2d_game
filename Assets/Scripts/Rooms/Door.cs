using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;
    [SerializeField] private int finalRoomIndex = 5; // Adjust this according to your final room

    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom);
                nextRoom.GetComponent<Room>().ActivateRoom(true);
                previousRoom.GetComponent<Room>().ActivateRoom(false);
            }
            else
            {
                cam.MoveToNewRoom(previousRoom);
                previousRoom.GetComponent<Room>().ActivateRoom(true);
                nextRoom.GetComponent<Room>().ActivateRoom(false);
            }

            // Check if the next room is the final room
            if (nextRoom.name == "Room " + finalRoomIndex)
            {
                FinishGame();
            }
        }
    }

    private void FinishGame()
    {
        // You can perform any actions needed to finish the game here
        // For example, loading a game completion scene, displaying credits, etc.
        Debug.Log("Game Finished!"); // Just a placeholder example
        SceneManager.LoadScene("GameCompletionScene"); // Load your game completion scene
    }
}
