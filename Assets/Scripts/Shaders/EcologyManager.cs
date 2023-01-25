using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcologyManager : MonoBehaviour
{
    [SerializeField] float switchDuration = 5.0f;

    [SerializeField] SpriteRenderer[] spriteRenderers;

    public static EcologyManager s_Instance;

    private bool isRestaured = false;

    private void Start()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [ContextMenu("SwitchWorld")]
    public void SwitchWorld()
    {
        if(!isRestaured) StartCoroutine("SwitchWorldAnimation", switchDuration);
    }

    private IEnumerator SwitchWorldAnimation(float duration)
    {
        float time = 0.0f;
        while (time <= duration)
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                if (spriteRenderer.material != null)
                    spriteRenderer.material.SetFloat("_SwitchValue", time / duration);
            }
            time += Time.deltaTime;
            yield return null;
        }
        isRestaured = true;
    }
}