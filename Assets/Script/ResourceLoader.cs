using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public static class ResourceLoader 
{
   

    private static AssetBundle _bgmAsset;
    private static AssetBundle _soundAsset;


    public static void LazyLoadInit()
    {
        _bgmAsset = AssetBundle.LoadFromFile("AssetBundles/bgm");
        _soundAsset = AssetBundle.LoadFromFile("AssetBundles/clip");
    }
   
    public static AudioClip BgmLoad(string clipName)
    {
        if (_bgmAsset)
        {
           return _bgmAsset.LoadAsset<AudioClip>(clipName);
        }
        else
        {
            _bgmAsset = AssetBundle.LoadFromFile("AssetBundles/bgm");
            return _bgmAsset.LoadAsset<AudioClip>(clipName);
        }
    }

    public static AudioClip SoundLoad(string clipName)
    {
        if (_soundAsset)
        {
            return _soundAsset.LoadAsset<AudioClip>(clipName);
        }
        else
        {
            _soundAsset = AssetBundle.LoadFromFile("AssetBundles/clip");
            return _soundAsset.LoadAsset<AudioClip>(clipName);
        }
    }
}
