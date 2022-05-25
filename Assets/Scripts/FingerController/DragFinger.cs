using UnityEngine;

public class DragFinger : MonoBehaviour
{
    private Vector3 pointScreen;
    [SerializeField] private AudioSource audio;

    public bool FingerInGame;

    private void OnMouseDown()
    {
        pointScreen = Camera.main.ScreenToWorldPoint(transform.position);
        FingerInGame = true;
        audio.Play();
    }

    private void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
        transform.position = new Vector3(currentPosition.x, currentPosition.y, transform.position.z);
    }

    private void OnMouseUp()
    {
        FingerInGame = false;
        audio.Pause();
    }
}
