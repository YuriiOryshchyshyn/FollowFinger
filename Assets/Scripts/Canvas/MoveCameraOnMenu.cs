using UnityEngine;

public class MoveCameraOnMenu : MonoBehaviour
{
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
    }
}
