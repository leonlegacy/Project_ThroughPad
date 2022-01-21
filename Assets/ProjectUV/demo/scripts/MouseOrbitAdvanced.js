
var target : Transform;
var distance = 35.0;
 
var xSpeed = 8.0;
var ySpeed = 150.0;
 
var yMinLimit = -20;
var yMaxLimit = 80;
 
var distanceMin:float = 10;
var distanceMax:float = 150;
 
private var x = 0.0;
private var y = 0.0;

private var inputNotSet:boolean = false;
 
 
@script AddComponentMenu("Camera-Control/Mouse Orbit")
 
function Start () {
    var angles = transform.eulerAngles;
    x = angles.y;
    y = angles.x;
   
    // Make the rigid body is not changing rotation
    if (rigidbody)
        rigidbody.freezeRotation = true;
    
    // Input checking
  /*  try {
    	Input.GetAxis("Mouse ScrollWheel");
    } catch(err:UnityException) {
    	inputNotSet = true;
    	Debug.Log("The mouse scroll wheel has not been set up. Please go to Edit > ProjectSettings > Input and set up a \"Mouse ScrollWheel\" input (see doc for more infos).");
    }
    try {
    	Input.GetAxis("Mouse X");
    	Input.GetAxis("Mouse Y");
    } catch(err:UnityException) {
    	inputNotSet = true;
    	Debug.Log("At least one of the mouse axis is not setup correctly. Please go to Edit > ProjectSettings > Input and set up a \"Mouse X\" and \"Mouse Y\" input (see doc for more infos).");
    }*/
}

private var mouvementInertiel:Vector2;
private var resitance:float = 3.0;
 
function LateUpdate () {
	if (inputNotSet)		return;
    if (target) {
		if (Input.GetMouseButton(0)) {
			x += Input.GetAxis("Mouse X") * xSpeed * distance* 0.02;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
			mouvementInertiel = Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"))/100;
		} else {
			x += mouvementInertiel.x * xSpeed * distance;
			y -= mouvementInertiel.y * ySpeed;
			mouvementInertiel /= 1+0.01*resitance;
		}
       y = ClampAngle(y, yMinLimit, yMaxLimit);
       
        var rotation = Quaternion.Euler(y, x, 0);
        
        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*5, distanceMin, distanceMax);
       
        var hit : RaycastHit;
        if (Physics.Linecast (target.position, transform.position, hit)) {
        	if (hit.collider.gameObject == target.gameObject)
                distance -=  hit.distance;
        }
       
        var position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
 
        transform.rotation = rotation;
        transform.position = position;
   
    }

}
 
 
static function ClampAngle (angle : float, min : float, max : float) {
    if (angle < -360)
        angle += 360;
    if (angle > 360)
        angle -= 360;
    return Mathf.Clamp (angle, min, max);
}
 