using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroAction : MonoBehaviour
{

    public float actionPerformTime;
    public float currentTime;
    public bool hasStarted,canExit;
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
    }

    public void Update()
    {
        if(currentTime < actionPerformTime)
        {
            DoAction();
            currentTime += Time.deltaTime;
        }else{
            StopAction();
        }
    }
}
