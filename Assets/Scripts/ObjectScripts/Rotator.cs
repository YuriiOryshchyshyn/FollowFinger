using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float speedRotation;

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, speedRotation));
    }
}
