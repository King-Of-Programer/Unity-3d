using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LabirintState : MonoBehaviour
{
    private static List<Action<String>> observers = new();
    private static Dictionary<String, List<Action>> propertyObservers = new()
    {
        {nameof(checkPoint1Amount),new() },
        {nameof(checkPoint2Amount),new() },
        {nameof(checkPoint2Active),new() },
        {nameof(gameLevel),new() },
        {nameof(musicVolume),new() }
    };

    public static void AddPropertyListener(String propertyName, Action listener)
    {
        if (propertyObservers.ContainsKey(propertyName))
        {
            propertyObservers[propertyName].Add(listener);
        }
        else
        {
            throw new ArgumentException($"'{propertyName}' Could not be observed");
        }
    }

    public static void RemovePropertyListener(String propertyName, Action listener)
    {
        if (propertyObservers.ContainsKey(propertyName))
        {
            propertyObservers[propertyName].Remove(listener);
        }
        else
        {
            throw new ArgumentException($"'{propertyName}' Could not be observed");
        }
    }

    public static void AddNotifyListener(Action<String> listener) => observers.Add(listener);

    public static void RemoveNotifyListener(Action<String> listener) => observers.Remove(listener);

    private static void NotifyListeners([CallerMemberName] String propertyName = "")
    {
        observers.ForEach(listener => listener.Invoke(propertyName));
        if (propertyObservers.ContainsKey(propertyName))
        {
            propertyObservers[propertyName].ForEach(listener => listener.Invoke());
        }
        /*foreach (var listener in observers)
        {
            listener.Invoke(propertyName);
        }*/
    }

    private static float _checkPoint1Amount { get; set; }
    public static float checkPoint1Amount
    {
        get { return _checkPoint1Amount; }
        set
        {
            if (_checkPoint1Amount != value)
            {
                _checkPoint1Amount = value;
                NotifyListeners();
            }
        }
    }
    private static float _musicVolume;
    public static float musicVolume
    {
        get { return _musicVolume; }
        set
        {
            _musicVolume = value;
            NotifyListeners();
        }
    }

    private static float _checkPoint2Amount { get; set; }
    public static float checkPoint2Amount
    {
        get { return _checkPoint2Amount; }
        set
        {
            if (_checkPoint2Amount != value)
            {
                _checkPoint2Amount = value;
                NotifyListeners();
            }
        }
    }
    public static bool _checkPoint2Active;
    public static bool checkPoint2Active
    {
        get
        {
            return _checkPoint2Active;
        }
        set
        {
            _checkPoint2Active = value;
            NotifyListeners();
        }
    }
    private static int _gameLevel;
    public static int gameLevel
    {
        get { return _gameLevel; }
        set
        {
            _gameLevel = value;
            NotifyListeners();
        }
    }
    public static bool checkPoint1Passed { get; set; }

    public static bool cameraFirstPerson { get; set; }
    public static bool isDay { get; set; }
    public static bool isPause { get; set; }
    public static int score { get; set; }

    public static float effectsVolume;
    public static bool isSoundsMuted;


}
