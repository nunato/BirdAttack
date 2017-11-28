using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClearManager : MonoBehaviour
{
	private static bool stageClearFlag;

	void Awake()
	{
		stageClearFlag = false;
	}

	void Update()
	{
		if( Input.GetKeyDown(KeyCode.R) && stageClearFlag == true ){
			SceneManager.LoadScene("NeneGameStageSelect");
			stageClearFlag = false;
		}
	}

	public static void SetStageClearFlag( bool clearFlag )
	{
		stageClearFlag = clearFlag;
	}
}
