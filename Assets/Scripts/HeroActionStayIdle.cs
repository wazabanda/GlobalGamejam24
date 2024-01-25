using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HeroActionStayIdle : HeroAction
{
    public Transform idlePosition;
    public override void DoAction()
    {
        print("idle");
        transform.DOMove(idlePosition.position,2*Time.deltaTime);
    }
}
