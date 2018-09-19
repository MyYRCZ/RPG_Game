using UnityEngine;
using System.Collections;

public class WalkingOrc : SingletonMono<WalkingOrc>
{

    public Animator animator;//动作

    public float walkspeed = 5;//移动速度
    public float rota = 60;//旋转速度
    private float horizontal;//数轴
    private float vertical;//横轴

    private float m_hor;
    private float m_ver;


    //private float rotationDegreePerSecond = 1000;
    private bool isAttacking = false;//是否在攻击 
    private Vector3 stickDirection;
    private Vector3 oldforward;
    private Quaternion oldrotation;
    private Vector3 playerdir;
    float movespeedratio = 1f;  //移动系数
    private float camdistance = 10f;
    private bool ismvove = false;
    //enum MOVEFORWARD
    //{
    //    UP,
    //    LEFT,
    //    RIGHT,
    //    BACK,
    //    UPLEFT,
    //    UPRIGHT,
    //    BACKLEFT,
    //    BACKRIGHT,

    //}
    //private MOVEFORWARD m_moveforward;
    private Vector3 playerlook;
    private Vector3 playerback;
    private bool ondoublemoved = false;
    private bool onrightmoved = false;

    public GameObject gamecam;
    public Vector2 camPosition;
    Vector3 campldir;


    private bool dead;
    private bool isgetdownmouselefted = false;// 按下鼠标左键后重置摄像机位置的判断值

    public GameObject[] characters;
    public int currentChar = 0;



    Vector3 ACodeDir;
    Vector3 DCodeDir;

    float returnangle = 0;  //摄像机回归角度
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
       

        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()//移动 
    {
        
        if (animator && !playerattribute.Instance.isdead)
        {
            float speedOut;
            //  walk
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            if(horizontal>0)
            {
                m_hor = 1;
            }
            if (horizontal <0)
            {
                m_hor = -1;
            }
            if (horizontal == 0)
            {
                m_hor = 0;
            }
            if (vertical > 0)
            {
                m_ver = 1;
            }
            if (vertical < 0)
            {
                m_ver = -1;
            }
            if (vertical == 0)
            {
                m_ver = 0;  
            }


            //  print(horizontal);    
            ///写个状态机
            ///
            playerdir = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);
            if (m_hor != 0 || m_ver != 0)
            {
                if (!ismvove)
                {
                    transform.forward = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);

                    oldrotation = transform.rotation;
                    oldforward = transform.forward;

                    movespeedratio = 1f;
                    ismvove = true;
                }
                if (ondoublemoved == true)
                {

                }

                else
                {

                    if (m_ver > 0 && m_hor == 0)//直走
                    {
                        if (Input.GetMouseButton(1))
                        {
                            oldforward = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);
                        }
                        transform.forward = oldforward;
                        movespeedratio = 1f;
                    }

                    if (m_ver == 0 && m_hor < 0)//左走
                    {
                        if (Input.GetMouseButton(1))
                        {
                            transform.forward = new Vector3(-gamecam.transform.right.x,  0, -gamecam.transform.right.z);
                        }

                        else
                        {
                            transform.forward = oldforward + Vector3.Lerp(transform.forward, -transform.right, 0.99f);
                        }


                        movespeedratio = 1f;
                    }

                    if (m_ver == 0 && m_hor > 0)//右走
                    {
                        if (Input.GetMouseButton(1))
                        {
                            transform.forward = new Vector3(gamecam.transform.right.x, 0, gamecam.transform.right.z);
                        }
                        else
                        {
                            transform.forward = oldforward + Vector3.Lerp(transform.forward, transform.right, 0.99f);
                        }
                      
                        movespeedratio = 1f;
                    }
                    if (m_ver > 0 && m_hor > 0)//右前
                    {
                        if (Input.GetMouseButton(1))
                        {
                            transform.forward = Vector3.Lerp(new Vector3(gamecam.transform.forward.x, 0, gamecam.transform.forward.z), new Vector3(gamecam.transform.right.x, 0, gamecam.transform.right.z),0.5f);
                        }
                        else
                        { transform.forward = oldforward + Vector3.Lerp(transform.forward, transform.right, 0.5f); }
                      
                        movespeedratio = 1f;
                    }
                    if (m_ver > 0 && m_hor < 0)//左前
                    {
                        if (Input.GetMouseButton(1))
                        {
                            transform.forward = Vector3.Lerp(new Vector3(gamecam.transform.forward.x, 0, gamecam.transform.forward.z), new Vector3(-gamecam.transform.right.x, 0,- gamecam.transform.right.z), 0.5f);
                        }
                        else
                        {
                            transform.forward = oldforward + Vector3.Lerp(transform.forward, -transform.right, 0.5f);
                        }
                      
                        movespeedratio = 1f;
                    }
                    if (m_ver < 0 && m_hor < 0)//左后 实际面朝方向为右前
                    {
                        if (Input.GetMouseButton(1))
                        {
                            transform.forward = Vector3.Lerp(new Vector3(gamecam.transform.forward.x, 0, gamecam.transform.forward.z), new Vector3(gamecam.transform.right.x, 0, gamecam.transform.right.z), 0.5f);
                        }
                        else
                        {
                            transform.forward = oldforward + Vector3.Lerp(transform.forward, transform.right, 0.5f);   
                        }
                      

                        movespeedratio = -0.4f;
                    }
                    if (m_ver < 0 && m_hor > 0)//右后 实际面朝方向为左前
                    {
                        if (Input.GetMouseButton(1))
                        {
                            transform.forward = Vector3.Lerp(new Vector3(gamecam.transform.forward.x, 0, gamecam.transform.forward.z), new Vector3(-gamecam.transform.right.x, 0, -gamecam.transform.right.z), 0.5f);
                        }
                        else
                        {
                            transform.forward = oldforward + Vector3.Lerp(transform.forward, -transform.right, 0.5f);
                        }
                     
                        movespeedratio = -0.4f;
                    }

                    if (m_ver < 0 && m_hor == 0)//倒退
                    {
                        if (Input.GetMouseButton(1))
                        {
                            oldforward = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);
                        }
                        transform.forward = oldforward;
                        movespeedratio = -0.4f;
                    }
                }
            }
            if (m_hor == 0 && m_ver == 0 && ismvove == true && !(Input.GetMouseButton(0) && Input.GetMouseButton(1)))
            {
                if (ondoublemoved == true)
                {
                    transform.forward = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);
                    ondoublemoved = false;
                }
                if (onrightmoved ==true)
                {
                    transform.forward = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);
                    onrightmoved = false;
                }
                else
                {
                    
                    transform.forward = oldforward;
                }

                ismvove = false;
            }

            // stickDirection = new Vector3(horizontal, 0, vertical);
            //float speedOut;
            stickDirection = transform.forward;
            if (stickDirection.sqrMagnitude > 1) stickDirection.Normalize();

            if (!isAttacking && ismvove)
                speedOut = 1;
            else
                speedOut = 0;

            if (stickDirection != Vector3.zero && !isAttacking)
                // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(stickDirection, Vector3.up), 1000 * Time.deltaTime);


                GetComponent<Rigidbody>().velocity = stickDirection * speedOut * movespeedratio * walkspeed + new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);
            // GetComponent<Rigidbody>().velocity = stickDirection * movespeedratio * speedOut * walkspeed;
            animator.SetFloat("Speed", speedOut);

            if (Input.GetKeyDown(KeyCode.W))
            {
                //  returnangle = Vector3.Angle(playerback, campldir);


                //按下w时如果摄像机位置不正 将摄像机与角色方向一致
                if (isgetdownmouselefted)
                {
                    Vector3 nowcamposition = gamecam.transform.position;
                    //transform.forward = new Vector3(-gamecam.transform.localPosition.x, 0, -gamecam.transform.localPosition.z);
                    transform.forward = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);
                    //GameObject camtemp = new GameObject("camtemp");
                    //camtemp.transform.position = nowcamposition;
                    //camtemp.transform.SetParent(this.transform);
                    gamecam.transform.position = nowcamposition;
                    //gamecam.transform.localPosition = camtemp.transform.localPosition;
                    // Destroy(camtemp);
                    isgetdownmouselefted = false;
                }
            }

            //if (Input.GetKeyDown(KeyCode.S))
            //{
            //    walkspeed = 2.5f;
            //    transform.forward = -transform.forward;
            //}
            //if (Input.GetKeyUp(KeyCode.S))
            //{
            //    walkspeed = 5;
            //    transform.forward = -transform.forward;
            //}

            //     print(gamecam.transform.forward.x+","+gamecam.transform.forward.y+","+ gamecam.transform.forward.z);
            // }
            //   if (Input.GetKey(KeyCode.W)&&!isAttacking)
            // {
            //    // GetComponent<Rigidbody>().velocity = transform.forward * speedOut * walkspeed + new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);
            //    transform.Translate(new Vector3(0, 0, walkspeed * Time.fixedDeltaTime));
            //      speedOut = 1;
            //     animator.SetFloat("Speed", speedOut);
            //     //resetcampos = -transform.forward * Mathf.Sin(returnangle)- gamecam.transform.position;

            // }
            //else  if (Input.GetKey(KeyCode.S) && !isAttacking)
            // {
            //     transform.Translate(new Vector3(0, 0, -0.5f*walkspeed * Time.fixedDeltaTime));
            //     speedOut = 1.0f;
            //     animator.SetFloat("Speed",speedOut);
            // }
            // else
            // {
            //     speedOut = 0;
            //     animator.SetFloat("Speed", speedOut);
            // }

            //   //按下a键时
            // if (Input.GetKeyDown(KeyCode.A))
            // {
            //     transform.forward = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);   
            //     ACodeDir = transform.forward;
            //     if(Input.GetKey(KeyCode.W))
            //     {
            //         transform.forward = Vector3.Lerp(transform.forward, -transform.right, 0.5f);
            //     }
            //     else
            //     transform.forward = -transform.right;
            // }
            //     if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            //     {


            //         transform.Translate(new Vector3(0, 0, walkspeed * Time.fixedDeltaTime));
            //         speedOut = 1;
            //         animator.SetFloat("Speed", speedOut);


            // }
            // if(Input.GetKeyUp(KeyCode.A))
            // {
            //     transform.forward = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);
            // }
            // if (Input.GetKeyDown(KeyCode.D))
            // {
            //     transform.forward = transform.right;
            // }
            // if (Input.GetKey(KeyCode.D))
            // {

            //     if (Input.GetKey(KeyCode.W))
            //     {
            //         transform.forward = transform.forward + new Vector3(1, 0, 1);
            //     }
            //     else
            //     {
            //         transform.forward = transform.forward + new Vector3(1, 0, 0);
            //         transform.Translate(new Vector3(0, 0, walkspeed * Time.fixedDeltaTime));
            //         speedOut = 1;
            //         animator.SetFloat("Speed", speedOut);
            //     }


            // }
            // if (Input.GetKeyUp(KeyCode.D))
            // {
            //     transform.forward = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);
            // }
            // if (Input.GetKeyUp(KeyCode.A))
            // {
            //     transform.forward = ACodeDir;
            // }



        }
    }

    void Update()
    {
        setCharacter();
        //print(Mathf.Sqrt((transform.position.x - gamecam.transform.position.x) * (transform.position.x - gamecam.transform.position.x)
        //                    + (transform.position.y - gamecam.transform.position.y) * (transform.position.y - gamecam.transform.position.y)
        //                    + (transform.position.z - gamecam.transform.position.z) * (transform.position.z - gamecam.transform.position.z)));




        //  print(horizontal);

        playerlook = transform.forward.normalized;
        playerback = -transform.forward.normalized;
        campldir = (gamecam.transform.position - transform.position).normalized;
        // Vector3 campldirY = new Vector3(0, campldir.y, campldir.z).normalized;
        Vector3 mospos = new Vector3(0, 0, 0);
        camPosition = gamecam.transform.position    ;


        // print(returnangle);


        float angle = Vector3.Angle(playerlook, campldir);
        //print(angle);
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");



        if (!dead)
        {
            // move camera鼠标滚轮控制摄像机远近
            if (gamecam)
            {
            

            }
            //鼠标右键控制视角
            //if (Input.GetMouseButtonDown(1))
            //{
            //    //if (isgetdownmouselefted)
            //    //{ 

            //    //    transform.forward= transform.position- gamecam.transform.position;
            //    //   // transform.up = new Vector3(transform.position.x, transform.position.y, 0);
            //    //}       
            //    //Vector3 nowcamposition = gamecam.transform.position;
            //    //transform.forward = new Vector3(-gamecam.transform.localPosition.x, 0, -gamecam.transform.localPosition.z);
            //    transform.forward = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);
            //    //GameObject camtemp = new GameObject("camtemp");
            //    //camtemp.transform.position = nowcamposition;
            //    //camtemp.transform.SetParent(this.transform);
            //    // gamecam.transform.position = nowcamposition;
            //    //gamecam.transform.localPosition = camtemp.transform.localPosition;
            //    // Destroy(camtemp);
            //    isgetdownmouselefted = false;

            //}
            if (Input.GetMouseButton(1))
            {


                //oldforward = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);



                //  transform.forward = 
                if (ismvove)
                {

                    if (Input.GetMouseButton(0))
                    {
                        transform.forward = oldforward=new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z); ;
                    }
                    else
                    {
                        onrightmoved = true;
                       // transform.forward = new Vector3(-gamecam.transform.right.x,0, gamecam.transform.right.z);

                    }
                }
                if (!ismvove)
                {
                    transform.forward = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);
                }



                //else
                //{
                //    //oldforward  = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);

                //}

                //stickDirection = transform.forward;
                // 
                //if (angle <= 90)
                //{
                //    y = -y;
                //    if (gamecam.transform.position.y <= 0.5f && y < 0)
                //    {
                //        y = 0;
                //    }
                //}
                //else if (gamecam.transform.position.y <= 0.5f && y > 0)//将摄像机的y坐标限制在0.5之上
                //{
                //    y = 0;

                //}
                //gamecam.transform.RotateAround(transform.position, transform.up, x * 100 * Time.deltaTime);
                //gamecam.transform.RotateAround(transform.position, transform.right, -50 * y * Time.deltaTime);
                //transform.Rotate(transform.up,100*x*Time.deltaTime);
            }

            if (Input.GetMouseButtonUp(1))
            {

            }
            //鼠标左键控制摄像机
            if (Input.GetMouseButtonDown(0))
            {
                isgetdownmouselefted = true;
            }
            //if (Input.GetMouseButton(0)&&!Input.GetMouseButton(1))
            //{
            //    // print(y);
            //    //if((transform.position-gamecam.transform.position).normalized.z<0)//当摄像机在玩家的正方向时mousey反向
            //    //{
            //    //    y = -y;
            //    //    print(y);
            //    //    if(gamecam.transform.position.y <= 0.5&&y>0)
            //    //    {
            //    //        y = 0;
            //    //    }
            //    //}
            //    // if(campldir)
            //    //print("按下了左键");
            //    isgetdownmouselefted = true;
            //    if (angle<=90)
            //    {
            //        y = -y;
            //        if (gamecam.transform.position.y <= transform.position.y+ 0.5f && y < 0)
            //        {
            //            y = 0;

            //        }
            //    }
            //   else  if(gamecam.transform.position.y <= transform.position.y + 0.5f &&y>0)//将摄像机的y坐标限制在0.5之上
            //    {
            //        y = 0;

            //    }
            //    gamecam.transform.RotateAround(transform.position,transform.up, x * 100 * Time.deltaTime);
            //    gamecam.transform.RotateAround(transform.position,transform.right  ,-50* y * Time.deltaTime);



            //}
            if (Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
            {

            }
            //鼠标左右键同时按下移动
            if ((Input.GetMouseButtonDown(0) && Input.GetMouseButton(1)) || (Input.GetMouseButton(0) && Input.GetMouseButtonDown(1)) && isgetdownmouselefted)
            {
                //Vector3 nowcamposition = gamecam.transform.position;
                //transform.forward = new Vector3(-gamecam.transform.localPosition.x, 0, -gamecam.transform.localPosition.z);
                transform.forward = new Vector3(transform.position.x - gamecam.transform.position.x, 0, transform.position.z - gamecam.transform.position.z);
                //GameObject camtemp = new GameObject("camtemp");
                //camtemp.transform.position = nowcamposition;
                //camtemp.transform.SetParent(this.transform);
                //gamecam.transform.position = nowcamposition;
                //gamecam.transform.localPosition = camtemp.transform.localPosition;
                // Destroy(camtemp);
                ondoublemoved = true;
                movespeedratio = 1.0f;
                isgetdownmouselefted = false;

            }
            if (Input.GetMouseButton(0) && Input.GetMouseButton(1) && !Input.GetKey(KeyCode.W) && !isgetdownmouselefted)
            {

                ismvove = true;
                animator.SetFloat("Speed", 1);
            }
            if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && horizontal == 0 && vertical == 0)
            {
                ismvove = false;
                animator.SetFloat("Speed", 0);
            }

            // attack

            //if (Input.GetButtonDown("Jump") && !isAttacking)
            //{
            //    isAttacking = true;
            //    //animator.Play("Attack");
            //    animator.SetTrigger("Attack");
            //    StartCoroutine(stopAttack(1));
            //    activateTrails(true);
            //}

            animator.SetBool("isAttacking", isAttacking);

            //switch character

            //if (Input.GetKeyDown("left"))
            //{
            //    setCharacter(-1);
            //    isAttacking = true;
            //    StartCoroutine(stopAttack(1f));
            //}

            //if (Input.GetKeyDown("right"))
            //{
            //    setCharacter(1);
            //    isAttacking = true;
            //    StartCoroutine(stopAttack(1f));
            //}

            //// death
            //if (Input.GetKeyDown("m"))
            //    StartCoroutine(selfdestruct());
        }

    }

    public IEnumerator stopAttack(float lenght)
    {
        yield return new WaitForSeconds(lenght); // attack lenght
        isAttacking = false;
        activateTrails(false);
    }

    public IEnumerator selfdestruct()
    {
        animator.SetTrigger("isDead");
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        dead = true;

        yield return new WaitForSeconds(1.3f);
        GameObject.FindWithTag("GameController").GetComponent<gameContoller>().resetLevel();
    }

    public void setCharacter()//改变角色
    {

    if(playerattribute.Instance.zhongzu)
        {
            if(Equipattribute.Instance.weaponid==0|| goods.Instance.Getgood(Equipattribute.Instance.weaponid).weapontype==1)
            {
                currentChar = 0;
            }
            if (goods.Instance.Getgood(Equipattribute.Instance.weaponid).weapontype == 2)
            {
                currentChar = 1;
            }
            if (goods.Instance.Getgood(Equipattribute.Instance.weaponid).weapontype == 3)
            {
                currentChar = 2;
            }
        }
    else
        {
            if (Equipattribute.Instance.weaponid == 0 || goods.Instance.Getgood(Equipattribute.Instance.weaponid).weapontype == 1)
            {
                currentChar = 4;
            }
            if (goods.Instance.Getgood(Equipattribute.Instance.weaponid).weapontype == 2)
            {
                currentChar = 5;
            }
            if (goods.Instance.Getgood(Equipattribute.Instance.weaponid).weapontype == 3)
            {
                currentChar = 6;
            }
        }

        foreach (GameObject child in characters)
        {
            if (child == characters[currentChar])
                child.SetActive(true);
            else
            {
                child.SetActive(false);

                if (child.GetComponent<triggerProjectile>())
                    child.GetComponent<triggerProjectile>().clearProjectiles();
            }
        }

        animator = GetComponentInChildren<Animator>();
    }

    public void activateTrails(bool state)
    {
        var tails = GetComponentsInChildren<TrailRenderer>();
        foreach (TrailRenderer tt in tails)
        {
            tt.enabled = state;
        }
    }
    //private void RotateView(float x, float y)
    //{
    //    x *= 10;
    //    y *= 10;

    //    //大于330     小于60
    //    if (this.transform.eulerAngles.x - y > 60 || this.transform.eulerAngles.x - y < 330)
    //    {
    //        gamecam. transform.RotateAround(this.transform, x, 0, Space.World);
    //        gamecam. transform.Rotate(-y, 0, 0);
    //    }
    //}
    //public void RotateAround(Vector3 point, Vector3 axis, float angel);


    public void resetcamera()
    {
        //所需要对x轴旋转的角度为   Vector3.Angle(playerlook, campldir);对应每一帧需要旋转的角度即为Vector3.Angle(playerlook, campldir)/120
        /// 一秒60帧   在2秒内 将摄像机恢复  
        // gamecam.transform.RotateAround(transform.position, transform.up, (Vector3.Angle(playerlook, campldir) )/ 120);
        // gamecam.transform.RotateAround(transform.position, transform.right, 15 * Time.deltaTime);
    }
}
