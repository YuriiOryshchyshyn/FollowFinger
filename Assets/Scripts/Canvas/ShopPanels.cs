using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanels : BaseSelectSkin
{
    public int indexPanel;
    public string panelState;
    public string panelName;

    [SerializeField] private GameObject content;
    [SerializeField] public Text textButton;

    private List<GameObject> panels;

    public bool CanSelectingSkin;

    private void Start()
    {
        panels = PaintPanels.GetChildrens(content);
    }

    public override void SelectSkin(int skinIndex)
    {
        indexPanel = skinIndex;
        panelName = panels.ElementAt(indexPanel).gameObject.name;

        if (PlayerPrefs.HasKey(panelName))
        {
            panelState = PlayerPrefs.GetString(panelName);
            if (panelState == "Open")
            {
                textButton.text = "Select";
                CanSelectingSkin = true;
            }
            else
            {
                textButton.text = "Buy";
                CanSelectingSkin = false;
            }
        }
        else
        {
            panelState = "Close";
            textButton.text = "Buy";
            CanSelectingSkin = false;
        }
    }
}
