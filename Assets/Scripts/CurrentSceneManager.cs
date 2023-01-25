using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    [HideInInspector]
    public Vector3 respawnPoint;

    public static CurrentSceneManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of CurrentSceneManager in the scene.");
            return;
        }
        instance = this;
        respawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
    }
}
