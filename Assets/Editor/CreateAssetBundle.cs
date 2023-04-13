using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class CreateAssetBundle 
{
   
   
   //add 
   [MenuItem("Assets/BuildAssetBundle")]
   private static void BuildAssetBundle()
   {

      string path = "AssetBundles";

      if (!Directory.Exists(path))
      {
         Directory.CreateDirectory(path);
      }

      BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
      
   }
}
