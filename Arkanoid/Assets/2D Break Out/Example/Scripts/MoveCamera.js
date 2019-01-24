#pragma strict
var minX:float = -10;
var maxX:float = 10;

function Update () {
     var xMove : float = Input.GetAxis("Horizontal") * Time.deltaTime * 20;
     transform.Translate(Vector3(xMove,0,0));
     transform.position.x = Mathf.Clamp(transform.position.x, minX, maxX);
 }
