using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillDataUI : MonoBehaviour
{
    public TextMeshProUGUI ak;
    public TextMeshProUGUI mk;
    // Start is called before the first frame update
    void Start()
    {    
        ak.text="Kill: "+KillCounter.instance.ailenKill;
        mk.text="Destruction: "+KillCounter.instance.meteorKill;
    }
}
