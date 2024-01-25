using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroAction : MonoBehaviour
{

    public float actionPerformTime;
    public float currentTime;
    public bool hasStarted,canExit = true;


    public void StartAction(HeroController controller)
    {
        
        hasStarted = true;
    }
    
    public virtual void DoAction(){

    }
    public void StopAction()
    {
        canExit = true;
        hasStarted = false;
    }
    public bool CanLeaveState(HeroController controller)
    {
        return canExit;
    }

    public void Start()
    {
        currentTime = 0;
        hasStarted = false;
        canExit = true;
    }

    public void Update()
    {
        if(hasStarted == false){
            return;
        }
        if(currentTime < actionPerformTime )
        {
            DoAction();
            currentTime += Time.deltaTime;
        }else{
            StopAction();
        }
    }
}
