using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TL.Core;


namespace TL.UTilityAI
{


    public abstract class Action : ScriptableObject
    {
        public string name;
        private float _score;

        public float score
        {
        get{return score;}
        set
            {
                this._score = Mathf.Clamp01(value);
             }
        }

        public Consideration[] considerations;

        public virtual void Awake()
        {

        }

        public abstract void Execute(EnemyOneConrtoller eoc);
     

    }
}
