using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extended2D.Animations
{
    public class AnimationManager : ExtendedSingleton<AnimationManager>
    {
        private AnimationManager() { }

        [HideInInspector]
        public List<AnimatedObject> ObjectsToAnimate;

        private int i;

        public float FPS = 24;
        [HideInInspector]
        public float AnimationTickRate;

        public bool animateObjectsAsync;

        void Start()
        {
            i = 1;
            AnimationTickRate = (100 / FPS) / 60;

            if (!animateObjectsAsync)
                StartCoroutine(AnimateAllTheThings());
        }

        IEnumerator AnimateAllTheThings()
        {
            while (i != 0)
            {
                yield return new WaitForSeconds(AnimationTickRate);

                if (ObjectsToAnimate != null)
                    foreach (AnimatedObject workingObject in ObjectsToAnimate)
                    {
                        SpriteRenderer SR = workingObject.parent.SR;

                        SR.sprite = workingObject.currentAnimation.animSprites[workingObject.currentAnimation.tickCount];

                        workingObject.parent.AnimationTick();
                    }
            }
        }

        public void SetupObjectForAnimation(ExtendedGameObject intake)
        {
            if (intake.objAnim == null)
                intake.objAnim = intake.gameObject.AddComponent<AnimatedObject>();

            if (intake.objAnim.childName == null || intake.objAnim.childName == "")
                intake.objAnim.childName = "Animated Object";
            intake.objAnim.childParent = managerName;

            intake.objAnim.parent = intake;
            intake.objAnim.initialAnimations = new List<CustomAnimation>();

            foreach (string temp in intake.objectAnimations)
            {
                CustomAnimation newAnimation = intake.gameObject.AddComponent<CustomAnimation>();

                newAnimation.animName = temp;
                newAnimation.objAnim = intake.objAnim;

                newAnimation.childName = newAnimation.animName;
                newAnimation.childParent = intake.objAnim.childName;

                intake.objAnim.initialAnimations.Add(newAnimation);

                InitializeChildrenScripts(newAnimation);

                if (intake.animateLeftRightSame)
                {
                    if (temp.Length > 8)
                    {
                        string newString = temp.Substring(temp.Length - 7, 6);

                        if (newString == "R Base" || newString == "L Base")
                        {
                            newAnimation.animName.Remove(newAnimation.animName.Length - 6, 5);

                            CustomAnimation newAnimation2 = intake.gameObject.AddComponent<CustomAnimation>();

                            newAnimation2.objAnim = intake.objAnim;

                            newAnimation2.animName = temp;
                            newAnimation2.animName.Remove(newAnimation2.animName.Length - 7, 6);
                            newAnimation2.animName += "L";

                            newAnimation2.childName = newAnimation.animName;
                            newAnimation2.childParent = intake.objAnim.childName;

                            newAnimation2.flipped = true;

                            intake.objAnim.initialAnimations.Add(newAnimation2);

                            InitializeChildrenScripts(newAnimation2);

                            if (newString == "R Base")
                                newAnimation2.animName += "L";
                            else if (newString == "L Base")
                                newAnimation2.animName += "R";
                        }
                    }
                }

                InitializeChildrenScripts(intake.objAnim);
            }
        }
    }
}