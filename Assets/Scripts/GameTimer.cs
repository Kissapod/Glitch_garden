using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float levelSeconds = 10f;
    public static bool bossInLevel = false;
    public static bool isEndWinCondition = false;

    private Slider slider;
    private AudioSource audioSource;
    private LevelManager levelManager;
    private GameObject winLabel;
    private Animator animator;
    private bool bossBurn = false;
    private GameObject starNull;
    // Start is called before the first frame update
    private void Awake()
    {
        starNull = GameObject.Find("Star Null");
        isEndWinCondition = false;
    }
    void Start()
    {
        if (FindObjectOfType<BossSpawner>())
            bossInLevel = true;
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        FindWin();
        winLabel.SetActive(false);
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", false);
    }

    private void FindWin()
    {
        winLabel = GameObject.Find("Win");
        if (!winLabel)
        {
            Debug.LogWarning("Пожалуйста создайте объект Win");
        }
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;
        bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
        if (timeIsUp && !isEndWinCondition)
        {
            if (FindObjectOfType<BossSpawner>() && !bossBurn)
            {
                FindObjectOfType<BossSpawner>().BossBorn();
                bossBurn = true;
            }
            else if (!bossBurn)
                WinCondition();
        }
        if (FindObjectOfType<BossSpawner>() && bossBurn)
        {
            if (FindObjectOfType<BossSpawner>().transform.childCount <= 0)
                WinCondition();
        }
    }

    private void WinCondition()
    {
        Destroy(starNull);
        DestroyAllTaggedObjects();
        FindObjectOfType<MusicManager>().GetComponent<AudioSource>().Stop();
        if (!audioSource.isPlaying) { 
            audioSource.Play();
        }
        animator.SetBool("Idle", true);
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndWinCondition = true;
    }
    
    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
        foreach (GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }

    void LoadNextLevel()
    {
        if (!PlayerPrefsManager.LevelUnlocked(SceneManager.GetActiveScene().buildIndex)) { 
        PlayerPrefsManager.UnlockLevel(SceneManager.GetActiveScene().buildIndex);
        }
        levelManager.LoadNextLevel();
    }
}
