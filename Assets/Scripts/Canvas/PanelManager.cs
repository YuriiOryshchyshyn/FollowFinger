using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject _image;
    [SerializeField] private Text _text;

    public void SetSprite(Sprite sprite)
    {
        _image.GetComponent<Image>().sprite = sprite;
    }

    public void SetText(string text)
    {
        _text.GetComponent<TextMesh>().text = text;
    }

    public Sprite GetSprite()
    {
        return _image.GetComponent<Image>().sprite;
    }
}
