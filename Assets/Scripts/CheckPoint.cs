using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CurrentSceneManager.instance.respawnPoint = transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine("SwitchImage", 1.5f);
            AudioSource audioSource =  GetComponent<AudioSource>();
            if (audioSource != null) audioSource.Play();
        }
    }

    private IEnumerator SwitchImage(float duration)
    {
        Material checkPointImage = GetComponent<SpriteRenderer>().material;
        float time = 0.0f;
        while (time <= duration)
        {
            checkPointImage.SetFloat("_SwitchValue", time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
