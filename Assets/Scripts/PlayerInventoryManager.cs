using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("NPC"))
        {

        }
    }
}
