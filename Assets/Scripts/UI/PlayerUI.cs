using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;

    void Start(){
        instance = this;
        RefreshAllGUI();
    }


    [SerializeField] private Image hpFillBar;
    [SerializeField] private Text levelText;

    [SerializeField] private Image expFillBar;

    public void RefreshPlayerHealth(){
        if(hpFillBar == null) return;
        hpFillBar.fillAmount = (float)(Manager.instance.save.currHealth)/(float)(Manager.instance.save.maxHealth);
    }

    public void RefreshPlayerLevel(){
        if(levelText == null) return;
        levelText.text = Manager.instance.save.level.ToString();

        if(expFillBar == null) return;
        expFillBar.fillAmount = (float)(Manager.instance.save.exp)/(float)(Manager.instance.save.expToNext);
    }


    public void RefreshAllGUI(){
        RefreshPlayerHealth();
        RefreshPlayerLevel();
    }
}
