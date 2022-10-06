using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TL.Core;


namespace TL.UTilityAI
{


    public class AIBrain : MonoBehaviour
    {
        public Action bestAction { set; get; }
        private EnemyOneConrtoller eoc;

        // Start is called before the first frame update
        void Start()
        {
            eoc = GetComponent<EnemyOneConrtoller>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void DecideBestAction(Action[ ] actionsAvailable)
        {
            float score = 0f;
            int nextBestActionIndex = 0;
            for (int i  = 0; i < actionsAvailable.Length; i++)
            {
                if(ScoreAction(actionsAvailable[i]) > score)
                {
                    nextBestActionIndex = i;
                    score = actionsAvailable[i].score;
                }
            }

            bestAction = actionsAvailable[nextBestActionIndex];

        }


        public float ScoreAction(Action action)
        {
            float score = 1f;
            for(int  i = 0; i < action.considerations.Length; i++)
            {
                float considerationScore = action.considerations[i].ScoreConsideration();
                score *= considerationScore;

                if(score == 0)
                {
                    action.score = 0;
                    return action.score; // no point computing further
                }
            }

            float originalScore = score;
            float modFactor = 1 - (1 / action.considerations.Length);
            float makeupValue = (1 - originalScore) * modFactor;
            action.score = originalScore + (makeupValue * originalScore);

            return action.score;

        }




    }
}