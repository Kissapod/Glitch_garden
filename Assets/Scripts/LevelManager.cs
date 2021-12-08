using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{

	public float autoLoadNextLevelAfter;
	private int sceneIndex;
	void Start()
	{
		sceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (autoLoadNextLevelAfter <= 0)
		{
			Debug.LogWarning("Недопустимое значение. Используйте только положительное число");
		}
		else
		{
			Invoke("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}
	public void LoadLevel(string name)
	{
		Debug.Log("New Level load: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest()
	{
		Debug.Log("Quit requested");
		Application.Quit();
	}
	public void LoadNextLevel()
	{
		SceneManager.LoadScene(sceneIndex + 1);
	}
}
