using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GeneralFunction : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI BonusScoreText;
	private int _bonusScore { get { return PlayerPrefs.GetInt("Player's Apple"); } }

	private void Start()
	{
		BonusScore();
	}

	private void BonusScore() => BonusScoreText.text = _bonusScore.ToString();	
}
