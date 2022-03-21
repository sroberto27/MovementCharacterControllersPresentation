using System.Collections;
using UnityEngine;

public class MissileLogic : MonoBehaviour
{
    public Transform tankFirePoint;
    public GameObject missilePrefab;

    public float bulletSpeed;

    public float coolDown = 2f;
    private bool canFire = true;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (canFire)
        {
            Fire();
            canFire = false;
            StartCoroutine(CoolDown());
        }
    }

    private void Fire()
    {
        var instanceBullet = Instantiate(missilePrefab, tankFirePoint.position, tankFirePoint.rotation, tankFirePoint);
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDown);
        canFire = true;
    }
}
