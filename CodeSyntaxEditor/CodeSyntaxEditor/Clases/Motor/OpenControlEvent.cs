//
//  OpenControlEvent.cs
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
using System.Text.RegularExpressions;
using Gtk;

public class OpenControlEvent : OpenControlBase
{
    public OpenControlEvent()
    {
    }

    public void Buffer_InsertText(object o, InsertTextArgs args)
    {
        Modificado[count] = true;
        Caracteres.Text = "Caracteres: " + Convert.ToString(Texto[count].Buffer.Text.Length);
        Lineas.Text = "Lineas: " + Convert.ToString(Texto[count].Buffer.LineCount);
    }

    public void OnPaginaSwitchPage(object o, SwitchPageArgs args)
    {
        if (Pagina.Page >= 0)
        {
            count = Pagina.Page;
            Caracteres.Text = "Caracteres: " + Convert.ToString(Texto[count].Buffer.Text.Length);
            Lineas.Text = "Lineas: " + Convert.ToString(Texto[count].Buffer.LineCount);
        }
        else
        {
            index = 0;
        }
    }
}