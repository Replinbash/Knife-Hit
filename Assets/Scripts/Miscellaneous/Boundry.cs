using UnityEngine;
using Knife.Core;
using System.Collections;

public class Boundry : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(collision.gameObject);
		StartCoroutine(GameOver(0.5f));
	}

	private IEnumerator GameOver(float timer)
	{
		yield return new WaitForSeconds(timer);
		GameManager.Instance.GameOver();
	}
}
