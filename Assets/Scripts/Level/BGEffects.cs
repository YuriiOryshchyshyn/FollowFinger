using UnityEngine;

public class BGEffects : MonoBehaviour
{
    [SerializeField] private Vector3 xRightEndPosition;
    [SerializeField] private Vector3 xLeftEndPosition;
    [SerializeField] private Vector3 yUpEndPosition;
    [SerializeField] private Vector3 yDownEndPosition;

    private void FixedUpdate()
    {
        Vector3 acceleration = Input.acceleration;

        if (acceleration.x > 0)
        {
            transform.position = Vector3.Lerp(transform.position, xRightEndPosition, Mathf.Abs(acceleration.x));
        }
        if (acceleration.x < 0)
        {
            transform.position = Vector3.Lerp(transform.position, xLeftEndPosition, Mathf.Abs(acceleration.x));
        }
        if (acceleration.y > 0)
        {
            transform.position = Vector3.Lerp(transform.position, yUpEndPosition, Mathf.Abs(acceleration.y));
        }
        if (acceleration.y < 0)
        {
            transform.position = Vector3.Lerp(transform.position, yDownEndPosition, Mathf.Abs(acceleration.y));
        }
    }
}
