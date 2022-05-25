using UnityEngine;
using UnityEngine.UI;

public class BuySkin : MonoBehaviour
{
    [SerializeField] private ShopPanels shopPanels;
    [SerializeField] private Text cointCount;
    
    public void Buy()
    {
        if (!shopPanels.CanSelectingSkin && PlayerPrefs.GetInt("CountMoney") >= 50)
        {
            PlayerPrefs.SetString(shopPanels.panelName, "Open");
            shopPanels.CanSelectingSkin = true;
            shopPanels.textButton.text = "Select";
            PlayerPrefs.SetInt("CountMoney", PlayerPrefs.GetInt("CountMoney") - 50);
            cointCount.text = PlayerPrefs.GetInt("CountMoney").ToString();
        }
    }
}
