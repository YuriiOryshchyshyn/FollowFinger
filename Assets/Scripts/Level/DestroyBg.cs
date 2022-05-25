using UnityEngine;

public class DestroyBg : MonoBehaviour
{
    private void Update()
    {
        if (transform.localPosition.y < -15f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 45f, transform.localPosition.z);
        }
    }
}
