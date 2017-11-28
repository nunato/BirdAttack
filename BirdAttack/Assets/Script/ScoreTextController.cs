using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour
{
	public Text ScoreText;
	public Text HiScoreText;

	void Start ()
	{
		ScoreText.text = "Score: " + ScoreManager.gameScore;
		HiScoreText.text = "HiScore: " + ScoreManager.hiScore;
	}

	void Update ()
	{
		ScoreText.text = "Score: " + ScoreManager.gameScore;
		HiScoreText.text = "HiScore: " + ScoreManager.hiScore;
	}
}
