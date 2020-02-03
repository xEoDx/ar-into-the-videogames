using UnityEngine;

namespace Maze
{
    public class MazeController : MonoBehaviour
    {
        public GameObject ballPrefab;

        public Transform spawnPosition;

        private GameObject _instantiatedBall;

        public void StartMaze()
        {
            _instantiatedBall = Instantiate(ballPrefab, spawnPosition.position, Quaternion.identity, spawnPosition.parent);
        }

        public void StopMaze()
        {
            Destroy(_instantiatedBall);
        }
    }
}
