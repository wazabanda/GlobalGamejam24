using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class HeroActionMoveToPoints : HeroAction
{
    public List<Transform> positions;
    public List<Transform> vistedLocations;
    public int selectedPoint;
    public float timeToMoveToPoint;
    public float timeToStayAtPoint;
    public float currentActionTime;
    
    public bool currentlyAtPont = false;
    // Start is called before the first frame update
   
    

    public override void DoAction(){
        if(Vector2.Distance(transform.position,positions[selectedPoint].position) < 1)
        {
            currentlyAtPont = true;
        }
        if(currentlyAtPont)
        {
            canExit = false;
        }else{
            transform.DOMove(positions[selectedPoint].position,timeToMoveToPoint *Time.deltaTime);
            canExit = true;
            
        }
    }
}
