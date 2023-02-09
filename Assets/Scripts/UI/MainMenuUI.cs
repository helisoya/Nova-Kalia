using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private MenuUITab loadScreen;
    [SerializeField] private GameObject newGameScreen;

    [SerializeField] private GameObject introScreen;
    [SerializeField] private InputField tfPlayerName;

    public void QuitGame(){
        Application.Quit();
    }

    public void GoToLoadScreen(){
        mainScreen.SetActive(false);
        loadScreen.OpenTab();
    }

    public void GotoMainScreen(){
        loadScreen.CloseTab();
        mainScreen.SetActive(true);
    }

    public void GoToNewGameScreen(){
        mainScreen.SetActive(false);
        newGameScreen.SetActive(true);
    }

    public void GoToIntroduction(){
        newGameScreen.SetActive(false);
        introScreen.SetActive(true);
    }


    public void ConfirmName(){
        Manager.instance.ResetSave();
        Manager.instance.GetSave().playerName = tfPlayerName.text;
        SceneManager.LoadScene("WorldMap");
    }
}
