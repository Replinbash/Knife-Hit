using UnityEngine;
using Knife.Attack;
using TMPro;
using UnityEngine.Events;

namespace Knife.Core // Bu scripte olacak olanlar: puan, oyun reseti...
{
	public class GameManager : MonoSingleton<GameManager>
	{	
		[Header("Stage Text")]
		public TextMeshProUGUI stageText;
		public TextMeshProUGUI StageText { get { return stageText; } }

		[Header("Game Score")]
		[SerializeField] TextMeshProUGUI GameScoreText;
		private int _gameScore;

		[Header("Bonus Score")]
		[SerializeField] TextMeshProUGUI BonusScoreText;
		private static int _bonusScore
		{
			get { return PlayerPrefs.GetInt("Player's Apple", 0); }
			set { PlayerPrefs.SetInt("Player's Apple", value); }
		}

		private bool isRestarted = false;
		public UnityEvent gameOver;

		private void OnEnable() 
		{
			KnifeController.CircleDamage += GameScore;
			Bonus.BonusDamage += BonusScore;
		}
		private void OnDisable()
		{
			KnifeController.CircleDamage -= GameScore;
			Bonus.BonusDamage -= BonusScore;
		}

		private void Start()
		{
			isRestarted = false;
			Text(BonusScoreText, _bonusScore);
		}

		private void GameScore()
		{
			_gameScore++;
			Text(GameScoreText, _gameScore);
		}

		private void BonusScore()
		{
			_bonusScore++;
			Text(BonusScoreText, _bonusScore);
		}

		public string Text(TextMeshProUGUI text, int value)
		{
			return text.text = value.ToString();
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