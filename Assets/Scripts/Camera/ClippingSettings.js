#pragma strict
 
 function Start () {
     
     var distances = new float[32];
     distances[6] = 1000;
     GetComponent.<Camera>().layerCullDistances = distances;
     
 }
 
 function Update () {
     
 } 