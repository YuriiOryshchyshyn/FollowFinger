using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OnSkinSelectedPanel : ChangeSkinBase
{
    [SerializeField] private GameObject finger;
    [SerializeField] private GameObject content;

    public override void ChangeSkin(int index)
    {
        List<GameObject> panels = PaintPanels.GetChildrens(content);
        finger.GetComponent<Image>().sprite = panels.ElementAt(index).GetComponent<PanelManager>().GetSprite();
        if (PlayerPrefs.GetString(panels.ElementAt(index).name) == "Onen")
        {
            SaveSkin("Skin", index);
        }
    }

    private void SaveSkin(string key, int indexSkin)
    {
        PlayerPrefs.SetInt(key, indexSkin);
    }
}
