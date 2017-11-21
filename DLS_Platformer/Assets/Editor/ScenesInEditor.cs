using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;


public class ScenesInEditor : MonoBehaviour {

	[MenuItem("Game/MenuScenes/Main Menu")]
	static void LoadMainMenu()
	{
		EditorSceneManager.OpenScene ("Assets/_Scenes/main_menu.unity");
	}

	[MenuItem("Game/MenuScenes/House OverWorld")]
	static void LoadHouseOverWorld()
	{
		EditorSceneManager.OpenScene ("Assets/_Scenes/OverWorld.unity");
	}

	[MenuItem("Game/MenuScenes/Kitchen OverWorld")]
	static void LoadKitchenOverWorld()
	{
		EditorSceneManager.OpenScene ("Assets/_Scenes/KitchenOverWorld.unity");
	}

	[MenuItem("Game/LevelScenes/Level 1 Fridge")]
	static void LoadLevel1()
	{
		EditorSceneManager.OpenScene ("Assets/_Scenes/Level 1.unity");
	}

	[MenuItem("Game/LevelScenes/Level 2 Freezer")]
	static void LoadLevel2()
	{
		EditorSceneManager.OpenScene ("Assets/_Scenes/Level 2.unity");
	}

	[MenuItem("Game/LevelScenes/Level 3 Lightbulb flying")]
	static void LoadLevel3()
	{
		EditorSceneManager.OpenScene ("Assets/_Scenes/Level 3 flying.unity");
	}

	[MenuItem("Game/LevelScenes/Level 4 Fume Hood moving platform")]
	static void LoadLevel4()
	{
		EditorSceneManager.OpenScene ("Assets/_Scenes/Level 4 moving.unity");
	}

	[MenuItem("Game/LevelScenes/Level 5 Toaster")]
	static void LoadLevel5()
	{
		EditorSceneManager.OpenScene ("Assets/_Scenes/Level 5.unity");
	}

	[MenuItem("Game/LevelScenes/Level 6 Oven Boss")]
	static void LoadLevel6Boss()
	{
		EditorSceneManager.OpenScene ("Assets/_Scenes/BossBattle1.unity");
	}
}
