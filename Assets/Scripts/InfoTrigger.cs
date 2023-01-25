using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoTrigger : MonoBehaviour
{
    public Info info;

    private bool isInRange;

    void Update()
    {
        if(isInRange) InfoManager.instance.StartInfo(info);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            isInRange = true;
            //Destroy(gameObject, 15);
        }
    }
}