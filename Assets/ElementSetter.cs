using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSetter : MonoBehaviour
{
    [SerializeField] private GameObject elementListPrefab;
    [SerializeField] private Transform listParent;

    private void Start()
    {
        foreach (var element in DataHandler.instance.elements)
        {
            print("sth");
            var t = Instantiate(elementListPrefab, listParent);
            var g = t.GetComponent<ElementSelector>();
            g.element = element;
            g.SetData();

        }
    }
}
