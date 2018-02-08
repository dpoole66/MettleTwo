﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Decisions/Attack")]

public class AttackDecison : Decision {

    public override bool Decide(StateController controller) {

        bool attackTarget = Attack(controller);
        return attackTarget;

    }

    private bool Attack(StateController controller) {

        Debug.DrawRay(controller.m_MettleEye.position, controller.m_MettleEye.forward.normalized *
        controller.enemyStats.attackRange, Color.red);

            if (Vector3.Distance(controller.transform.position, controller.chaseTarget.transform.position) <= controller.enemyStats.attackRange) {

            controller.enemyStats.enemyAttacking = true;
            return true;

            } else
            controller.enemyStats.enemyAttacking = false;
        return false;

    }

}