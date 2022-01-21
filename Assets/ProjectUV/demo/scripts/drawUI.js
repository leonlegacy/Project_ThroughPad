#pragma strict

@script ExecuteInEditMode()

public var border1:boolean = false;
public var text:String = "Hello World";
public var skin:GUISkin;

function OnGUI() {
	// Draw a border around the camera bounds
	var rect:Rect = this.camera.pixelRect;
	var thickness:float = 1.5f;
	var color = new Color(0.09f, 0.377f, 1.0f);
	
	if (border1) {
		// the outline around the camera view
		DrawQuad(Rect(rect.x-thickness, (Screen.height - rect.y - rect.height)-thickness, rect.width+thickness*2, thickness), color);
		DrawQuad(Rect(rect.x+rect.width, (Screen.height - rect.y - rect.height)-thickness, thickness, rect.height+thickness*2), color);
		DrawQuad(Rect(rect.x-thickness, (Screen.height - rect.y - rect.height)+rect.height, rect.width+thickness*2, thickness), color);
		DrawQuad(Rect(rect.x-thickness, (Screen.height - rect.y - rect.height)-thickness, thickness, rect.height+thickness*2), color);
	}
	
	// Text
	GUI.skin = skin;
	GUI.color = Color.black;
	GUI.Label( Rect(8, 12, Screen.width-20,150), text);
	GUI.color = Color.white;
	GUI.Label( Rect(10, 10, Screen.width-20,150), text);
}

function DrawQuad(position:Rect, color:Color):void {
	var texture:Texture2D = new Texture2D(1, 1);
	texture.SetPixel(0,0,color);
	texture.Apply();
	GUI.skin.box.normal.background = texture;
	GUI.skin.box.border = new RectOffset(0,0,0,0);
	GUI.Box(position, GUIContent.none);
}