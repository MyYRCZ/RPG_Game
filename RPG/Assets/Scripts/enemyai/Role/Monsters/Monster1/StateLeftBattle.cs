using UnityEngine;
using System.Collections;
namespace FSM
{
    /// <summary>
    /// 攻击状态
    /// </summary>
    public class StateLeftBattle : FSMStateBase
    {
        private Transform[] points;//巡逻点
        CharacterController characterController;//这个组件专门控制角色移动


        public StateLeftBattle(FSMSystem fms, Transform[] points, Transform trans, float speed)
        {
            this.fms = fms;
            this.name = "leftbattle";//状态名字就叫脱战
            this.curSpeed = speed;
            this.points = points;
            this.transSelf = trans;
            transTarget = points[0].transform;
            characterController = transSelf.GetComponent<CharacterController>();


        }
        public override void action()
        {
            this.curSpeed = transSelf.GetComponent<enemyattribute>().Curspeed;
            rotateTheTarget(transSelf, transTarget);
            characterController.Move(transSelf.forward * Time.deltaTime * curSpeed);
            //characterController.Move(transSelf.forward * Time.deltaTime * curSpeed);
            Animator animator = transSelf.GetComponent<Animator>();
            animator.SetInteger("nowstate", 2);


        }

        public override void reason()
        {
            float dis = Vector3.Distance(transSelf.position, transTarget.position);
            if (dis<0.3f)//
            {
                transSelf.transform.GetComponent<enemyattribute>().Now_Hp = transSelf.transform.GetComponent<enemyattribute>().Max_Hp;

                transSelf.transform.GetComponent<enemyattribute>().Target = null;
                fms.doTransition(ETransition.LEFTBATTLE_TO_PATROL);
            }
            else if (transSelf.GetComponent<enemyattribute>().isdead == true)
            {
                fms.doTransition(ETransition.LEFTBATTLE_TO_DEATH);
            }

        }


    }
}

