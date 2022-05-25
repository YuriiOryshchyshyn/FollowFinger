using System.Collections.Generic;
using UnityEngine;

public class PaintPanels : MonoBehaviour
{
    [SerializeField] private GameObject content;

    [SerializeField] private Sprite[] sprites;

    private List<GameObject> panels;

    private void Start()
    {
        panels = GetChildrens(content);

        SetSpritesInPanels(panels, sprites);
    }

    private void SetSpritesInPanels(List<GameObject> panels, Sprite[] sprites)
    {
        uint tempSprite = uint.MinValue;

        foreach (GameObject panel in panels)
        {
            panel.GetComponent<PanelManager>().SetSprite(sprites[tempSprite]);
            tempSprite++;
        }
    }

    public static List<GameObject> GetChildrens(GameObject content)
    {
        List<GameObject> childrensList = new List<GameObject>();

        for (int i = 0; i < content.transform.childCount; i++)
        {
            childrensList.Add(content.transform.GetChild(i).gameObject);
        }

        return childrensList;
    }
}
