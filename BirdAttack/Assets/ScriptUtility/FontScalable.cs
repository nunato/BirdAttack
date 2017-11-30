using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FontScalable : MonoBehaviour
{
	public float fontScale = 1;

	private int fontMaxSize = 128;
	private TextMesh textMesh;

	void Start()
	{
		textMesh = GetComponent<TextMesh>();
	}

	void Update()
	{
		int fontSize = Mathf.Max( fontMaxSize, textMesh.fontSize );
		textMesh.fontSize = fontSize;
		float scale = 0.1f * fontMaxSize / fontSize;
		textMesh.characterSize = scale * fontScale;
	}
}
