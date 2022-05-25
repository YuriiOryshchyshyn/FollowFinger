using UnityEngine;

public class MovementArea : MonoBehaviour
{
    [SerializeField] Vector3 offsetPosition;

    [SerializeField] private DragFinger fingerController;
    [SerializeField] private float smoothFactor;
    
    private Vector3 positionSmooth, endPosition;

    private float _speed = 0.05f;

    private void FixedUpdate()
    {
        endPosition = new Vector3(transform.position.x, transform.position.y + offsetPosition.y, transform.position.z);
        positionSmooth = Vector3.Lerp(transform.position, endPosition, smoothFactor * Time.fixedDeltaTime);

        if (fingerController.FingerInGame)
        {
            transform.position = Vector2.MoveTowards(transform.position, positionSmooth, _speed);
            _speed += 0.00000001f;
                //positionSmooth;
        }
    }
}
