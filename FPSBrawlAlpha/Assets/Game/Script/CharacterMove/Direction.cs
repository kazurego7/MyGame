using UnityEngine;
using System.Collections;

public class Direction : MonoBehaviour {
	
	// プロパティ
	public Vector3 Put // 押された瞬間
	{
		get;
		set;
	}
	public Vector3 Held // 押され続けている
	{
		get;
		set;
	}
	public Vector3 Total // 合計
	{
		get{ return Put + Held; }
	}
	
	// Put Held Totalを初期化
	public void Initialize()
	{
		Put = Held = Vector3.zero;
	}
	
	// ButtonをDirectionに変換
	public void ConvertButton(string buttonName,Vector3 direction)
	{
		if (Input.GetButtonDown(buttonName)) {
			Put += direction;
		} else if (Input.GetButton(buttonName)) {
			Held += direction;
		}
	}
}