using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * ゲームクリアフラグを管理するクラス
 * ゲーム開始時にターゲットとなるオブジェクトを見つけて、
 * オブジェクトが消滅したらゲームクリアとする
 */
public class ClearFlagManager : MonoBehaviour
{
	public GameObject ClearText;

	private bool IsStageClear;
	private bool IsGameOver;
	private Text targetText;
	private GameObject TargetObj;

	void Start()
	{
		IsStageClear = false;
		IsGameOver = false;
		targetText = ClearText.GetComponent<Text>();
		TargetObj = GameObject.FindGameObjectWithTag("Target");
	}

	void Update()
	{
		if( TargetObj == null && IsStageClear != true ){
			IsStageClear = true;
			targetText.text = "Stage Clear";
			ClearText.SetActive( true );
		}

		if( IsGameOver == true ){
			targetText.text = "Game Over";
			ClearText.SetActive( true );
		}
	}

	public bool isStageClear
	{
		get{ return IsStageClear; }
	}

	public bool GameOver
	{
		set{ IsGameOver = value; }
		get{ return IsGameOver; }
	}
}
