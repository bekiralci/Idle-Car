using PathCreation;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{

    #region EventManager

    RoadManager GetThis()
    {
        return this;
    }

    private void OnEnable()
    {
        EventManager.RoadManager += GetThis;
    }

    private void OnDisable()
    {
        EventManager.RoadManager -= GetThis;
    }

    #endregion

    public List<PathCreator> roads = new();

}
