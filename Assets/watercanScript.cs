using UnityEngine;

public class watercanScript : MonoBehaviour
{
    int flag = 0;
    public GameObject[] water;
    //public ParticleSystem[] water;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            flag++;
            if (flag > 2) flag = 2;
            setWaterAmnt(flag);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            flag--;
            if (flag < 0) flag = 0;
            setWaterAmnt(flag);
        }
    }

    public void setWaterAmnt(int _f)
    {
        switch (_f)
        {
            case 0:
                water[0].SetActive(true);
                water[1].SetActive(false);
                water[2].SetActive(false);
                break;
            case 1:
                water[0].SetActive(true);
                water[1].SetActive(true);
                water[2].SetActive(false);
                break;
            case 2:
                water[0].SetActive(true);
                water[1].SetActive(true);
                water[2].SetActive(true);
                break;
        }
    }
}
