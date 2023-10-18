using System;

public static class EventManager
{
    public static Func<ObjectPool> ObjectPool;
    public static Func<GameManager> GameManager;
    public static Func<CarsManager> CarsManager;
}