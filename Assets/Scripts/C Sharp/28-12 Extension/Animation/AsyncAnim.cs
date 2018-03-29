using System.Collections;
using UnityEngine;

namespace Extended2D.Animations
{
    public class AsyncAnim : MonoBehaviour
    {
        [HideInInspector]
        public AnimatedObject parentAObj;

        private int i = 1;

        private float AnimationTickRate;

        public void AnimateAsync()
        {
            i = 1;

            StartCoroutine(AnimateJustTheOneThing());
        }

        IEnumerator AnimateJustTheOneThing()
        {
            AnimationTickRate = ExtendedGameController.instance.animationManager.AnimationTickRate;

            while (i != 0)
            {
                yield return new WaitForSeconds(AnimationTickRate);

                    SpriteRenderer SR = parentAObj.parent.SR;

                SR.flipX = false;

                if (parentAObj.currentAnimation.flipped == true)
                {
                    SR.flipX = true;
                }

                SR.sprite = parentAObj.currentAnimation.animSprites[parentAObj.currentAnimation.tickCount];

                    parentAObj.currentAnimation.AnimationTick();
            }
        }
    }
}