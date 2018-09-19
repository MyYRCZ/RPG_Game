using UnityEngine;
using System.Collections;
namespace FSM
{
    /// <summary>
    /// 巡逻状态
    /// </summary>
    public class StatePatrol : FSMStateBase
    {
        private Transform[] points;//巡逻点
        private Transform transRandNextPoint;//要巡逻的点（随机获取）
        CharacterController characterController;//控制器，通过它来移动物体
        private float needidletime = 0;
        private float nowidletime = 0;



        public StatePatrol(FSMSystem fms, Transform[] points, Transform trans, float speed)
        {
            this.fms = fms;
            this.points = points;
            this.curSpeed = speed;
            this.name = "patrol";//当前状态的名字
            this.transSelf = trans;
            this.transTarget = GameObject.FindGameObjectWithTag("Player").transform;
            characterController = transSelf.GetComponent<CharacterController>();
            getNextPoint();
        }
        
        public void getNextPoint()
        {
            if (points != null && points.Length>0)
            {
                Transform nextTrans=null;
                float distance = 0;
                float x = 0, z = 0;
                distance = Random.Range(0f, 10f);
                x = Random.Range(-1f, 1f);
                z = Random.Range(-1f, 1f);
                points[1].position = points[0].position + new Vector3(x, 0, z).normalized * distance;

                nextTrans = points[1];
                //while (transRandNextPoint!=null&&transRandNextPoint.Equals(nextTrans))
                //{
                //    nextTrans = points[1];
                //}
                transRandNextPoint = nextTrans;//更换不一样的巡逻点
                
            }
        }
        /// <summary>
        /// 执行当前状态的行为
        /// </summary>
        public override void action()
        {
            this.curSpeed = transSelf.GetComponent<enemyattribute>().Curspeed;
            Animator animator = transSelf.GetComponent<Animator>();
            float dis = Vector3.Distance(new Vector3(transSelf.position.x,0, transSelf.position.z),transRandNextPoint.position);//计算两个点之间的距离
            if (dis<=0.3f&& nowidletime == 0)
            {
                getNextPoint();
                animator.SetInteger("nowstate", 1);
                nowidletime += Time.deltaTime;
                needidletime = Random.Range(3f, 6f);
            }
             if(nowidletime != 0)
            {
                nowidletime += Time.deltaTime;
                if(nowidletime >= needidletime)
                {
                    rotateTheTarget(transSelf, transRandNextPoint);
                    characterController.Move(transSelf.forward * Time.deltaTime * curSpeed);
                    nowidletime = 0;
                    animator.SetInteger("nowstate", 2);
                }
            }
             else
            {
                //确定方向
                rotateTheTarget(transSelf, transRandNextPoint);
                //移动
                characterController.Move(transSelf.forward * Time.deltaTime * curSpeed);
                //Vector3 moveDirection = transNpc.TransformDirection(Vector3.Cross(Vector3.up, Vector3.left));
                //Vector3 velocity = moveDirection.normalized * curSpeed;
                //if (characterController != null)
                //{
                //    characterController.SimpleMove(velocity);
                //}
                //播放动画

                animator.SetInteger("nowstate", 2);
            }
           
        }

        public override void reason()
        {

            if (transSelf.GetComponent<enemyattribute>().isdead == true)
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
                fms.doTransition(ETransition.PATROL_TO_DEATH);
            }
            float dis = Vector3.Distance(transTarget.position, transSelf.position);
           if (transSelf.GetComponent<enemyattribute>().Target == null)//当怪物被攻击时
            {
                if (dis < 3 && Vector3.Distance(points[0].position, transSelf.position) <= 25&&!playerattribute.Instance.isdead)//巡逻的时候进入攻击范围
                {
                    transSelf.GetComponent<enemyattribute>().Target = transTarget;

                    fms.doTransition(ETransition.PATROL_TO_ATTACK);
                }
                else if (dis > 3 && dis < 8 && !playerattribute.Instance.isdead)
                {
                    transSelf.GetComponent<enemyattribute>().Target = transTarget;
                    fms.doTransition(ETransition.PATROL_TO_FOLLOW);
                }
            }
       
            else
            {
                fms.doTransition(ETransition.PATROL_TO_FOLLOW);
            }
        }
    }

}
