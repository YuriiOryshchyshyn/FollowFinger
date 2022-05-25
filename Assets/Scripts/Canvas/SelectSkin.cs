using UnityEngine;
using UnityEngine.UI;

public class SelectSkin : MonoBehaviour
{
    [SerializeField] private Image skin;
    [SerializeField] private SpriteRenderer finger;
    [SerializeField] private ShopPanels shopPanels;

    public void SetSkin()
    {
        if (shopPanels.CanSelectingSkin)
        {
            finger.sprite = skin.sprite;
        }
    }
}
