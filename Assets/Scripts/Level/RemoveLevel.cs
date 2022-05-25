using UnityEngine;

public class RemoveLevel : MonoBehaviour
{
    [SerializeField] private LevelGenerate levelGenerate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Level"))
        {
            if (levelGenerate.RoadInScene > 1)
            {
                Destroy(collision.gameObject);
                levelGenerate.RoadInScene--;
            }
        }
    }
}
