using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int k = 0;
    GameObject level2, level3, level4, level5, level6, level7, level8, level9, level10, level11, level12, level13, level14, level15, level16, level17, level18, 
        level19, level20;
    private GameObject removeProgress;
    private GameObject mainMenu;
    private void Start()
    {
        removeProgress = GameObject.Find("RemoveProgress");
        removeProgress.SetActive(false);
        mainMenu = GameObject.Find("MainMenu");
        level2 = GameObject.Find("Level 2");
        level3 = GameObject.Find("Level 3");
        level4 = GameObject.Find("Level 4");
        level5 = GameObject.Find("Level 5");
        level6 = GameObject.Find("Level 6");
        level7 = GameObject.Find("Level 7");
        level8 = GameObject.Find("Level 8");
        level9 = GameObject.Find("Level 9");
        level10 = GameObject.Find("Level 10");
        level11 = GameObject.Find("Level 11");
        level12 = GameObject.Find("Level 12");
        level13 = GameObject.Find("Level 13");
        level14= GameObject.Find("Level 14");
        level15 = GameObject.Find("Level 15");
        level16 = GameObject.Find("Level 16");
        level17 = GameObject.Find("Level 17");
        level18 = GameObject.Find("Level 18");
        level19 = GameObject.Find("Level 19");
        level20 = GameObject.Find("Level 20");
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);
        level6.SetActive(false);
        level7.SetActive(false);
        level8.SetActive(false);
        level9.SetActive(false);
        level10.SetActive(false);
        level11.SetActive(false);
        level12.SetActive(false);
        level13.SetActive(false);
        level14.SetActive(false);
        level15.SetActive(false);
        level16.SetActive(false);
        level17.SetActive(false);
        level18.SetActive(false);
        level19.SetActive(false);
        level20.SetActive(false);
        if (PlayerPrefsManager.LevelUnlocked(4))    { level2.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(5))    { level3.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(6))    { level4.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(7))    { level5.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(8))    { level6.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(9))    { level7.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(10))   { level8.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(11))   { level9.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(12))   { level10.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(13))   { level11.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(14))   { level12.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(15))   { level13.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(16))   { level14.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(17))   { level15.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(18))   { level16.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(19))   { level17.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(20))   { level18.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(21))   { level19.SetActive(true); }
        if (PlayerPrefsManager.LevelUnlocked(22))   { level20.SetActive(true); }

    }

    public void PrefDelete()
    {
            level2.SetActive(false);
            level3.SetActive(false);
            level4.SetActive(false);
            level5.SetActive(false);
            level6.SetActive(false);
            level7.SetActive(false);
            level8.SetActive(false);
            level9.SetActive(false);
            level10.SetActive(false);
            level11.SetActive(false);
            level12.SetActive(false);
            level13.SetActive(false);
            level14.SetActive(false);
            level15.SetActive(false);
            level16.SetActive(false);
            level17.SetActive(false);
            level18.SetActive(false);
            level19.SetActive(false);
            level20.SetActive(false);
            PlayerPrefsManager.UnlockLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void RemoveProgress()
    {
        removeProgress.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void MainMenu()
    {
        removeProgress.SetActive(false);
        mainMenu.SetActive(true);
    }
}
