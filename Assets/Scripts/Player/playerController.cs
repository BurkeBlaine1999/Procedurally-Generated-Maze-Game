using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class playerController : MonoBehaviour
{
    //Variables
    public float speed;
    public MazeRenderer mr;
    [SerializeField] private MainMenu menu;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;
    [SerializeField] private CinemachineVirtualCamera cam;

    //Body
    void Update()
    {
      
        //If not paused, allow the player to move.
        if (menu.isPaused() == false)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            gameObject.transform.position = new Vector3(transform.position.x + (h * speed), 0,
            transform.position.z + (v * speed));
        }

        //Get the scroll wheel, and check if it is scrolling up or down.
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            var transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
            transposer.m_FollowOffset = new Vector3(0, transposer.m_FollowOffset.y + 1, 0);
            //transposer.m_XDamping = transposer.m_FollowOffset.y * ;
            
        }
        else if (scroll < 0f)
        {
            var transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
            //Restrict player from zooming in too much
            if (transposer.m_FollowOffset.y >= 5)
            {
                transposer.m_FollowOffset = new Vector3(0, transposer.m_FollowOffset.y - 1, 0);
            }
        }

    }

    //Check if the player has collided with a finish line
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "finish")
        {
          //Play the win sound effect and regenerate
            source.PlayOneShot(clip);
            mr.ReGenerateMaze();
        }
        else if (col.gameObject.tag == "Increase_Difficulty")
        {
          //Play the win sound effect, increase Difficulty and regenerate
            source.PlayOneShot(clip);
            mr.increaseDifficulty();
            var test = mr.getScore() - 2;

            //Set Local highscore
            if(test > PlayerPrefs.GetInt("MazeHighscore")){
              PlayerPrefs.SetInt("MazeHighscore",test);
            }
            
            mr.ReGenerateMaze();
        }
    }
}
