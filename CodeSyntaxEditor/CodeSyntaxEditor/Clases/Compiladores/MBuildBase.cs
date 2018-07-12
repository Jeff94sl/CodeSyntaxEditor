//
//  MBuildBase.cs
//
//  Author:
//       jeff <jeffrynsl@hotmail.es>
//
//  Copyright (c) 2018 
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Text;
using System.Diagnostics;

public class MBuildBase
{
    public MBuildBase()
    {
    }

    ProcessStartInfo StartIn = new ProcessStartInfo();
    Process Pro = new Process();
    protected void Run(string cmd, string argv,out string err)
    {
        try
        {
            StartIn.FileName = cmd;
            StartIn.Arguments = argv;
            StartIn.RedirectStandardInput = true;
            StartIn.RedirectStandardOutput = true;
            StartIn.RedirectStandardError = true;
            StartIn.StandardOutputEncoding = Encoding.UTF8;
            StartIn.StandardErrorEncoding = Encoding.UTF8;
            StartIn.UseShellExecute = false;
            StartIn.CreateNoWindow = true;
            Pro.StartInfo = StartIn;
            Pro.Start();
            Pro.WaitForExit();
            err = Pro.StandardError.ReadToEnd();
            err = Pro.StandardOutput.ReadToEnd();
        }
        catch (Exception Ex)
        {
            err = Ex.Message;
        }
    }

    public string Runwithinput(string cmd, string argv, string input)
    {
        try
        {
            StartIn.FileName = cmd;
            StartIn.Arguments = argv;
            StartIn.RedirectStandardOutput = true;
            StartIn.RedirectStandardError = true;
            StartIn.StandardErrorEncoding = Encoding.UTF8;
            StartIn.StandardOutputEncoding = Encoding.UTF8;
            StartIn.UseShellExecute = false;
            StartIn.CreateNoWindow = true;
            Pro.StartInfo = StartIn;
            if(Pro.WaitForInputIdle()){
                while(Pro.WaitForInputIdle()){
                }
            }
            Pro.Start();
            return Pro.StandardOutput.ReadToEnd();
        }
        catch (Exception Ex)
        {
            return Ex.Message;
        }
    }
}