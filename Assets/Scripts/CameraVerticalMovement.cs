using UnityEngine;

public class CameraVerticalMovement : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private void Update()
    {
        transform.position = new Vector3(0, target.transform.position.y, -10);
    }
}
