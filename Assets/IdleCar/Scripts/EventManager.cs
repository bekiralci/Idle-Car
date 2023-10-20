using System;

public static class EventManager
{
    public static Func<GameManager> GameManager;
    public static Func<CarsManager> CarsManager;
    public static Func<AmountManager> AmountManager;
    public static Func<ButtonManager> ButtonManager;
    public static Func<ObjectFactory> ObjectFactory;
    public static Func<RoadManager> RoadManager;
    public static Func<UiItemIncome> UiItemIncome;
}