using UnityEngine;
using UnityEngine.UI;

public class UiMonetPresentation : MonoBehaviour
{
    private int _monetCount;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            _monetCount = PlayerPrefs.GetInt("Money");
            GetComponent<Text>().text = _monetCount.ToString();
        }
    }

    public void CollectMonet()
    {
        _monetCount++;
        GetComponent<Text>().text = _monetCount.ToString();
        PlayerPrefs.SetInt("Money", _monetCount);
    }
}
