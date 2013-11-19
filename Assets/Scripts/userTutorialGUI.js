#pragma strict

var style : GUIStyle;

function Start () {
	style.fontSize = 24;
}

function Update () {

}

function OnGUI(){
	
	GUI.Label(new Rect(200,200,100, 100),"Use W,A,S,D to move around", style);

}