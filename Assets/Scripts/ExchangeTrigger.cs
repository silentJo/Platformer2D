using UnityEngine;
using UnityEngine.UI;

public class ExchangeTrigger : MonoBehaviour
{
    public Exchange exchange;

    private bool isInRange;

    void Update()
    {
        if(isInRange) ExchangeManager.instance.StartDialogue(exchange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isInRange = true; 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            ExchangeManager.instance.EndDialogue();
        }
    }
}