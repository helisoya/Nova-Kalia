using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SaveFile : MonoBehaviour
{
    public Text saveFileText;
    public GameObject saveFileEmpty;
    public Image bg;
    public Button saveButton;
    public Button loadButton;
    public Button deleteButton;

    public int saveIndex;

    public SaveUI ui;


    public void Load(){
        ui.Load(this);
    }


    public void Save(){
        ui.Save(this);
    }

    public void Delete(){
        ui.Delete(this);
    }
}
