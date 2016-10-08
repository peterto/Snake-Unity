using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {

	private Vector2 _dir = Vector2.right;
	private List<Transform> _tail = new List<Transform> ();
	private bool _ate = false;

	public GameObject _tailPrefab;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Move", 0.3f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.RightArrow))
			_dir = Vector2.right;
		else if (Input.GetKey (KeyCode.DownArrow))
			_dir = -Vector2.up;
		else if (Input.GetKey (KeyCode.UpArrow))
			_dir = Vector2.up;
		else if (Input.GetKey (KeyCode.LeftArrow))
			_dir = -Vector2.right;
	
	}

	void Move() {
		Vector2 newVector = transform.position;
		transform.Translate (_dir);

		if (_ate) {
			GameObject gameObject = (GameObject)Instantiate (_tailPrefab, newVector, Quaternion.identity);

			_tail.Insert (0, gameObject.transform);

			_ate = false;
		} else if (_tail.Count > 0) {
			_tail.Last().position = newVector;
			_tail.Insert (0, _tail.Last());
			_tail.RemoveAt (_tail.Count - 1);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.name.StartsWith ("food")) {
			_ate = true;
			Destroy (col.gameObject);
		} else {
			
		}

	}
}
