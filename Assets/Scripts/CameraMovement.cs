using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
    }
}
