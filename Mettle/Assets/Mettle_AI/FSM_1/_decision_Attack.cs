using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Decisions/Attack")]

public class _decision_Attack : Decision {

	public override bool Decide (StateController controller){

        bool inRange = RangeOK(controller);
        return inRange;

    }

    private bool RangeOK(StateController controller){

        if(Vector3.Distance(controller.transform.position, controller.m_EnemyMettle.transform.position) <= 1.3f){
                
                return true;   
                
        }  else{

            return false;
        }

    }
}
