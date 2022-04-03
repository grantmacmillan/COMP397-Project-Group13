using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildButton : MonoBehaviour
{
    private BuildManager buildManager;
    private TextMeshProUGUI text;
    private Color darkRed = new (139,0,0), darkGreen = new (0, 100, 0);

    private int[] diff = new int[3];

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (buildManager.GetTurretToBuild() != null)
        {
            Tower tower = buildManager.GetTurretToBuild();

            diff[0] = ResourceManager.Instance.GetGold() - tower.gold;

            diff[1] = ResourceManager.Instance.GetWood() - tower.wood;

            diff[2] = ResourceManager.Instance.GetGems() - tower.gem;

            if (diff[0] < 0 || diff[1] < 0 || diff[2] < 0)
            {
                text.color = new Color(0.7f,0,0,1);
            }
            else if(diff[0] >= 0 && diff[1] >= 0 && diff[2] >= 0)
            {
                text.color = new Color(0,0.60f,0,1);
            }
        }
    }
}
