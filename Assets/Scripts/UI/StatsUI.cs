using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MenuUITab
{
    [SerializeField] private Text txtPlayerName;
    [SerializeField] private Image expFillCurve;
    [SerializeField] private Text txtLevel;
    [SerializeField] private Text txtExpToNext;
 
    public override void OpenTab(){
        rootTab.SetActive(true);
        txtPlayerName.text = "Nom : "+Manager.instance.save.playerName;
        expFillCurve.fillAmount =  (float)(Manager.instance.save.exp)/(float)(Manager.instance.save.expToNext);
        txtLevel.text = Manager.instance.save.level.ToString();
        txtExpToNext.text = (Manager.instance.save.expToNext - Manager.instance.save.exp).ToString();
    }
}
