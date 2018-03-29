using System.Collections.Generic;
using UnityEngine;
using Extended2D.Animations;

namespace Extended2D
{
    public class ExtendedGameObject : MonoBehaviour
    {
        public List<string> objectAnimations;

        [HideInInspector]
        public AnimatedObject objAnim;

        [HideInInspector]
        public SpriteRenderer SR;

        public string EGOType;
        public string EGOIdentifier;

        public bool animateLeftRightSame;
        public bool animatedObject;

        [HideInInspector]
        public int locInCollection;

        void Awake()
        {
            if (name == "Player")
                ExtendedGameController.instance.playerEGO = this;

            locInCollection = ExtendedGameController.instance.CollectionUpdater(this);
        }

        void Start()
        {
            if (SR == null)
                SR = gameObject.AddComponent<SpriteRenderer>();

            if (animatedObject)
                AnimationManager.instance.SetupObjectForAnimation(this);
        }


        public virtual void AnimationTick()
        {
            objAnim.currentAnimation.AnimationTick();
        }
    }
}