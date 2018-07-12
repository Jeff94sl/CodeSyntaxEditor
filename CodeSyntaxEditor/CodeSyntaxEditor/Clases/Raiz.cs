//
//  Raiz.cs
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
using Gtk;

public class Raiz
{
    public Raiz()
    {

    }
    public TreeView Tree { get; set; }

    public void Cargar_Archivos(string Path)
    {
        
        try
        {
            DirectoryInfo Dir = new DirectoryInfo(Path);
            FileInfo[] File = Dir.GetFiles();

            TreeStore Store = new TreeStore(typeof(string), typeof(string));
            ListStore List = new ListStore(typeof(string), typeof(string));

            TreeViewColumn A = new TreeViewColumn();
            A.Title = "Archivo";

            CellRendererText Render = new CellRendererText();

            A.PackStart(Render, true);

            Tree.AppendColumn(A);

            A.AddAttribute(Render, "text", 0);

            foreach (FileInfo D in Dir.GetFiles()){
                
                TreeIter Iter = Store.AppendValues(D.Name);
            }
            Tree.Model = Store;
        }
        catch (AccessViolationException Ex)
        {
            Console.WriteLine(Ex.Message);
        }
        catch (UnauthorizedAccessException Ex)
        {
            Console.WriteLine(Ex.Message);
        }
        catch (DirectoryNotFoundException Ex)
        {
            Console.WriteLine(Ex.Message);
        }
    }

    public void Cargar_Directorio(ComboBox Comb){
        DirectoryInfo Dinf = new DirectoryInfo(Directory.GetCurrentDirectory());
        int index = 0;
        foreach(DirectoryInfo dir in Dinf.GetDirectories()){
            Comb.InsertText(index,dir.Name);
        }
    }
}