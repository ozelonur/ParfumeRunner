using UnityEditor;
using UnityEngine;

namespace _ORANGEBEAR_.Scripts.Editor
{
    public class OrangeBearMenu : MonoBehaviour
    {
        [MenuItem("Orange Bear/Clear All Player Prefs")]
        private static void ClearAllPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log($"All Player Prefs Cleared !");
        }
    }
}
