using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extended2D.WorldSpace.Background
{
    public class Parallax : ExtendedChildScript
    {
        private Transform cam;
        private Vector3 previousCamPos;

        public float parallaxScale;
        public float smoothing;

        public bool parallaxForward;

        void Start()
        {
            cam = Camera.main.transform;
            previousCamPos = cam.position;
            parallaxScale = transform.position.z * -1;
        }

        void Update()
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScale;
            float backgroundTargetPosX = transform.position.x - parallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, backgroundTargetPos, smoothing * Time.deltaTime);

            previousCamPos = cam.position;
        }
    }
}