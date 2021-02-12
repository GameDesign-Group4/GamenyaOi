using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	[SerializeField] private LayerMask platformslayerMask;
	private Rigidbody2D rigidbody2d;
	private BoxCollider2D boxCollider2d;
	private Animation anim;

	private void Start () {
		anim = gameObject.GetComponent<Animation>();
		rigidbody2d = transform.GetComponent<Rigidbody2D>();
		boxCollider2d = transform.GetComponent<BoxCollider2D>();
	}
	

	private void Update () {
		if (Input.GetKey(KeyCode.Space))
		{
			if (IsGrounded())
			{
				float jumpVelocity = 7f;
				rigidbody2d.velocity = Vector2.up * jumpVelocity;
			}
			anim.Play("Jump");
		}

		Movement();

		if (IsGrounded() && !anim.IsPlaying("Attack"))
		{
			if (rigidbody2d.velocity.x == 0)
			{
				anim.Play("Idle");
			}
		}
		else if (!anim.IsPlaying("Attack")) { anim.Play("Jump"); }
	}
	
	private bool IsGrounded()
    {
		RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformslayerMask);
		Debug.Log(raycastHit2d.collider);
		return raycastHit2d.collider != null;
    }

	private void Movement()
	{
		float movespeed = 5f;
		if (Input.GetKey(KeyCode.Mouse0))
		{
			anim.Play("Attack");
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			rigidbody2d.velocity = new Vector2(-movespeed, rigidbody2d.velocity.y); if (!anim.IsPlaying("Attack")){ anim.Play("Run"); }
			gameObject.transform.localScale = new Vector3(2, 2, 1);
		}	else {
			if (Input.GetKey(KeyCode.RightArrow)) 
			{
				rigidbody2d.velocity = new Vector2(+movespeed, rigidbody2d.velocity.y); if (!anim.IsPlaying("Attack")) { anim.Play("Run"); }
				gameObject.transform.localScale = new Vector3(-2, 2, 1);
			} else
			{
				//No key pressed
				rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
			}
		}
	}
}
