using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Ball b = other.GetComponent<Ball>();

        if (b != null)
        {
            if (b.Point == 0)
            {
                Game_Manager.instance.ShowString("Whiteball dropped, you Lost!");
                Time.timeScale = 0f;
            }
            else
            {

                Game_Manager.instance.ShowScoreText(b.Point);
            }
            Destroy(b.gameObject);
            AudioManager.Instance.PlaySFX(1);
            
        }
    }
}
