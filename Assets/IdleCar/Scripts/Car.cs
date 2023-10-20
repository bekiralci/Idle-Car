using PathCreation.Examples;
using UnityEngine;

public class Car : MonoBehaviour
{

    public int _level;

    public void SetPath()
    {
        GetComponent<PathFollower>().pathCreator = EventManager.RoadManager.Invoke().roads[_level - 1];
    }

    public void OnCalled()
    {
        SetPath();
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
