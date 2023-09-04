using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuSystem : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject challengeMenu;
    [SerializeField] GameObject gamePlayMenu;
    [SerializeField] GameObject powerUpsMenu;
    [SerializeField] GameObject knifesMenu;
    [SerializeField] GameObject gameOverMenu;
    List<GameObject> menus;
    public void LoadURL()
    {
        Application.OpenURL(Constants.DEVELOPER_URL);
    }
    private void Start()
    {
        menus = new List<GameObject> {mainMenu,challengeMenu,gamePlayMenu};
    }
    public void SetMenu(string name)
    {
        foreach(var menu in menus)
        {
            if (menu.name == name) menu.Show();
            else menu.Hide();
        }
    }
    public void HideGameOverMenu()
    {
        gameOverMenu.Hide();
    }

    public void ShowSettingsMenu()
    {
        settingsMenu.Show();
    }
    public void HideSettingMenu()
    {
        settingsMenu.Hide();
    }
    public void ShowPowerUpsMenu()
    {
        powerUpsMenu.Show();
    }
    public void HidePowerUpsMenu()
    {
        powerUpsMenu.Hide();
    }
    public void ShowKnifessMenu()
    {
        knifesMenu.Show();
    }
    public void HideKnifesMenu()
    {
        knifesMenu.Hide();
    }


}
