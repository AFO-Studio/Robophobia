using System.Collections.Generic;
using UnityEngine;

namespace Extended2D.Animations
{
    public class AnimatedObject : ExtendedChildScript
    {
        [HideInInspector]
        public ExtendedGameObject parent;

        [HideInInspector]
        public List<CustomAnimation> initialAnimations;

        public Dictionary<string, CustomAnimation> animations;

        public AsyncAnim objAsyncAnimRef;

        [HideInInspector]
        public CustomAnimation idleAnimation;

        [HideInInspector]
        public CustomAnimation currentAnimation;

        [HideInInspector]
        public string nextAnimName = "Idle";

        [HideInInspector]
        public bool animationChangeRequest;
        [HideInInspector]
        public bool asyncAnimate;

        void Start()
        {
            animations = new Dictionary<string, CustomAnimation>();

            foreach (CustomAnimation workingAnim in initialAnimations)
            {
                AnimationManager.instance.InitializeChildrenScripts(workingAnim);
                animations.Add(workingAnim.animName, workingAnim);

                if (workingAnim.animName == "Idle")
                    idleAnimation = workingAnim;
            }

            if (!animations.ContainsKey("Idle"))
            {
                idleAnimation = gameObject.AddComponent<CustomAnimation>();
                idleAnimation.animName = "Idle";

                idleAnimation.objAnim = this;

                animations.Add("Idle", idleAnimation);
                idleAnimation.isNewIdle = true;
            }

            currentAnimation = idleAnimation;

            asyncAnimate = AnimationManager.instance.animateObjectsAsync;

            if (!asyncAnimate)
            {
                if (AnimationManager.instance.ObjectsToAnimate == null)
                    AnimationManager.instance.ObjectsToAnimate = new List<AnimatedObject>();

                AnimationManager.instance.ObjectsToAnimate.Add(this);
            }
            else
            {
                if (objAsyncAnimRef == null)
                {
                    objAsyncAnimRef = gameObject.AddComponent<AsyncAnim>();
                    objAsyncAnimRef.parentAObj = this;
                }

                objAsyncAnimRef.AnimateAsync();
            }
        }

        void OnDestroy()
        {
            if (!asyncAnimate)
                if (AnimationManager.instance != null)
                    AnimationManager.instance.ObjectsToAnimate.Remove(this);
                else
                {
                    if (objAsyncAnimRef != null)
                    {
                        objAsyncAnimRef.StopAllCoroutines();
                        Destroy(objAsyncAnimRef);
                    }
                }
        }

        public void ChangeAnimation()
        {
            if (currentAnimation.animName == "Death")
            { /*Fill later*/}

            if (!animationChangeRequest)
                nextAnimName = idleAnimation.animName;

            if (idleAnimation.isNewIdle)
            {
                idleAnimation.animSprites.Clear();
                idleAnimation.animSprites.Add(currentAnimation.animSprites[currentAnimation.animSprites.Count - 1]);
            }

            animationChangeRequest = false;

            currentAnimation.tickCount = 0;

            currentAnimation = animations[nextAnimName];
        }
    }
}