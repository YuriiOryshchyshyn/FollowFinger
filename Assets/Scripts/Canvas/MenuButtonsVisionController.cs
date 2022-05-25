using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonsVisionController : MonoBehaviour
{
    [SerializeField] private DragFinger fingerController;
    [SerializeField] private GameObject _menuButtons;

    private List<GameObject> buttons;

    private bool inProcessHiding;
    private bool inProcessShowing;
    private bool _menuState;

    private void Start()
    {
        buttons = GetChildrensFromGameObject(_menuButtons);

        Messenger<bool>.AddListener("MENUOFF", OnSwitch);
    }

    private void OnSwitch(bool menuState)
    {
        _menuState = menuState;
    }

    private void Update()
    {
        if (fingerController.FingerInGame 
            && _menuButtons.activeSelf == true 
            && !inProcessHiding)
        {
            HideMenuButtons();
            inProcessHiding = true;
        }
        if (!fingerController.FingerInGame 
            && _menuButtons.activeSelf == false 
            && !inProcessShowing 
            && !_menuState)
        {
            ShowMenuButtons();
            inProcessShowing = true;
        }
    }

    public void HideMenuButtons()
    {
        foreach (GameObject children in buttons)
        {
            Image spriteRendererChildren = children.GetComponent<Image>();
            StartCoroutine(HideSprite(spriteRendererChildren));
        }

        _menuButtons.SetActive(false);
    }
    
    public void ShowMenuButtons()
    {
        _menuButtons.SetActive(true);

        foreach (GameObject children in buttons)
        {
            Image spriteRendererChildren = children.GetComponent<Image>();
            StartCoroutine(ShowSprite(spriteRendererChildren));
        }
    }

    private IEnumerator HideSprite(Image spriteRendererChildren)
    {
        for (float i = 1; i >= -0.05f; i -= 0.5f)
        {
            Color color = spriteRendererChildren.color;
            color.a = i;
            spriteRendererChildren.color = color;
            yield return new WaitForSeconds(0.05f);
        }

        inProcessHiding = false;
    }
    
    private IEnumerator ShowSprite(Image spriteRendererChildren)
    {
        for (float i = 0; i <= 1.1f; i += 0.5f)
        {
            Color color = spriteRendererChildren.color;
            color.a = i;
            spriteRendererChildren.color = color;
            yield return new WaitForSeconds(0.05f);
        }

        inProcessShowing = false;
    }

    private List<GameObject> GetChildrensFromGameObject(GameObject menuButtons)
    {
        List<GameObject> childrens = new List<GameObject>();

        for (int i = 0; i < menuButtons.transform.childCount; i++)
        {
            childrens.Add(menuButtons.transform.GetChild(i).gameObject);
        }

        return childrens;
    }
}
