using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Mettle_AI/Decisions/Scan")]

public class ScanDecision : Decision {

   public override bool Decide(StateController controller){

        bool noEnemyInSight = Scan(controller);
        return noEnemyInSight;

   }

   private bool Scan(StateController controller){
        
        // Rotate while looking  as this uses Raycast vision
        controller.m_Agent.isStopped = true;
        controller.transform.Rotate(0, controller.enemyStats.searchingTurnSpeed * Time.deltaTime, 0);
        controller.m_Anim.SetTrigger("Looking");
        // check aginst enemyStats
        return controller.CheckIfCountDownElapsed(controller.enemyStats.searchDuration);

   }
	
}
