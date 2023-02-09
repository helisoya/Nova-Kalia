using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuUITab : MonoBehaviour
{
    [SerializeField] protected GameObject rootTab;

    public abstract void OpenTab();

    public void CloseTab(){
        rootTab.SetActive(false);
    }
}
