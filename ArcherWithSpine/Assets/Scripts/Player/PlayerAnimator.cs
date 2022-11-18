using System;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
        private const string JumpStartAnimation = "Jump_Start";
        private const string IdleAnimation = "Idle_01";
        private const string RunAnimation = "Running";
        private const string JumpAnimation = "Jump_Loop";
        private const string StuffAnimation = "Attack_Stuff";
        private const string SwordAnimation = "Attack_Sword";
        private const string BowAnimation = "Attack_Bow";
        
        [SerializeField] private SkeletonAnimation animator;
        [SerializeField] private PlayerMover mover;
        [SerializeField] private Renderer characterRenderer;

        private void Awake()
        {
                animator.AnimationState.Complete += entry => PlayIdle();
                
                mover.Moved += PlayRunMove;
                mover.Jumped += PlayJump;
                
                PlayStartMove();
        }

        public void PlayAttackStuff() => 
                PlayAnimation(StuffAnimation, false);
        
        public void PlayAttackSword() => 
                PlayAnimation(SwordAnimation, false);
        
        public void PlayAttackBow() => 
                PlayAnimation(BowAnimation, false);

        private void PlayStartMove() =>
                DOTween.Sequence()
                        .Append(DOVirtual.DelayedCall(1f, () => characterRenderer.enabled = true))
                        .Append(DOVirtual.DelayedCall(0f, () => PlayAnimation(JumpStartAnimation, false)))
                        .Play();

        private void PlayRunMove()
        {
                if (animator.AnimationState.GetCurrent(0).Animation.Name == RunAnimation)
                        return;

                PlayAnimation(RunAnimation, true);
        }

        private void PlayJump() => 
                PlayAnimation(JumpAnimation, false);

        private void PlayIdle() => 
                PlayAnimation(IdleAnimation, true);

        private void PlayAnimation(string animationName, bool loop) => 
                animator.AnimationState.SetAnimation(0, animationName, loop);

        private float GetAnimationDuration() => 
                animator.AnimationState.GetCurrent(0).Animation.Duration;
}