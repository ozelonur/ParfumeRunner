using PathCreation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME_.Scripts.Helpers
{
    public class FinishLocator : MonoBehaviour
    {
        [SerializeField] private PathCreator path;
        [SerializeField] private Transform road;

        [Button("Go To Finish")]
        private void GoToFinish()
        {
            Vector3 localScale = road.localScale;
            localScale = new Vector3(localScale.x, localScale.y, path.path.length + 20);
            road.localScale = localScale;
        
            Vector3 localPosition = road.localPosition;
            localPosition = new Vector3(localPosition.x, localPosition.y,
                ((localScale.z / 2) - 20));
            road.localPosition = localPosition;

            transform.localPosition = Vector3.forward * path.path.length;
        }
    }
}