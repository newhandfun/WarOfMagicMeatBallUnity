using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


public class MyImportSetting : AssetPostprocessor{

	void OnPostprocessModel (GameObject _o) {

		ModelImporter modelImporter = assetImporter as ModelImporter;

		var times = DateTime.Now.ToString ("h:mm:ss tt");

		Debug.Log ("匯入模型"+_o.name+ "於" + times +"!");

		modelImporter.materialName = ModelImporterMaterialName.BasedOnMaterialName;
		modelImporter.materialSearch = ModelImporterMaterialSearch.RecursiveUp;


		if (modelImporter.clipAnimations.Length != 0) {
			Debug.Log ("總共有"+modelImporter.clipAnimations.Length.ToString()+"個動作!");
			foreach(ModelImporterClipAnimation clip in modelImporter.clipAnimations){
				clip.loopTime = true;
				clip.wrapMode = WrapMode.Loop;
				clip.lockRootRotation = true;
                clip.keepOriginalPositionY = clip.keepOriginalPositionXZ = clip.keepOriginalOrientation = true;
			}
		}
	}
}
