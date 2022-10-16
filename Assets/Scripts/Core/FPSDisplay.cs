using UnityEngine;
using System.Collections;

public class FPSDisplay : MonoBehaviour
{
	private float _frequency = 1.0f;
	private string _fps;

	void Start()
	{
		Application.targetFrameRate = 60;
		StartCoroutine(FPS());
	}

	private IEnumerator FPS()
	{
		for (; ; )
		{
			// Capture frame-per-second
			int lastFrameCount = Time.frameCount;
			float lastTime = Time.realtimeSinceStartup;
			yield return new WaitForSeconds(_frequency);
			float timeSpan = Time.realtimeSinceStartup - lastTime;
			int frameCount = Time.frameCount - lastFrameCount;

			// Display it

			_fps = string.Format("FPS: {0}", Mathf.RoundToInt(frameCount / timeSpan));
		}	
	}

	private void OnGUI()
	{
		GUI.Label(new Rect(Screen.width - 100, 10, 150, 100), _fps);
	}
}