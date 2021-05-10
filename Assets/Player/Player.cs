using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public enum SIDE  { Left,Mid,Right}

public class Player: MonoBehaviour
{


    private readonly Vector2 mXAxis = new Vector2(1, 0);
    private readonly Vector2 mYAxis = new Vector2(0, 1);

    private readonly string[] mMessage = {
        "",
        "Swipe Left",
        "Swipe Right",
        "Swipe Top",
        "Swipe Bottom"
    };

    private int mMessageIndex = 0;

    // The angle range for detecting swipe
    private const float mAngleRange = 20;

    // To recognize as swipe user should at lease swipe for this many pixels
    private const float mMinSwipeDist = 10.0f;

    // To recognize as a swipe the velocity of the swipe
    // should be at least mMinVelocity
    // Reduce or increase to control the swipe speed
    private const float mMinVelocity = 500.0f;

    private Vector2 mStartPosition;
    private float mSwipeStartTime;
 



        public AudioClip PlayerJump ; 

  public Rigidbody rb ;
  public SIDE m_Side = SIDE.Mid ; 
  float NewXPos = 0f ; 
  [HideInInspector]
  public bool SwipeLeft , SwipeRight , SwipeUp , SwipeDown ; 
  public float XValue ;
  private CharacterController m_char ;  
  private Animator m_Animator ; 
  private float x ; 
  public float SpeedDodge ; 
  public float JumpPower = 12f ; 
  private float y ; 
  public bool InJump ; 
  public bool InRoll ; 
  public float FwdSpeed = 7f; 
    void Start()
    {
    m_char = GetComponent<CharacterController>() ;
    m_Animator = GetComponent<Animator>() ; 
      transform.position = Vector3.zero ;   
    }

   
    void Update()
    {

        SwipeMobile(); 
       

        SwipeLeft = Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow) ; 
        SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) ;
        SwipeUp = Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow) ;     
      if (mMessageIndex==1)
        {
            mMessageIndex = 0;
            if (m_Side == SIDE.Mid) 
            {
                NewXPos = -XValue ;
                m_Side = SIDE.Left ;
                m_Animator.Play("Left") ; 
            } else if (m_Side == SIDE.Right) {
                NewXPos = 0 ; 
                 m_Side = SIDE.Mid ;  
                m_Animator.Play("Left") ; 


            }   
        }
        else if (mMessageIndex==2)
        {
            mMessageIndex = 0;
            if (m_Side == SIDE.Mid) 
            {
                NewXPos = XValue ;
                 m_Side = SIDE.Right ; 
                 m_Animator.Play("Right") ; 
  
            } else if (m_Side == SIDE.Left) {
                NewXPos = 0 ; 
                 m_Side = SIDE.Mid ; 
                 m_Animator.Play("Right") ; 

            }
        }
         Vector3 moveVector = new Vector3 (x-transform.position.x,y*Time.deltaTime,FwdSpeed*Time.deltaTime) ; 
         x = Mathf.Lerp (x,NewXPos,Time.deltaTime*SpeedDodge) ; 
         m_char.Move(moveVector) ; 
         Jump() ; 

    }

    public void Jump() 
    {
        if (m_char.isGrounded) { 
        
            if (mMessageIndex==3) {
                mMessageIndex = 0;
                 y = JumpPower ; 
                 m_Animator.CrossFadeInFixedTime("jump" , 0.1f) ; 
                        AudioSource.PlayClipAtPoint(PlayerJump , transform.position);

                 InJump = true ; 
            }
        } else 
        {
            y -=JumpPower * 2 * Time.deltaTime ; 
        }
    }

    public void SwipeMobile()
    {
        // Mouse button down, possible chance for a swipe
        if (Input.GetMouseButtonDown(0))
        {
            // Record start time and position
            mStartPosition = new Vector2(Input.mousePosition.x,
                                         Input.mousePosition.y);
            mSwipeStartTime = Time.time;
        }

        // Mouse button up, possible chance for a swipe
        if (Input.GetMouseButtonUp(0))
        {
            float deltaTime = Time.time - mSwipeStartTime;

            Vector2 endPosition = new Vector2(Input.mousePosition.x,
                                               Input.mousePosition.y);
            Vector2 swipeVector = endPosition - mStartPosition;

            float velocity = swipeVector.magnitude / deltaTime;

            if (velocity > mMinVelocity &&
                swipeVector.magnitude > mMinSwipeDist)
            {
                // if the swipe has enough velocity and enough distance

                swipeVector.Normalize();

                float angleOfSwipe = Vector2.Dot(swipeVector, mXAxis);
                angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;

                // Detect left and right swipe
                if (angleOfSwipe < mAngleRange)
                {
                    OnSwipeRight();
                }
                else if ((180.0f - angleOfSwipe) < mAngleRange)
                {
                    OnSwipeLeft();
                }
                else
                {
                    // Detect top and bottom swipe
                    angleOfSwipe = Vector2.Dot(swipeVector, mYAxis);
                    angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;
                    if (angleOfSwipe < mAngleRange)
                    {
                        OnSwipeTop();
                    }
                    else if ((180.0f - angleOfSwipe) < mAngleRange)
                    {
                        OnSwipeBottom();
                    }
                    else
                    {
                        mMessageIndex = 0;
                    }
                }
            }
        }
    }


    private void OnSwipeLeft()
    {
        mMessageIndex = 1;
        Debug.Log("left");
    }

    private void OnSwipeRight()
    {
        mMessageIndex = 2;
        Debug.Log("Right");
    }

    private void OnSwipeTop()
    {
        mMessageIndex = 3;
        Debug.Log("top");
    }

    private void OnSwipeBottom()
    {
        mMessageIndex = 4;
        Debug.Log("bottom");
    }

}
