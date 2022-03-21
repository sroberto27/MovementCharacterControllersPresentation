using UnityEngine;

public class Missile : MonoBehaviour
{
    public float bulletSpeed = 100f;
    public GameObject explosionPrefab;
    public float blastRadius = 5f;

    private Rigidbody rbInstanceBullet;

    void Start()
    {
        rbInstanceBullet = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        rbInstanceBullet.velocity = rbInstanceBullet.transform.forward * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        Vector3 contactPosition = contact.point;

        var explosionInstance = Instantiate(explosionPrefab, contactPosition, Quaternion.identity);

        ParticleSystem particlesOfExplosion = explosionInstance.GetComponent<ParticleSystem>();
        particlesOfExplosion.Play();

        if (collision.gameObject.CompareTag("RattoTank"))
        {
            Rigidbody ratto = collision.gameObject.GetComponent<Rigidbody>();
            ratto.AddExplosionForce(1000, transform.position, blastRadius);
        }

        Physics.OverlapSphere(transform.position, blastRadius);

        Destroy(gameObject, particlesOfExplosion.main.duration);
        Destroy(explosionInstance, particlesOfExplosion.main.duration);
    }
}
