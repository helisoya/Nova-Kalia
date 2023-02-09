using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveUI : MenuUITab
{
    [SerializeField] private Transform saveFileRoot;
    [SerializeField] private GameObject saveFilePrefab;
    [SerializeField] private int maxSaveFiles;


    public override void OpenTab(){
        rootTab.SetActive(true);
        Time.timeScale = 0;


        for (int i = saveFileRoot.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(saveFileRoot.GetChild(i).gameObject);
        }


        for(int i = 1;i<=maxSaveFiles;i++){
            UI_SaveFile saveFile = Instantiate(saveFilePrefab,saveFileRoot).GetComponent<UI_SaveFile>();
            saveFile.saveIndex = i;
            saveFile.ui = this;

            if(SceneManager.GetActiveScene().name == "MainMenu"){
                saveFile.saveButton.gameObject.SetActive(false);
                saveFile.loadButton.transform.position = saveFile.saveButton.transform.position;
            }

            if(!System.IO.File.Exists(FileManager.savPath + "Saves/save"+i.ToString()+".sav")){
                saveFile.loadButton.gameObject.SetActive(false);
                saveFile.saveFileEmpty.SetActive(true);
                saveFile.saveFileText.gameObject.SetActive(false);
                saveFile.deleteButton.gameObject.SetActive(false);
            }else{
                Save file = FileManager.LoadJSON<Save>(FileManager.savPath + "Saves/save"+i.ToString()+".sav");
                saveFile.saveFileText.text = file.playerName+" Lv"+ file.level.ToString();
            }
        }
    }

    public void Save(UI_SaveFile file){
        Manager.instance.SaveGame(GameObject.Find("Player").transform.position, file.saveIndex);
        file.loadButton.gameObject.SetActive(true);
        file.deleteButton.gameObject.SetActive(true);
        file.saveFileEmpty.SetActive(false);
        file.saveFileText.gameObject.SetActive(true);
        file.saveFileText.text = Manager.instance.GetSave().playerName+" Lv"+ Manager.instance.GetSave().level.ToString();
    }

    public void Load(UI_SaveFile file){
        Time.timeScale = 1;
        Manager.instance.LoadGame(file.saveIndex);
    }


    public void Delete(UI_SaveFile file){
        System.IO.File.Delete(FileManager.savPath + "Saves/save"+file.saveIndex.ToString()+".sav");
        file.loadButton.gameObject.SetActive(false);
        file.deleteButton.gameObject.SetActive(false);
        file.saveFileText.gameObject.SetActive(false);
        file.saveFileEmpty.SetActive(true);
    }
}
