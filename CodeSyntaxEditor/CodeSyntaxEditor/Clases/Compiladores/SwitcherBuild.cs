//
//  SwitcherBuild.cs
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
using System.IO;
using System.Text.RegularExpressions;

public class SwitcherBuild : MBuildBase
{
    public SwitcherBuild()
    {
    }

    public void Building(string value, string file,string values, out string err)
    {
        err = "";
        switch (value.ToLower())
        {
            case "c":{
                    Run("gcc", file,out err);
                }break;
            case "cpp":{
                    Run("gcc",file,out err);
                }break;
            case "cs":{
                    Run("mcs", file,out err);
                    string exe = file.Replace(".cs",".exe");
                    if(File.Exists(exe)){
                        Run("mono",exe,out err);
                    }
                }break;
            case "html":{
                    Run("firefox", file,out err);
                }break;
            case "py":{
                    Run("python3", file,out err);
                }break;
            case "rb":{
                    Run("ruby", file,out err);
                }break;
            case "go":{
                    Run("go"," run " +file,out err);
                }break;
        }
    }
}