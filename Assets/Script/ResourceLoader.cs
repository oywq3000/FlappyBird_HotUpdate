using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public static class ResourceLoader 
{
   

    private static AssetBundle _bgmAsset;
    private static AssetBundle _soundAsset;
    private static string _bgmPackName = "bgm";
    private static string _soundPackName = "clip";


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

    public static void SetBgmPackName(string bgmPackName)
    {
        _bgmPackName = bgmPackName;
    }
    public static void SetSoundPackName(string soundPackName)
    {
        _soundPackName = soundPackName;
    }
}
