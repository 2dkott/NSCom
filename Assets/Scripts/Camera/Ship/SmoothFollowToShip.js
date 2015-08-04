/*
This camera smoothes out rotation around the y-axis and height.
Horizontal Distance to the target is always fixed.

There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.

For every of those smoothed values we calculate the wanted value and the current value.
Then we smooth it using the Lerp function.
Then we apply the smoothed values to the transform's position.
*/

// The target we are following
var target : Transform;
var posTarget : Transform;
// The distance in the x-z plane to the target
var distance = 1.0;
// the height we want the camera to be above the target
var height = 5.0;
// How much we 
var heightDamping = 1.0;
var rotationDamping = 3.0;
var tempVector : Vector3;

// Place the script in the Camera-Control group in the component menu
@script AddComponentMenu("Camera-Control/Smooth Follow")


function LateUpdate () {
	// Early out if we don't have a target
	if (!target)
		return;
	
	// Calculate the current rotation angles
	var wantedRotationAngle = target.eulerAngles.y;
	var wantedRotationAngleX = target.eulerAngles.x;
	var wantedRotationAngleZ = target.eulerAngles.z;
	var wantedHeight = target.position.y + height;
		
	var currentRotationAngle = transform.eulerAngles.y;
	var currentRotationAngleX = transform.eulerAngles.x;
	var currentRotationAngleZ = transform.eulerAngles.z;
	var currentHeight = transform.position.y;
		
	// Damp the height
	
	tempVector = posTarget.localPosition;
	tempVector.y = tempVector.y + 1.0;
	
	var wantedPos = posTarget.TransformPoint(tempVector);
	
	currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
	var currentPos = Vector3.Lerp(transform.position, wantedPos, heightDamping * Time.deltaTime);
	// Damp the rotation around the y-axis
	currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
	currentRotationAngleX = Mathf.LerpAngle (currentRotationAngleX, wantedRotationAngleX, rotationDamping * Time.deltaTime);
	currentRotationAngleZ = Mathf.LerpAngle (currentRotationAngleZ, wantedRotationAngleZ, rotationDamping * Time.deltaTime);
	// Convert the angle into a rotation
	var currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
	
	// Set the position of the camera on the x-z plane to:
	// distance meters behind the target
	//transform.position = target.position;
	transform.position = currentPos;
	//transform.position -= currentRotation * Vector3.forward;

	// Set the height of the camera
	//transform.position.y = currentHeight;
	
	// Always look at the target
	//transform.LookAt (target);
}