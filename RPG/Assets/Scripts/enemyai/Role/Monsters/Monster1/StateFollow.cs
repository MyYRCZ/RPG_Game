using UnityEngine;
using System.Collections;
namespace FSM
{
    /// <summary>
    /// 追踪状态
    /// </summary>
    public class StateFollow : FSMStateBase
    {
        private Transform[] points;//巡逻点
        CharacterController characterController;
        public StateFollow(FSMSystem fms, Transform[] points, Transform trans,float speed)
        {
            this.fms = fms;
            this.name = "follow";
            this.curSpeed = speed;
            this.points = points;
            this.transSelf = trans;
            transTarget = GameObject.FindGameObjectWithTag("Player").transform;
            characterController = transSelf.GetComponent<CharacterController>();
        }
        public override void action()
        {
            this.curSpeed = transSelf.GetComponent< enemyattribute > ().Curspeed;
            Animator animator = transSelf.GetComponent<Animator>();
            // animation.CrossFade("run_forward");
            rotateTheTarget(transSelf,transTarget);
            characterController.Move(transSelf.forward * Time.deltaTime * curSpeed);
            //Vector3 moveDirection = transNpc.TransformDirection(Vector3.Cross(Vector3.up, Vector3.left));
            //Vector3 velocity = moveDirection.normalized * curSpeed;
            //if (characterController != null)
            //{
            //    characterController.SimpleMove(velocity);
            //}
            //播放动画
            animator.SetInteger("nowstate", 2);
         //   Debug.Log(curSpeed);

        }

        public override void reason()
        {
            float dis = Vector3.Distance(transSelf.position, transTarget.position);
         
             if (Vector3.Distance(transSelf.position, points[0].position) >= 25)
            {
               
                fms.doTransition(ETransition.FOLLOW_TO_LEFTBATTLE);
            }
            else if (dis <=3)//距离目标3米转到攻击状态
            {
                fms.doTransition(ETransition.FOLLOW_TO_ATTACK);
            }
            else if (playerattribute.Instance.isdead == true)
            {
                if (transSelf.GetComponent<enemyattribute>().monstername == "绿岩卫士")
                {
                    playerattribute.Instance.exp += 30;
                    if (playerattribute.Instance.quest2 == 1)
                        questcontrol.Instance.quest2num += 1;
                }
                if (transSelf.GetComponent<enemyattribute>().monstername == "巡山小妖")
                {
                    playerattribute.Instance.exp += 10;
                    if (playerattribute.Instance.quest2 == 1)
                        questcontrol.Instance.quest2num += 1;
                }
                if (transSelf.GetComponent<enemyattribute>().monstername == "兽人头领")
                {
                    playerattribute.Instance.exp += 100;
                    if (playerattribute.Instance.quest2 == 1)
                        questcontrol.Instance.quest2num += 1;
                }
                fms.doTransition(ETransition.FOLLOW_TO_LEFTBATTLE);
            }
            else if (transSelf.GetComponent<enemyattribute>().isdead == true)
            {
                fms.doTransition(ETransition.FOLLOW_TO_DEATH);
            }
        }
    }

}
