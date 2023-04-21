using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public static class ResourceLoader 
{
   

    private static AssetBundle _bgmAsset;
    private static AssetBundle _soundAsset;
    private static AssetBundle _obstacleAsset;
    private static string _bgmPackName = "bgm";
    private static string _soundPackName = "clip";
    private static string _obstacleName = "obstacle";


    public static void LazyLoadInit()
    {
        if (_bgmAsset==null)
        {
            _bgmAsset = AssetBundle.LoadFromFile($"AssetBundles/{_bgmPackName}");
        }

        if (_soundAsset ==null)
        {
            _soundAsset = AssetBundle.LoadFromFile($"AssetBundles/{_soundPackName}");
        }

        if (_obstacleAsset == null)
        {
            _obstacleAsset = AssetBundle.LoadFromFile($"AssetBundles/{_obstacleName}");
        }
        
      
    }
   
    [LuaCallCSharp]
    public static AudioClip BgmLoad(string clipName)
    {
        if (_bgmAsset!=null)
        {
           return _bgmAsset.LoadAsset<AudioClip>(clipName);
        }
        else
        {
            _bgmAsset = AssetBundle.LoadFromFile($"AssetBundles/{_bgmPackName}");
            return _bgmAsset.LoadAsset<AudioClip>(clipName);
        }
    }

    [LuaCallCSharp]
    public static AudioClip SoundLoad(string clipName)
    {
        if (_bgmAsset!=null)
        {
            return _soundAsset.LoadAsset<AudioClip>(clipName);
        }
        else
        {
            _soundAsset = AssetBundle.LoadFromFile($"AssetBundles/{_soundPackName}");
            return _soundAsset.LoadAsset<AudioClip>(clipName);
        }
    }

    public static GameObject LoadObstacle(string obstacleName)
    {
        if (_obstacleAsset!=null)
        {
            return _obstacleAsset.LoadAsset<GameObject>(obstacleName);
        }
        else
        {
            _obstacleAsset = AssetBundle.LoadFromFile($"AssetBundles/{_obstacleName}");
            return _obstacleAsset.LoadAsset<GameObject>(obstacleName);
        }
       
    }
    public static void SetBgmPackName(string bgmPackName)
    {
        _bgmPackName = bgmPackName;
    }
    public static void SetSoundPackName(string soundPackName)
    {
        _soundPackName = soundPackName;
    }

    public static void SetObstaclePackName(string obstacleName)
    {
        _obstacleName = obstacleName;
    }
    
    
}
