using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	private static int GameScore = 0;
	private static int HiScore = 0;
	private static RespownManager respownManager;
	private const string HIGH_SCORE_KEY = "HiScoreKey";

	public static int gameScore
	{
		get { return GameScore; }
	}

	public static int hiScore
	{
		get{ return HiScore; }
	}

	void Start ()
	{
		GameScore = 0;
		GameObject reManager = GameObject.Find("RespownManager");
		respownManager = reManager.gameObject.GetComponent<RespownManager>();
		HiScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
	}

	void Update()
	{
		if( GameScore > HiScore ){
			HiScore = GameScore;
			PlayerPrefs.SetInt( HIGH_SCORE_KEY, HiScore );
		}
	}

	public static void AddScore( int newScore )
	{
		if( respownManager.isPlayerDead == false ){
			GameScore += newScore;
		}
	}
}
