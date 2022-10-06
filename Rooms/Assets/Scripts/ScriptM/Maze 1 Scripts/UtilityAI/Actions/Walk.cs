using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TL.UTilityAI.Actions;
using TL.Core;

namespace TL.UTilityAI.Actions
{

    [CreateAssetMenu(fileName ="Walk", menuName ="UtilityAI/Actions/Walk")]

    public class Walk : Action
    {
        public override void Execute(EnemyOneConrtoller eoc)
        {
            eoc.DoWalk(6);
        }


    }
}