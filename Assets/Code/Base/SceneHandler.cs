using UnityEngine.SceneManagement;

namespace Code.Base
{
    public class SceneHandler
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}