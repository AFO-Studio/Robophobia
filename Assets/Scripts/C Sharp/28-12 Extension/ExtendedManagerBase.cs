using System.Collections.Generic;
using UnityEngine;

namespace Extended2D
{
	public class ExtendedManagerBase : MonoBehaviour
    {
        [HideInInspector]
        public List<ExtendedChildScript> ChildrenScripts = new List<ExtendedChildScript>();

        public string managerName;
        [HideInInspector]
        public string managerParent;

        public void InitializeChildrenScripts(ExtendedChildScript intake)
        {
            ChildrenScripts.Add(intake);
            intake.childParent = managerName;          
        }
    }
}