using UnityEngine;

public class MenuItem : MonoBehaviour
{
    public MenuType type;
    public void OpenMenu() => gameObject.SetActive(true);
    public void CloseMenu() => gameObject.SetActive(false);
}