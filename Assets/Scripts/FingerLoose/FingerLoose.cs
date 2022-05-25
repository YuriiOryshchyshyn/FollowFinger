using UnityEngine;
using UnityEngine.SceneManagement;

public class FingerLoose : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("Main");
    }
}
