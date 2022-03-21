using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public int velocity;

    private Vector3 movement;
    private Animator cattoAnimator;

    void Start()
    {
        cattoAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        cattoAnimator.SetFloat("Horizontal", movement.x);
        cattoAnimator.SetFloat("Vertical", movement.y);
        cattoAnimator.SetFloat("Amount", movement.magnitude);

        transform.position = transform.position + movement * velocity * Time.deltaTime;
    }
}