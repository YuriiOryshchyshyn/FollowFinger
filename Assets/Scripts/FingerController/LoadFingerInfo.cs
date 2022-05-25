using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadFingerInfo : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameObject firstPanel;
    [SerializeField] private GameObject content;
    [SerializeField] private Sprite defaultSprite;

    private SpriteRenderer _skin;
    private List<GameObject> _panels;

    private void Start()
    {
        _panels = PaintPanels.GetChildrens(content);
        PlayerPrefs.SetString(firstPanel.name, "Open");
        _skin = GetComponent<SpriteRenderer>();
        _skin.sprite = defaultSprite;
        if (PlayerPrefs.GetString(_panels[PlayerPrefs.GetInt("Skin")].name) != "Open")
            return;
        LoadSkin("Skin", _skin, sprites);
    }

    public static List<PanelManager> GetChildrens(GameObject content)
    {
        List<PanelManager> childrensList = new List<PanelManager>();

        for (int i = 0; i < content.transform.childCount; i++)
        {
            childrensList.Add(content.transform.GetChild(i).gameObject.GetComponent<PanelManager>());
        }

        return childrensList;
    }

    private void LoadSkin(string key, SpriteRenderer skin, Sprite[] _sprites)
    {
        skin.sprite = _sprites.ElementAt(PlayerPrefs.GetInt(key));
    }
}
