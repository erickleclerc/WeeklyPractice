using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Material[] skyboxes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadScene("Level02", LoadSceneMode.Additive);
        //set skybox to the first one in the array
        RenderSettings.skybox = skyboxes[1];
    }

    // Update is called once per frame
    void Update()
    {
        //if I press the g key, flip between the two scenes
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (SceneManager.GetSceneByName("Level02").isLoaded)
            {
                SceneManager.UnloadSceneAsync("Level02");
                SceneManager.LoadScene("Level01", LoadSceneMode.Additive);
                RenderSettings.skybox = skyboxes[0];
            }
            else if (SceneManager.GetSceneByName("Level01").isLoaded)
            {
                SceneManager.UnloadSceneAsync("Level01");
                SceneManager.LoadScene("Level02", LoadSceneMode.Additive);
                RenderSettings.skybox = skyboxes[1];
            }
        }
    }
}
