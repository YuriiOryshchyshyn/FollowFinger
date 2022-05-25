using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsAdd : MonoBehaviour
{
    [SerializeField] private GameObject content;

    [SerializeField] private Sprite[] skins;

    private List<Transform> panels;

    private void Start()
    {
        panels = GetChildrens(content);
        SetSkins(skins, panels);
    }

    private void SetSkins(Sprite[] skins, List<Transform> panels)
    {
        uint selectedSkinId = uint.MinValue;

        foreach (Transform panel in panels)
        {
            panel.gameObject.GetComponentInChildren<Image>().sprite = skins[selectedSkinId];
        }
    }

    private List<Transform> GetChildrens(GameObject content)
    {
        List<Transform> returnedList = new List<Transform>();

        for (int i = 0; i < content.transform.childCount; i++)
        {
            Transform panel = content.transform.GetChild(i);
            returnedList.Add(panel);
        }

        return returnedList;
    }
}
