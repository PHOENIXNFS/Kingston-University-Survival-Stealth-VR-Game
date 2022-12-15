using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponManager : MonoBehaviour
{
    [HideInInspector] public bool bIsReadyToFire;
    public Transform WeaponTransform;
    public Player player;
    public Enemy enemy;
    [SerializeField] private float WeaponShootingForce;
    [SerializeField] private float FireRate;
    public Transform BulletSpawn;
    private WaitForSeconds WeaponWaitDuration;
    public GameObject BulletGameObject;
    public GameObject muzzleFlashPrefab;
    private float destroyTimer = 1f;
    public AudioClip RifleGunSound;
    public AudioSource GunSoundSource;



    private void Awake()
    {
        bIsReadyToFire = false;
    }

    private void Start()
    {
        WeaponWaitDuration = new WaitForSeconds(1 / FireRate);
    }

    public void Update()
    {
        IsEnemyReadyToFire();
        Fire();
        //Debug.Log("Is Ready To Fire: " + bIsReadyToFire);
    }

    public bool IsEnemyReadyToFire()
    {
        RaycastHit PlayerHit;
        if(bIsReadyToFire == false && Physics.Raycast(WeaponTransform.position, WeaponTransform.forward, out PlayerHit, 3.0f))
        {
            player = PlayerHit.collider.GetComponentInParent<Player>();
            if(player)
            {
                bIsReadyToFire = true;
                
            }
        }
        if(bIsReadyToFire == true && !Physics.Raycast(WeaponTransform.position, WeaponTransform.forward, out PlayerHit, 3.0f))
        {
            bIsReadyToFire = false;
        }

        return bIsReadyToFire;
    }

    public void Fire()
    {
        if(bIsReadyToFire == true && enemy.bIsPlayerInSight == true)
        {
            GunSoundSource.PlayOneShot(RifleGunSound);

            if (muzzleFlashPrefab)
            {
                //Create the muzzle flash
                GameObject tempFlash;
                tempFlash = Instantiate(muzzleFlashPrefab, BulletSpawn.position, BulletSpawn.rotation);

                //Destroy the muzzle flash effect
                Destroy(tempFlash, destroyTimer);
            }

            //cancels if there's no bullet prefeb
            if (!BulletGameObject)
            { return; }

            GameObject bullet = Instantiate(BulletGameObject, BulletSpawn.position, BulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * WeaponShootingForce * Time.deltaTime, ForceMode.Impulse);
            WeaponDelay();
        }

    }

    public IEnumerator WeaponDelay()
    {
        yield return WeaponWaitDuration;
    }

}
