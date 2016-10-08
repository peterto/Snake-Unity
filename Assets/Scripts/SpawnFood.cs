using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {

	public GameObject _food;

	public Transform _borderTop;
	public Transform _borderBottom;
	public Transform _borderLeft;
	public Transform _borderRight;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("Spawn", 3, 4);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn() {
		int x = (int)Random.Range (_borderLeft.position.x, _borderRight.position.x);
		int y = (int)Random.Range (_borderBottom.position.y, _borderTop.position.y);

		Instantiate (_food, new Vector2 (x, y), Quaternion.identity);
	}
}
