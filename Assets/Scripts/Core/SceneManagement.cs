using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoSingleton<SceneManagement>
{
	public void LoadScene(int buildIndex)
	{
		SceneManager.LoadScene(buildIndex);
	}
}
