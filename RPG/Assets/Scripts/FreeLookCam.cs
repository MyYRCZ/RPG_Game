using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class FreeLookCam : SingletonMono<FreeLookCam> // : PivotBasedCameraRig
{
    public bool ismouseinui;
    // This script is designed to be placed on the root object of a camera rig,/�˽ű�ּ�ڷ����������װ���ĸ������ϣ�
    // comprising 3 gameobjects, each parented to the next:   //����3����Ϸ����ÿ����������һ����

    // 	Camera Rig
    // 		Pivot
    // 			Camera

    [SerializeField]
    protected Transform m_Target;
    [SerializeField]
    private float m_MoveSpeed = 1f;                      //����ƶ����ٶ��ж���Ը���Ŀ���λ�á�
    [Range(0f, 10f)]
    [SerializeField]
    private float m_TurnSpeed = 1.5f;   // ������û�������ת���ٶ��ж�졣
    [SerializeField]
    private float m_TurnSmoothing = 0.0f;                // Ӧ����ת�������ƽ���̶ȣ��Լ������ת��ļ���
    [SerializeField]
    private float m_TiltMax = 75f;                       // aixs��x����ת�����ֵ��.
    [SerializeField]
    private float m_TiltMin = 45f;                       // aixs��x����ת����Сֵ��.
    [SerializeField]
    private bool m_LockCursor = false;                   //��ʾ�����ع��
    [SerializeField]
    private bool m_VerticalAutoReturn = false;           //�����Ƿ�ֱ��Ӧ�Զ�����
    [SerializeField]
    private Transform m_player;

    private Vector3 playertocamdir;
   
    private float distance = 10f ;
    private float changeddistace;
    private bool rayhited = false;
    private float m_LookAngle;                    // The rig's y axis rotation.
    private float m_TiltAngle;                    // The pivot's x axis rotation.
    private const float k_LookDistance = 100f;    // How far in front of the pivot the character's look target is.
    private Vector3 m_PivotEulers;
    private Quaternion m_PivotTargetRot;
    private Quaternion m_TransformTargetRot;


    protected Transform m_Cam; // the transform of the camera
    protected Transform m_Pivot; // the point at which the camera pivots around
    protected Vector3 m_LastTargetPosition;
    override protected void Awake()
    {
        base.Awake();
        m_Cam = GetComponentInChildren<Camera>().transform;
        m_Pivot = m_Cam.parent;
       // m_Cam.LookAt(m_Pivot);
        //base.Awake();
        // Lock or unlock the cursor.
        Cursor.lockState = m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None;  //���������Ƿ�
        Cursor.visible = !m_LockCursor;   //��������ʾ���
        m_PivotEulers = m_Pivot.rotation.eulerAngles;

        m_PivotTargetRot = m_Pivot.transform.localRotation;
        m_TransformTargetRot = transform.localRotation;

        
       // getdir();
        setdistance(distance);
    }


    protected void Update()
    {

       
         getdir();
        
      
        mrayhit();
       

   
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            Cursor.visible = true;
        }
        FollowTarget(Time.deltaTime);
        if (m_LockCursor && Input.GetMouseButtonUp(0))
        {
            Cursor.lockState = m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !m_LockCursor;
        }

        //gamecam.transform.position = transform.position + new Vector3(0, camPosition.x, -camPosition.y);
        if (Input.GetAxis("Mouse ScrollWheel") < 0&& !rayhited&&!ismouseinui)
        {
            distance += 0.5f;
            if (distance >= 15f)
            {
                distance = 15f;
            }
           
            setdistance(distance);
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && !rayhited && !ismouseinui)
        {
            distance -= 0.5f;
            if(distance<=1.5f)
            {
                distance = 1.5f;
            }

         
            setdistance(distance);
        }

     
        if (Input.GetMouseButton(0)&&!EventSystem.current.IsPointerOverGameObject()&&!ismouseinui)
        {
            HandleRotationMovement();
        }
        if (Input.GetMouseButton(1) && !EventSystem.current.IsPointerOverGameObject()&& !ismouseinui&&!playerattribute.Instance.isdead)
        {
            HandleRotationMovement();
        }
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && !ismouseinui)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//�������������㷢��������
            RaycastHit hit;//��¼��ײ��Ϣ

            bool isCollider = Physics.Raycast(ray, out hit);//�ж��Ƿ�����ײ
            if(isCollider)
            {
                print(hit.collider);
                if (hit.collider.tag == "Player" )
                playerattribute.Instance.Target = hit.collider.transform;
                if(hit.collider.tag == "Monster")
                {
                    playerattribute.Instance.Target = hit.collider.transform.parent.transform;
                }
                if(hit.collider.tag == "NPC")
                {
                    playerattribute.Instance.Target = hit.collider.transform;
                }
            }
        }
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject() && !ismouseinui)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//�������������㷢��������
            RaycastHit hit;//��¼��ײ��Ϣ

            bool isCollider = Physics.Raycast(ray, out hit);//�ж��Ƿ�����ײ
            if (isCollider)
            {
              //  print(hit.collider.GetComponent<enemyattribute>().monstername);
         
                if (hit.collider.tag == "Monster")
                {
                    if (hit.collider.GetComponent<enemyattribute>().isdead == true && Vector3.Distance(playerattribute.Instance.transform.position, hit.collider.transform.position) <= 5 && hit.collider.GetComponent<enemyattribute>().isdrag == false)
                    {
                        print(hit.collider.GetComponent<enemyattribute>().monstername);

                       if(hit.collider.GetComponent<enemyattribute>().level ==3&&playerattribute.Instance.quest1==1)
                        {
                            print(2);
                            getgood.Instance.showgetgood(Input.mousePosition);
                        }
                        hit.collider.GetComponent<enemyattribute>().isdrag = true;
                    }               
                }
                if (hit.collider.tag == "NPC")
                {
                    if (hit.collider.name=="NPC1"&&playerattribute.Instance.quest1==0 && Vector3.Distance(playerattribute.Instance.transform.position, hit.collider.transform.position) <= 5)
                    {
                        //��������һ��ȡ�Ŀ�
                        questjiaohu.Instance.openwindow(1);
                    }
                    else if(hit.collider.name == "NPC1" && playerattribute.Instance.quest1 ==1 && Vector3.Distance(playerattribute.Instance.transform.position, hit.collider.transform.position) <= 5)
                    {
                        questjiaohu.Instance.openwindow(1);
                        //��������һ��ɿ�
                    }
                     else if (hit.collider.name == "NPC2" && playerattribute.Instance.quest2 == 0 && Vector3.Distance(playerattribute.Instance.transform.position, hit.collider.transform.position) <= 5)
                    {
                        questjiaohu.Instance.openwindow(2);
                        //��������һ��ȡ�Ŀ�
                    }
                    else if (hit.collider.name == "NPC2" && playerattribute.Instance.quest2 == 1 && Vector3.Distance(playerattribute.Instance.transform.position, hit.collider.transform.position) <= 5)
                    {
                        questjiaohu.Instance.openwindow(2);
                        //��������һ��ȡ�Ŀ�
                    }
                }
            }
        }
    }


    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    protected void FollowTarget(float deltaTime)
    {
        if (m_Target == null) return;
        // Move the rig towards target position.
        transform.position = m_Target.position;
    }


    private void HandleRotationMovement()
    {
        if (Time.timeScale < float.Epsilon)
            return;                     //������
        Cursor.visible = false;
        // Read the user input
        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");

        // Adjust the look angle by an amount proportional to the turn speed and horizontal input.
        m_LookAngle += x * m_TurnSpeed;

        // Rotate the rig (the root object) around Y axis only:
        m_TransformTargetRot = Quaternion.Euler(0f, m_LookAngle, 0f);

        if (m_VerticalAutoReturn)
        {
            m_TiltAngle = y > 0 ? Mathf.Lerp(0, -m_TiltMin, y) : Mathf.Lerp(0, m_TiltMax, -y);
        }
        else
        {
            // on platforms with a mouse, we adjust the current angle based on Y mouse input and turn speed
            m_TiltAngle -= y * m_TurnSpeed;
            // and make sure the new value is within the tilt range
            m_TiltAngle = Mathf.Clamp(m_TiltAngle, -m_TiltMin, m_TiltMax);
        }

        // Tilt input around X is applied to the pivot (the child of this object)
        m_PivotTargetRot = Quaternion.Euler(m_TiltAngle, m_PivotEulers.y, m_PivotEulers.z);

        if (m_TurnSmoothing > 0)
        {
            m_Pivot.localRotation = Quaternion.Slerp(m_Pivot.localRotation, m_PivotTargetRot, m_TurnSmoothing * Time.deltaTime);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, m_TransformTargetRot, m_TurnSmoothing * Time.deltaTime);
        }
        else
        {
            m_Pivot.localRotation = m_PivotTargetRot;
            transform.localRotation = m_TransformTargetRot;
        }
    }

    private void getdir()
    {
        playertocamdir = (m_Cam.transform.position - m_player.transform.position).normalized;
    }
    private void setdistance(float dis)
    {
        m_Cam.transform.position = m_Target.position + m_Pivot.rotation* Vector3.back * dis;
    }
    private void mrayhit()
    {

        RaycastHit hitInfo;
        Physics.Raycast(m_Target.position + Vector3.up, playertocamdir, out hitInfo, distance);
       // print(hitInfo.collider);
        if (hitInfo.collider !=null)
        {
            //  print(hitInfo.distance);
           
           
                changeddistace = hitInfo.distance - 0.1f;

            

            rayhited = true;
            setdistance(changeddistace);
        }
        else
        {
          //  print(1);
            if (rayhited)
            {

                changeddistace += 0.1f;
                setdistance(changeddistace);
                if (changeddistace >= distance)
                {
                    setdistance(distance);
                    print("1");
                    rayhited = false;
                   
                }
            }
        }
    }
}
