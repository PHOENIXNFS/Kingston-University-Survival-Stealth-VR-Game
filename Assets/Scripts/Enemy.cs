using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    //Animation Triggers Used to call Animator's Different States
    //const string WALKING_TRIGGER = "Walking";
    //const string IDLE_TRIGGER = "Idle";
    
    public float EnemyMaxHealth;
    [HideInInspector] public float EnemyCurrentHealth;
    [HideInInspector] public bool bIsPlayerInSight;
    private float EnemyHuntTime = 15.0f;
    private float HuntTimer;
    [SerializeField] private Animator EnemyAnimator;
    [SerializeField] public Player player;
    //public VRTeleportOnThreshold vrTeleportOnThreshold;
    public float EnemyMoveSpeed = 2.0f;
    public float EnemyRotationSpeed = 2.0f;
    public Vector3 PlayerLastLocation;
    public GameManager gameManager;
    //public Vector3 EnemyLastLocation;
    //public EnemyHealthBar enemyHealthBar;
    //[SerializeField] GameObject knife;
    [HideInInspector] public float EnemyHitDelay;
    [HideInInspector] public float EnemyHitDelayTimer;


    private void Awake()
    {
        EnemyAnimator = GetComponent<Animator>();
        EnemyAnimator.SetBool("bIsWalking", true);
        //EnemyAnimator.SetTrigger(IDLE_TRIGGER);
        EnemyCurrentHealth = EnemyMaxHealth;
        //enemyHealthBar.SetMaxHealth(EnemyMaxHealth);
        HuntTimer = 0.0f;
        bIsPlayerInSight = false;
        //player = FindObjectOfType<Player>();
        EnemyHitDelay = 1.0f;
        EnemyHitDelayTimer = Time.time;
    }

    
    //private void Start()
    //{
    //    InvokeRepeating("EnemyMovement", 0.0f, 0.05f);
    //}

    private void Update()
    {
        EnemyMovement();
        //EnemyHealthCheck();
        //Debug.Log("Is Player Sighted: " + bIsPlayerInSight);
        //Debug.Log("Player last location: " + PlayerLastLocation);
        //Debug.Log("Hunt Time: " + HuntTimer);
        IsEnemyDead();
    }
    public void EnemyMovement()
    {
        RaycastHit PlayerSearchHit;

        if(bIsPlayerInSight == false && Physics.Raycast(transform.position, transform.forward, out PlayerSearchHit, 3.0f))
        {
            EnemyAnimator.SetBool("bIsWalking", false);
            player = PlayerSearchHit.collider.GetComponentInParent<Player>();
            if(player)
            {
                bIsPlayerInSight = true;
                StartCoroutine(PlayerDetectionDelay());
                PlayerLastLocation = player.GetPlayerHeadPosition();

            }
            else
            {
                transform.Rotate(Vector3.up, 180);
            }
        } //working fine

        if(HuntTimer < EnemyHuntTime)
        {
            if (bIsPlayerInSight == true && Physics.Raycast(transform.position, transform.forward, out PlayerSearchHit, 3.0f))
            {
                player = PlayerSearchHit.collider.GetComponentInParent<Player>();
                if (player)
                {
                    StartCoroutine(PlayerDetectionDelay());
                    PlayerLastLocation = player.GetPlayerHeadPosition();
                    //EnemyLastLocation = transform.position;
                    HuntTimer = 0.0f;
                }

                else
                {
                    //transform.Rotate(Vector3.up, 180 * EnemyRotationSpeed * Time.smoothDeltaTime);
                    transform.Rotate(Vector3.up, 180);
                }
            }
        }

        if(!Physics.Raycast(transform.position, transform.forward, out PlayerSearchHit, 3.0f))
        {
            
            if (bIsPlayerInSight)
            {
                //FollowPlayer();
                //HuntTimer += Time.deltaTime;
                HuntTimer += Time.deltaTime;
                if(transform.position != PlayerLastLocation)
                {
                    EnemyAnimator.SetBool("bIsWalking", true);
                //transform.LookAt(PlayerLastLocation);
                    transform.position = Vector3.MoveTowards(transform.position, PlayerLastLocation, EnemyMoveSpeed * Time.smoothDeltaTime); 
                    EnemyAnimator.SetBool("bIsWalking", false);
                }

                if (HuntTimer < EnemyHuntTime)
                {
                    
                    //transform.Rotate(Vector3.up, 90 * EnemyRotationSpeed * Time.smoothDeltaTime);
            
                }

                 if (HuntTimer >= EnemyHuntTime)
                 {
                      bIsPlayerInSight = false;
                      HuntTimer = 0.0f;
                      EnemyAnimator.SetBool("bIsWalking", true);
                  }

            }

            else
            {
                EnemyAnimator.SetBool("bIsWalking", true);
                transform.Translate(Vector3.forward * EnemyMoveSpeed * Time.smoothDeltaTime); //working fine//
            }
            
        }

    }

    public IEnumerator PlayerDetectionDelay()
    {
        yield return new WaitForSeconds(2);
    }

    public void IsEnemyDead()
    {
        if(EnemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
            gameManager.Score += 100;
            gameManager.scoreText.text = gameManager.Score.ToString();
        }
    }

    public void EnemyHealthCheck()
    {
        Debug.Log("Enemy Health is: " + EnemyCurrentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponentInParent<MeleeKnifeManager>())
        {
            if(Time.time > EnemyHitDelayTimer + EnemyHitDelay)
            {
                EnemyCurrentHealth -= 50.0f;
                EnemyHitDelayTimer = Time.time;
            } 
        }
    }

}
