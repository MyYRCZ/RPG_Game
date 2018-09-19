using UnityEngine;
using System.Collections;
using System.Collections.Generic;//各种集合，数据结构
namespace FSM
{
    public enum ETransition//状态机中的连线（转换条件）
    {
        NULL,//不需要转换
        PATROL_TO_IDLE,
        PATROL_TO_FOLLOW,//巡逻到跟随
        PATROL_TO_ATTACK,//巡逻到攻击
        FOLLOW_TO_ATTACK,//跟随到攻击
        FOLLOW_TO_LEFTBATTLE,//跟随到脱战
        ATTACK_TO_FOLLOW,//攻击到跟随
        ATTACK_TO_LEFTBATTLE,//攻击到脱战
        LEFTBATTLE_TO_PATROL, //脱战到巡逻
        DEATH_TO_PATROL, //死亡到巡逻
        PATROL_TO_DEATH,   //巡逻到死亡
        FOLLOW_TO_DEATH,   //跟随到死亡
        ATTACK_TO_DEATH,//  攻击到死亡
        LEFTBATTLE_TO_DEATH, // 脱战到死亡


    }
    public abstract class FSMStateBase
    {
        protected string name;//状态的名字

        protected float curRotateSpeed = 20;//角速度
        protected float curSpeed = 10;//移动速度

        protected FSMSystem fms;//状态机管理器
        protected Transform transTarget;//追踪的目标
        protected Transform transSelf;//自己

        
        public string Name { get { return name; } }
        protected Dictionary<ETransition, string> map = new Dictionary<ETransition, string>();//装换条件和状态的名字
        /// <summary>
        /// 添加条件
        /// </summary>
        /// <param name="transition"></param>
        /// <param name="stateName"></param>
        public void addTransition(ETransition transition, string stateName)
        {
            if (transition == ETransition.NULL || string.IsNullOrEmpty(stateName))
            {
                return;//防错处理 
            }
            if (!map.ContainsKey(transition))//判断集合内是否有对应的键名
            {
                map.Add(transition,stateName);
            }
        }

        /// <summary>
        /// 删除条件
        /// </summary>
        /// <param name="transition"></param>
        public void deleteTransition(ETransition transition)
        {
            if (transition == ETransition.NULL)
            {
                return;
            }
            if (map.ContainsKey(transition))
            {
                map.Remove(transition);
            }

        }
        /// <summary>
        /// 旋转当前位置到目标位置
        /// </summary>
        /// <param name="cur"></param>
        /// <param name="aim"></param>
        public void rotateTheTarget(Transform cur, Transform aim)
        {
            Quaternion destRotation;

            Vector3 tmpCur = cur.position;
            Vector3 tmpAim = aim.position;
            tmpCur.y = 0.0f;
            tmpAim.y = 0.0f;
            Vector3 relativePos = tmpAim - tmpCur;

            destRotation = Quaternion.LookRotation(relativePos);
            cur.rotation = Quaternion.Slerp(cur.rotation, destRotation, Time.deltaTime * curRotateSpeed);//插值运算
        }
        /// <summary>
        /// 获取新的状态，如果有状态过渡
        /// </summary>
        /// <param name="transition"></param>
        /// <returns></returns>
        public string getOutState(ETransition transition)// 状态切换
        {
            if (map.ContainsKey(transition))
            {
                return map[transition];
            }
            else {
                return null;
            }
        }
        //进入之前做的事情
        public virtual void doBeforeEntering() { }
        //离开之前做的事情
        public virtual void doBeforeLeaving() { }
        public abstract void action();//控制行为（循环函数Update,控制物体的移动）
        public abstract void reason();//检测转换（条件检测）

    }
}

