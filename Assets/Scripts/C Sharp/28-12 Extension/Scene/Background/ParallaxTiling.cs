using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extended2D.WorldSpace.Background
{
    public class ParallaxTiling : ExtendedChildScript
    {
        private Camera cam;

        public int offsetX = 2;

        private float spriteWidth = 0f;

        public bool rightLoop = false;
        public bool leftLoop = false;

        public bool reverseScale = false;


        void Awake()
        {
            cam = Camera.main;
        }

        void Start()
        {
            SpriteRenderer SR = GetComponent<SpriteRenderer>();
            spriteWidth = SR.sprite.bounds.size.x;
        }

        void Update()
        {
            if (!leftLoop || !rightLoop)
            {
                float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;
                float edgeVisiblePositionRight = (transform.position.x + spriteWidth / 2) - camHorizontalExtend;
                float edgeVisiblePositionLeft = (transform.position.x - spriteWidth / 2) + camHorizontalExtend;

                if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && rightLoop == false)
                {
                    ContinueLoop(1);
                    rightLoop = true;
                }
                else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && leftLoop == false)
                {
                    ContinueLoop(-1);
                    leftLoop = true;
                }
            }
        }

        public void ContinueLoop(int leftRight)
        {
            Vector3 newPosition = new Vector3(transform.position.x + spriteWidth * leftRight, transform.position.y, transform.position.z);
            Transform newLoop = Instantiate(transform, newPosition, transform.rotation) as Transform;
            SpriteRenderer SR = newLoop.GetComponent<SpriteRenderer>();
            SR.flipX = !SR.flipX;

            if (reverseScale == true)
                newLoop.localScale = new Vector3(newLoop.localScale.x * -1, newLoop.localScale.y, newLoop.localScale.z);

            newLoop.parent = transform.parent;

            if (leftRight > 0)
            {
                newLoop.GetComponent<ParallaxTiling>().leftLoop = true;
            }
            else
            {
                newLoop.GetComponent<ParallaxTiling>().rightLoop = true;
            }
        }
    }
}