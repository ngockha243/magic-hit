using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private Vector2 speed;
    private bool isActive = true;
    private Rigidbody2D rb;
    private BoxCollider2D knifeBoxCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && isActive)
        {
            rb.AddForce(speed, ForceMode2D.Impulse);
            rb.gravityScale = 1;

            GameUI.instance.DecrementDisplayedKnifeCount();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!isActive)
        {
            return;
        }
        isActive = false;
        if(other.collider.tag == "Board")
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(other.collider.transform);

            knifeBoxCollider.offset = new Vector2(knifeBoxCollider.offset.x, -0.4f);
            knifeBoxCollider.size = new Vector2(knifeBoxCollider.size.x, 1.2f);

            GameController.instance.OnSuccessfullKnifeHit();
        }
        else if(other.collider.tag == "Knife")
        {
            rb.velocity = new Vector2(rb.velocity.x, -2);
            GameController.instance.StartGameOverSequence(false);
        }
    }
}
