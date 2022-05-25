using UnityEngine;

public class CollectMoney : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finger"))
        {
            GameObject.Find("CountMoney").GetComponent<UiMonetPresentation>().CollectMonet();
            Destroy(gameObject);
        }
    }
}
