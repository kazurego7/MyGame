using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
	private static ObjectPool _instance;
	// シングルトン
	public static ObjectPool instance
	{
		get
		{
			if ( _instance == null) {

				// シーン上から取得
				_instance = FindObjectOfType<ObjectPool>();
				if ( _instance == null) {
					// ゲームオブジェクトの生成とコンポーネントの追加
					_instance = new GameObject("ObjectPool").AddComponent<ObjectPool>();
				}
			}
			return _instance;
		}
	}

	// ゲームオブジェクトのDictionary
	private Dictionary<int, List<GameObject>> pooledGameObjects = new Dictionary<int, List<GameObject>>();

	public GameObject GetGameObject(GameObject prefab, Vector3 position, Quaternion rotation)
	{
		// 受け取ったprefabのインスタンスＩＤをkeyとする
		int key = prefab.GetInstanceID ();

		// オブジェクトプールに指定のKeyなければ新しく生成する
		if (pooledGameObjects.ContainsKey (key) == false) {
			pooledGameObjects.Add(key, new List<GameObject>());
		}

		List<GameObject> gameObjects = pooledGameObjects[key];

		// ゲームオブジェクトが非アクティブなものを探す
		foreach (var tmpGO in gameObjects) {
			if(tmpGO.activeInHierarchy == false) {
				tmpGO.transform.position = position;
				tmpGO.transform.rotation = rotation;
				tmpGO.SetActive(true);
				return tmpGO;
			}
		}

		// 使用できるものがないのでゲームオブジェクトを新しく生成する
		GameObject go = (GameObject)Instantiate (prefab, position, rotation);
		go.transform.parent = this.transform;
		return go;
	}

	public void ReleaseGameObject(GameObject go)
	{
		// 非アクティブにする
		go.SetActive (false);
	}

}
