using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Knife.Core // Bu scripte olacak olanlar: puan, oyun reseti...
{
	public class GameManager : MonoSingleton<GameManager>
	{
		private bool isRestarted = false;

		public UnityEvent gameOver;

		public TextMeshProUGUI stageText;
		public TextMeshProUGUI StageText { get { return stageText; } }

		private void Start()
		{
			isRestarted = false;
		}

		public void GameOver()
		{
			if (!isRestarted)
			{
				gameOver?.Invoke();
				isRestarted = true;
			}
		}
	}
}