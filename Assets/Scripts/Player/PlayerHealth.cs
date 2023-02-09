using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public void TakeDamage(int dmg){
        bool dead = Manager.instance.TakeDamage(dmg);
        PlayerUI.instance.RefreshPlayerHealth();

        if(dead){
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }

    }
}
