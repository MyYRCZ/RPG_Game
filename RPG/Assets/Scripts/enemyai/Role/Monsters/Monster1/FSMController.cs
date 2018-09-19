using UnityEngine;
using System.Collections;
using FSM;
public class FSMController : MonoBehaviour {
    private FSMSystem fms;///FSM系统，用来管理状态
    public Transform[] points;
    Transform transTarget;
    private float CurSpeed;
    // Use this for initialization
    void Start () {
        //查找巡逻点
        //GameObject curGo = GameObject.FindGameObjectWithTag("PointsPatrol");
        //int count=curGo.transform.childCount;
        //points=new Transform[count];
        //int index=0;
        //foreach (Transform a in curGo.transform)
        //{
        //    points[index] = a;
        //    index++;
        //}
        //创建有限状态机
        CurSpeed = GetComponent<enemyattribute>().Curspeed; 
       transTarget = GameObject.FindGameObjectWithTag("Player").transform;


        makeFMS();//状态机系统的初始化
	}
	
	// Update is called once per frame
	void Update () {
      //  CurSpeed = GetComponent<enemyattribute>().Curspeed;
        if (fms.CurState != null)
        {
            fms.CurState.action();
            fms.CurState.reason();
           // print("fms.CurState.Name=" + fms.CurState.Name);
            //print(this.GetComponent<enemyattribute>().isdead);
            //float dis = Vector3.Distance(transform.position, transTarget.position);
            //print(dis);
            //  if(Vector3.Distance(transform.position, points[0].position)>=25.0f)
            //    {
            //        if (fms.CurState.Name == "follow")
            //        {
            //            fms.doTransition(ETransition.FOLLOW_TO_PATROL);
            //        }
            //        else if (fms.CurState.Name == "attack")
            //        {
            //            fms.doTransition(ETransition.ATTACK_TO_FOLLOW);
            //        }
            //    }

        }
        
	}
    private void makeFMS()
    {
        fms = new FSMSystem();//状态机管理系统

        StatePatrol statePatrol = new StatePatrol(fms, points,transform,CurSpeed);//巡逻状态
        statePatrol.addTransition(ETransition.PATROL_TO_FOLLOW, "follow");
        statePatrol.addTransition(ETransition.PATROL_TO_ATTACK, "attack");
        statePatrol.addTransition(ETransition.PATROL_TO_DEATH, "death");



        StateFollow stateFollow = new StateFollow(fms, points, transform, CurSpeed);//跟随状态
        stateFollow.addTransition(ETransition.FOLLOW_TO_ATTACK, "attack");
        stateFollow.addTransition(ETransition.FOLLOW_TO_LEFTBATTLE, "leftbattle");
        stateFollow.addTransition(ETransition.FOLLOW_TO_DEATH, "death");

        StateAttack stateAttack = new StateAttack(fms, points, transform);//攻击状态
        stateAttack.addTransition(ETransition.ATTACK_TO_FOLLOW, "follow");
        stateAttack.addTransition(ETransition.ATTACK_TO_LEFTBATTLE, "leftbattle");
        stateAttack.addTransition(ETransition.ATTACK_TO_DEATH, "death");


        StateLeftBattle stateleftbattle = new StateLeftBattle(fms, points, transform, CurSpeed);//脱战状态
        stateleftbattle.addTransition(ETransition.LEFTBATTLE_TO_PATROL, "patrol");
        stateleftbattle.addTransition(ETransition.LEFTBATTLE_TO_DEATH, "death");


        StateDeath statedeath = new StateDeath(fms, points, transform);//死亡状态
        statedeath.addTransition(ETransition.DEATH_TO_PATROL, "patrol");
       

        fms.addState(statePatrol);
        fms.addState(stateFollow);
        fms.addState(stateAttack);
        fms.addState(stateleftbattle);
        fms.addState(statedeath);

    }
}
