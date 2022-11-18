using System;
using UnityEngine;

namespace ArcherWithSpine.Player
{
        public class PlayerMover : MonoBehaviour
        {
                [SerializeField] private Transform player;
                [SerializeField] private Rigidbody2D rigidbody;
        
                [SerializeField] private float movingSpeed;
                [SerializeField] private float jumpSpeed;
                [SerializeField] private float jumpPower;

                public Action Moved;
                public Action Jumped;
        
                public void RightMove()
                {
                        if (player.localScale.x < 0) 
                                ChangeDirection();

                        transform.position = new Vector3(transform.position.x + movingSpeed, transform.position.y, transform.position.z);
                
                        Moved?.Invoke();
                }
        
                public void LeftMove()
                {
                        if (player.localScale.x > 0) 
                                ChangeDirection();

                        transform.position = new Vector3(transform.position.x - movingSpeed, transform.position.y, transform.position.z);
                
                        Moved?.Invoke();
                }

                public void Jump()
                {
                        rigidbody.AddForce(new Vector2(0, jumpPower));
                
                        //Todo realization with DoTween
                        /*var targetPosition = new Vector3(player.position.x, player.position.y, player.position.z);
                player.DOJump(targetPosition, jumpPower, 1, jumpSpeed);*/
                
                        Jumped?.Invoke();
                }

                private void ChangeDirection() => 
                        player.localScale = new Vector3(player.localScale.x * -1, player.localScale.y, player.localScale.z);
        }
}