using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootRemainManager : MonoBehaviour 
{
	public GameObject RemainTextObject;
	public int StartRemain = 3;

	private ClearFlagManager ClearFlag;
	private PlayerStatusManager PlayerState;
	private Text RemainText;

	void Start()
	{
		GameObject GameManager = GameObject.Find("GameManager");
		ClearFlag = GameManager.GetComponent<ClearFlagManager>();
		PlayerState = GameManager.GetComponent<PlayerStatusManager>();

		RemainText = RemainTextObject.GetComponent<Text>();
	}

	void Update()
	{
		RemainText.text = "残り " + StartRemain;

		/* プレイヤー残数が0になったらゲームオーバー */
		if( StartRemain == 0 && PlayerState.PlayerStatus == PLAYER_STATUS_T.IDLE ){
			ClearFlag.GameOver = true;
		}
	}

	public void DecrementRemain()
	{
		--StartRemain;
	}
}
