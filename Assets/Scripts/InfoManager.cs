using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class InfoManager : MonoBehaviour
{
    public static InfoManager instance;
    [SerializeField] private List<Info> infos = new List<Info>();

    [SerializeField] private Image itemIcon;
    [SerializeField] private Image arrowIcon;
    [SerializeField] private Image effectIcon;

    [SerializeField] private Animator animator;

    public Info currentInfo;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de InfoManager dans la scène");
            return;
        }
        instance = this;
    }

    public void StartInfo(Info info)
    {
        animator.SetBool("IsOpen", true);

        if (info != null)
        {
            currentInfo = infos.Find(e => e.id == info.id);
            if (currentInfo == null)
            {
                infos.Add(info);
            }
            currentInfo = infos.Find(e => e.id == info.id);
        }

        StartCoroutine(EndInfo());
    }

    private IEnumerator EndInfo()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("IsOpen", false);
    }
}
