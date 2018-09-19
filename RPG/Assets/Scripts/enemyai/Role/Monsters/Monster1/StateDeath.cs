using UnityEngine;
using System.Collections;
namespace FSM
{
    /// <summary>
    /// 攻击状态
    /// </summary>
    public class StateDeath : FSMStateBase
    {
        private float deathtime;
        CharacterController characterController;//这个组件专门控制角色移动
        private Transform[] points;//巡逻点

        public StateDeath(FSMSystem fms, Transform[] points, Transform trans)
        {
            this.fms = fms;
            this.name = "death";//状态名字就叫攻击
            this.points = points;
            this.transSelf = trans;
            transTarget = GameObject.FindGameObjectWithTag("Player").transform;
            characterController = transSelf.GetComponent<CharacterController>();


        }
        public override void action()
        {
            this.curSpeed = transSelf.GetComponent<enemyattribute>().Curspeed;
           // rotateTheTarget(transSelf, transTarget);
            //characterController.Move(transSelf.forward * Time.deltaTime * curSpeed);
            Animator animator = transSelf.GetComponent<Animator>();
            animator.SetInteger("nowstate", 15);
             animator.SetBool("isdead", true);//播放死亡动画


        }

        public override void reason()
        {
          //  Debug.Log(deathtime);
            deathtime += Time.deltaTime;
            if (deathtime>=45)
            {
                
                deathtime = 0;
                transSelf.position = points[0].position;
                Animator animator = transSelf.GetComponent<Animator>();
                animator.SetBool("isdead", false);
                animator.SetInteger("nowstate", 1);
                transSelf.GetComponent<enemyattribute>().isdead = false;
                transSelf.GetComponent<enemyattribute>().isdrag = false;
                transSelf.GetComponent<enemyattribute>().Now_Hp = transSelf.GetComponent<enemyattribute>().Max_Hp;
                transSelf.GetComponent<enemyattribute>().Target = null;
                transSelf.GetComponent<enemyattribute>().buff1time = 0;
                transSelf.GetComponent<enemyattribute>().buff2time = 0;

                fms.doTransition(ETransition.DEATH_TO_PATROL);
            }
         
        }


    }
}

