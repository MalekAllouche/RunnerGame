using DG.Tweening;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 0.2f;
    public static bool tapToStart = false;
    public GameObject player;
    private bool isMoving = false;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

void Update()
    {
   

        if (tapToStart)
        {
            transform.Translate(new Vector3(0, 0, 0.4f) * speed);
        }

        
        if (Input.GetKeyDown(KeyCode.A) && !isMoving && tapToStart)
        {
            if (player.transform.localPosition.x > -3)
            {
                isMoving = true;
                player.transform.DOLocalMoveX(player.transform.localPosition.x - 3, 0.2f).OnComplete(() => isMoving = false);
            }
        }

        
        if (Input.GetKeyDown(KeyCode.D) && !isMoving && tapToStart)
        {
            if (player.transform.localPosition.x < 3)
            {
                isMoving = true;
                player.transform.DOLocalMoveX(player.transform.localPosition.x + 3, 0.2f).OnComplete(() => isMoving = false);
            }
        }
    }
}
