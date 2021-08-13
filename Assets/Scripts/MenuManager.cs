using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    
    [SerializeField]
    private MenuItem[] _menuItems;

    private void Awake() => Instance = this;

    public void OpenMenu(MenuType type)
    {
        foreach (var menuItem in _menuItems)
        {
            if (menuItem.type == type)
            {
                OpenMenu(menuItem);
            }
        }
    }

    public void OpenMenu(MenuItem menuItem)
    {
        CloseAllMenu();
        menuItem.OpenMenu();
    }

    private void CloseAllMenu()
    {
        foreach (var menuItem in _menuItems)
            menuItem.CloseMenu();
    }
}
