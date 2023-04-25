using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
    [Condition("HasBeenFound")]
    public class HasBeenFound : GOCondition
    {
        [InParam("npc")] NPCInteractable npc;
        public override bool Check()
        {
            return npc.hasBeenRescued; 
        }
    }
}
