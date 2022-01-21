using UnityEngine;
using System.Collections;

/**
 * 		This class is used in the ProjectUV demo "Simple API example" scene.
 */

public class CameraUI : MonoBehaviour {

	public GUISkin skin;
	private ProjectUV projectUV;
	private Color original_color;

	void Start() {
		projectUV = FindObjectOfType(typeof(ProjectUV)) as ProjectUV;
		original_color = transform.Find("Arrow").GetComponent<Renderer>().material.color;
	}

	void OnGUI () {
		Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
		GUI.skin = skin;
		if (	GUI.Button(new Rect(screenPos.x - 50, Screen.height - screenPos.y, 100,25), this.name)) {
			projectUV.camera_projection = this.GetComponent<Camera>();
			projectUV.Project();
			// recover colors of all arrows
			GameObject[] arrows = GameObject.FindGameObjectsWithTag("arrow");
			foreach (GameObject arrow in arrows) {
				arrow.GetComponent<Renderer>().material.color = original_color;
			}
			// change arrow color
			transform.Find("Arrow").GetComponent<Renderer>().material.color = Color.white;
		}
	}

}
