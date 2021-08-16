using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    
    [SerializeField]
    private Menu[] _menuItems;

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

    public void OpenMenu(Menu menu)
    {
        CloseAllMenu();
        menu.OpenMenu();
    }

    private void CloseAllMenu()
    {
        foreach (var menuItem in _menuItems)
            menuItem.CloseMenu();
    }
}
