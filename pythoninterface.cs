using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

public class pythoninterface : MonoBehaviour
{
    // Start is called before the first frame update
     void Start()
    { 
    		UnityEngine.Debug.Log( Application.dataPath);
    		
    	 	ProcessStartInfo psi = new ProcessStartInfo(); 
		psi.FileName = "/bin/sh";
		psi.UseShellExecute = false; 
		psi.RedirectStandardOutput = true;
		psi.Arguments = Application.dataPath + "/job.sh";
		Process p = Process.Start(psi); 
		string strOutput = p.StandardOutput.ReadToEnd(); 
		
		UnityEngine.Debug.Log(strOutput);
    
    }

    

    
}
