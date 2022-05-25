using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private GameObject rotationObject;

    [Range(0, 300)]
    [SerializeField] private float speedRotation;

    private void FixedUpdate()
    {
        rotationObject.transform.Rotate(Vector3.forward * speedRotation * Time.fixedDeltaTime);
    }
}
