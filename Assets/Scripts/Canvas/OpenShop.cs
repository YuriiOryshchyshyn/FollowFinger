using UnityEngine;

public class OpenShop : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _level;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _finger;
    [SerializeField] private GameObject _camera;

    [SerializeField] private Material _bgGame;
    [SerializeField] private Material _bgMenu;

    public void OpenShopMethod()
    {
        Messenger<bool>.Broadcast("MENUOFF", true);
        _score.SetActive(false);
        _level.SetActive(false);
        _finger.SetActive(false);
        _camera.GetComponent<Skybox>().material = _bgMenu;
        _shop.SetActive(true);
        _menu.SetActive(false);
    }

    public void CloseShopMethod()
    {
        Messenger<bool>.Broadcast("MENUOFF", false);
        _score.SetActive(true);
        _level.SetActive(true);
        _finger.SetActive(true);
        _camera.GetComponent<Skybox>().material = _bgGame;
        _shop.SetActive(false);
        _menu.SetActive(true);
    }
}
