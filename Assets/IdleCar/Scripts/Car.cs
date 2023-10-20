using PathCreation.Examples;
using System.Collections;
using UnityEngine;

public class Car : MonoBehaviour
{

    public int _level;

    public void SetPathNPos()
    {
        PathFollower thisPathFollower = GetComponent<PathFollower>();
        thisPathFollower.pathCreator = EventManager.RoadManager.Invoke().roads[_level - 1];
        thisPathFollower.distanceTravelled = Random.Range(0, thisPathFollower.pathCreator.path.length);
    }

    public void OnCalled()  
    {
        SetPathNPos();
        EventManager.CarsManager.Invoke().ToGameList(this, _level);
        gameObject.SetActive(true);
    }

    public void ReturnTheBase()
    {
        gameObject.SetActive(false);
        EventManager.CarsManager.Invoke().ToMainList(this, _level);
        print("return the base");
    }

}
