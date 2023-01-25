using UnityEngine;
using UnityEngine.UI;

public class ManageItem : MonoBehaviour
{
    private bool isInRange;

    [SerializeField] private Item item;

    void Update()
    {
        if (isInRange) TakeItem();
    }

    void TakeItem()
    {
        Inventory.instance.content.Add(item);
        Inventory.instance.audioSource.Play();
        Inventory.instance.UpdateInventoryUI();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isInRange = false;
    }
}
