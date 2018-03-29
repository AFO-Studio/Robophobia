using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Extended2D.Animations
{
    public class CustomAnimation : ExtendedChildScript
    {
        public List<Sprite> animSprites;

        public AnimatedObject objAnim;

        public string animName;

        [HideInInspector]
        public int tickCount = 0;

        [HideInInspector]
        public bool isNewIdle;
        [HideInInspector]
        public bool flipped;

        void Start()
        {
            if (animSprites == null)
                animSprites = new List<Sprite>();

            animSprites = Resources.LoadAll<Sprite>("Animations/" + objAnim.parent.EGOType + "/" + objAnim.parent.EGOIdentifier + "/" + animName).ToList();
        }

        public void AnimationTick()
        {
            ++tickCount;

            if (tickCount == animSprites.Count)
                objAnim.ChangeAnimation();
        }
    }
}