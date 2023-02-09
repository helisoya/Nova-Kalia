using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject rootMenu;
    [SerializeField] private MenuUITab[] menuTabs;
    private int currentTab = 0;

    public static MenuUI instance;
    
    void Start(){
        instance = this;
    }

    private bool menuOpened;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            if (menuOpened) CloseMenu();
            else OpenMenu();
            menuOpened = !menuOpened;
        }
    }

    public void ChangeTab(int newTab){
        menuTabs[currentTab].CloseTab();
        currentTab = newTab;
        menuTabs[currentTab].OpenTab();
    }


    public void OpenMenu(){
        rootMenu.SetActive(true);
        menuTabs[currentTab].OpenTab();
        Time.timeScale = 0;
    }


    public void CloseMenu(){
        rootMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoToMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
