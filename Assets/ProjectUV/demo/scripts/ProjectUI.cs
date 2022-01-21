using UnityEngine;
using System.Collections;

/**
 * 		Class used in ProjectUV demo scene "Multiple gameObjects".
 * 		This display buttons to project UV and to reset it.
 */

[ExecuteInEditMode()]
public class ProjectUI : MonoBehaviour {

	public GUISkin skin;
	private ProjectUV projectUV;

	void Start() {
		projectUV = GameObject.FindObjectOfType(typeof(ProjectUV)) as ProjectUV;
	}

	void OnGUI () {
		GUI.skin = skin;
		if (GUI.Button(new Rect(40, Screen.height - (Screen.height*0.3f) - 150, Screen.width * 0.3f, 65), "Project UVs")) {
			projectUV.Project();
		}
		if (GUI.Button(new Rect(40, Screen.height - (Screen.height*0.3f) - 70, Screen.width * 0.3f, 35), "Reset")) {
			projectUV.RestoreUVs();
		}
	}
}
