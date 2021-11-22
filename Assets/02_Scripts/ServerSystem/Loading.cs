using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
	public Image loadingBar;
    public Text loadingStatus;

	public static string loadScene;

	public static void LoadSceneHandle(string _name)
	{
		loadScene = _name;
		LoadScene();
	}

	private void Start() 
	{
		loadingBar.fillAmount = 0;
		StartCoroutine(LoadAsyncScene());	
	}

	public static void LoadScene()
	{
		SceneManager.LoadScene("Loading");
	}

	IEnumerator LoadAsyncScene()
	{
		yield return null;
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(loadScene);
		asyncOperation.allowSceneActivation = false;
		float timeC = 0;
		while (!asyncOperation.isDone)
		{
			yield return null;
			timeC += Time.deltaTime;
			if (asyncOperation.progress >= 0.9f)
			{
				loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, 1, timeC);
                loadingStatus.text = (asyncOperation.progress * 100f).ToString() + "%"; 
				if (loadingBar.fillAmount == 1.0f)
				{
					asyncOperation.allowSceneActivation = true;
				}
			}
			else
			{
				loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, asyncOperation.progress, timeC);
                loadingStatus.text = (asyncOperation.progress * 100f).ToString() + "%";
				if (loadingBar.fillAmount >= asyncOperation.progress)
				{
					timeC = 0f;
				}
			}
		}
	}
}