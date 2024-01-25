using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class HeroController : MonoBehaviour
{

    public List<HeroAction> randomActions;
    public HeroAction mainAction;
    private HeroAction chosenAction;

    public float ADHDTIME = 2;
    public float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        MicrophoneSample.OnThreshHold += OnThreshHoldReached;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime >= ADHDTIME){
            if(randomActions.Count > 0 && chosenAction == null && mainAction.CanLeaveState(this))
            {

            int ran = Random.Range(0,randomActions.Count);
            chosenAction = randomActions[ran];
            chosenAction.StartAction(this);
            }
        }else{
            currentTime += Time.deltaTime;
            chosenAction?.StopAction();
        }
    }

    public void OnThreshHoldReached(object sender, System.EventArgs args)
    {
        if(chosenAction != null)
        {
            chosenAction.StopAction();
        }
        mainAction.StartAction(this);
        
    }
}
