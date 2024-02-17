using UnityEngine;

[System.Serializable]
public class Guns
{
    public GameObject rightGun, leftGun, centralGun;
    public ParticleSystem leftGunVFX, rightGunVFX, centralGunVFX;
}

public class PlayerShooting : MonoBehaviour
{
    public float fireRate;
    public GameObject projectileObject;
    public float nextFire;
    [Range(1, 4)] public int weaponPower = 1;
    public Guns guns;
    public int maxweaponPower = 4;
    public static PlayerShooting instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        guns.leftGunVFX = guns.leftGun.GetComponent<ParticleSystem>();
        guns.rightGunVFX = guns.rightGun.GetComponent<ParticleSystem>();
        guns.centralGunVFX = guns.centralGun.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Time.time > nextFire)
        {
            Shot();
            nextFire = Time.time + 1 / fireRate;
        }
    }

    void Shot()
    {
        switch (weaponPower)
        {
            case 1:
                CreateShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                guns.centralGunVFX.Play();
                break;
            case 2:
                CreateShot(projectileObject, guns.rightGun.transform.position, Vector3.zero);
                guns.leftGunVFX.Play();
                CreateShot(projectileObject, guns.leftGun.transform.position, Vector3.zero);
                guns.rightGunVFX.Play();
                break;
            case 3:
                CreateShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                CreateShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                guns.leftGunVFX.Play();
                CreateShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                guns.rightGunVFX.Play();
                break;
            case 4:
                CreateShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                CreateShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                guns.leftGunVFX.Play();
                CreateShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                guns.rightGunVFX.Play();
                CreateShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 15));
                CreateShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -15));
                break;
        }
    }

    void CreateShot(GameObject shot, Vector3 position, Vector3 rotation)
    {
        Instantiate(shot, position, Quaternion.Euler(rotation));
    }
}


