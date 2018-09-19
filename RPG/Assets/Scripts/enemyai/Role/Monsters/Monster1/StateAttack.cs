using UnityEngine;
using System.Collections;
namespace FSM
{
    /// <summary>
    /// 攻击状态
    /// </summary>
    public class StateAttack : FSMStateBase
    {
        CharacterController characterController;//这个组件专门控制角色移动
        private Transform[] points;//巡逻点

        public StateAttack(FSMSystem fms, Transform[] points, Transform trans)
        {
            this.fms = fms;
            this.name = "attack";//状态名字就叫攻击
            this.points = points;
            this.transSelf = trans;
            transTarget = GameObject.FindGameObjectWithTag("Player").transform;
            characterController = transSelf.GetComponent<CharacterController>();


        }
        public override void action()
        {
            this.curSpeed = transSelf.GetComponent<enemyattribute>().Curspeed;
            rotateTheTarget(transSelf, transTarget);
            //characterController.Move(transSelf.forward * Time.deltaTime * curSpeed);
            Animator animator = transSelf.GetComponent<Animator>();
            animator.SetInteger("nowstate", 3);//播放战力开火动画


        }

        public override void reason()
        {
            float dis = Vector3.Distance(transSelf.position, transTarget.position);
            if (dis >3 && dis < 10)
            {
                fms.doTransition(ETransition.ATTACK_TO_FOLLOW);
            }
            else if ( Vector3.Distance(transSelf.position, points[0].position)>=25)
            {
                fms.doTransition(ETransition.ATTACK_TO_LEFTBATTLE);
            }
            else if (playerattribute.Instance.isdead==true)
            {
                fms.doTransition(ETransition.ATTACK_TO_LEFTBATTLE);
            }
            else if (transSelf.GetComponent<enemyattribute>().isdead == true)
            {

                if (transSelf.GetComponent<enemyattribute>().monstername == "绿岩卫士" )
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
                fms.doTransition(ETransition.ATTACK_TO_DEATH);
              
            }
        }


    }
}

