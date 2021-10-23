using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wolf : MonoBehaviour
{
    private Rigidbody2D rBody;
    [SerializeField]
    private float jumpStrength;
    [SerializeField]
    private KeyCode jumpKey;
    private bool enableJump = false;
    private bool endJump = true;
    [SerializeField]
    private float jumpDuration;

    private void Awake()
    {
        this.rBody = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(this.jumpKey) && this.endJump)
        {
            this.enableJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (this.enableJump)
        {
            this.Jump();
        }
    }

    public void Jump()
    {
        this.rBody.AddForce(Vector2.up * this.jumpStrength, ForceMode2D.Impulse);
        this.enableJump = false;
        this.endJump = false;
        StartCoroutine(ActiveJump());
    }

    private IEnumerator ActiveJump()
    {
        yield return new WaitForSeconds(jumpDuration);
        this.enableJump = false;
        this.endJump = true;
    }
}
