using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extended2D
{
    public class Organizer : ExtendedSingleton<Organizer>
    {
        [HideInInspector]
        public GameObject organizedStorage;

        public Dictionary<string, GameObject> OrganizedFields;

        void Awake()
        {
            organizedStorage = new GameObject("Organized Storage");
            OrganizedFields = new Dictionary<string, GameObject>();
        }

        public void AddFieldToDictionary(string newFieldName)
        {
            GameObject newOrganizedContainer = new GameObject();
            newOrganizedContainer.transform.parent = organizedStorage.transform;
            newOrganizedContainer.name = newFieldName;

            OrganizedFields.Add(newFieldName, newOrganizedContainer);
        }

        public void ObjectChecker(GameObject inGO)
        {
            if (inGO.tag != null)
            {
                if (!OrganizedFields.ContainsKey(inGO.tag))
                    AddFieldToDictionary(inGO.tag);
                inGO.transform.parent = OrganizedFields[inGO.tag].transform;
            }
        }
    }
}