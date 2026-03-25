using UnityEngine;

public class Movement : MonoBehaviour
{
    public Room currentRoom;
    public Background_Manager background_Manager;
    public Sprite current_sprite;
    public Event_Manager events;
    void Start()
    {
        
    }

    public void GoUp()
    {
        if (currentRoom.up != null)
        {
            currentRoom = currentRoom.up.GetComponent<Room>();
            UpdateRoom();
        }
    }

    public void GoDown()
    {
        if (currentRoom.down != null)
        {
            currentRoom = currentRoom.down.GetComponent<Room>();
            UpdateRoom();
        }
    }

    public void GoLeft()
    {
        if (currentRoom.left != null)
        {
            currentRoom = currentRoom.left.GetComponent<Room>();
            UpdateRoom();
        }
    }

    public void GoRight()
    {
        if (currentRoom.right != null)
        {
            currentRoom = currentRoom.right.GetComponent<Room>();
            UpdateRoom();
        }
    }

    public void UpdateRoom()
    {
        current_sprite = currentRoom.background;
        background_Manager.Change_Background(current_sprite);
        if (currentRoom.collectable != null && currentRoom.collected == false)
        {
            currentRoom.collectable.SetActive(true);
            currentRoom.collected = true;
        }
        if (currentRoom.collectable != null && events.score == 4)
        {
            currentRoom.collectable.SetActive(true);
        }
    }

}
