using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ExchangeManager.instance.isStageDone) StartCoroutine(loadNextScene());
    }

    public IEnumerator loadNextScene()
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene(sceneName);
    }
}