#pragma strict

var target : Transform; //the enemy's target
var moveSpeed = .00005; //move speed
var rotationSpeed = 3; //speed of turning
 
var myTransform : Transform; //current transform data of this enemy
 
function Awake()
{
    myTransform = transform; //cache transform data for easy access/preformance
}
 
function Start()
{
     target = GameObject.FindWithTag("Player").transform; //target the player
 
}
function FixedUpdate()
{
    //rotate to look at the player
    var targYPos = new Vector2(0, target.position.y);
    var myYPos = new Vector2(0, myTransform.position.y);
    var targXPos = new Vector2(target.position.x, 0);
    var myXPos = new Vector2(myTransform.position.x, 0);
    
    var diff = target.position - myTransform.position;
    //if(diff.y < 0.001 && diff.y > -0.001 && diff.x < 0.001 && diff.x > -0.001) {
    //	diff = new Vector2(0, .001);
    //}
        
    var xSq = (diff.x) * (diff.x);
    var ySq = diff.y * diff.y;
    var oneOver = 1 / (xSq + ySq);
    var normalized = Mathf.Sqrt( oneOver );
    var coefficient = normalized;
    diff.x *= coefficient * Time.deltaTime;
    diff.y *= coefficient * Time.deltaTime;
    
    //myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
    //Quaternion.LookRotation(diff), rotationSpeed*Time.deltaTime);
 
    //move towards the player
    
    myTransform.position += diff;
    
 	 if((targXPos - myXPos).x < 0 && myTransform.localScale.x == -.1) //target should face left
 	 	myTransform.localScale.x = .1;
 	 else if((targXPos - myXPos).x > 0 && myTransform.localScale.x == .1) //target should face right
 	 {
 	 	myTransform.localScale.x = -.1;
	 }
}
function Update () {

}