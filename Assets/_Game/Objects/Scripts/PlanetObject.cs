using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Planets/Planet")]


public class PlanetObject : ScriptableObject
{
    public string PlanetName;
    public string StarName;
    public Sprite PlanetSprite;
    // public Sprite SpectreSprite;
    [TextArea(0, 20)] public string PlanetDescription;
    [TextArea(0, 20)] public string PlanetLookDescription;

    [Expandable] public List<ElementObject> elements;
}
