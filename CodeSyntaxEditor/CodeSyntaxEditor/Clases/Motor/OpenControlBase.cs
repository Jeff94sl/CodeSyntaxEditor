//
//  OpenControlBase.cs
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
using Gtk;

public class OpenControlBase
{
    public OpenControlBase()
    {
    }
    protected int count = 0;
    protected int index = 0;

    protected bool[] Nuevo = new bool[1000];
    protected bool[] Modificado = new bool[1000];
    protected bool[] Guardado = new bool[1000];
    protected Clipboard Clip = Gtk.Clipboard.Get((Gdk.Atom.Intern("Clip", false)));

    protected ScrolledWindow[] Scroll = new ScrolledWindow[1000];
    protected Label[] Etiqueta = new Label[1000];
    protected TextView[] Texto = new TextView[1000];

    public Window win { get; set; }
    public Notebook Pagina { get; set; }
    public Label Caracteres { get; set; }
    public Label Lineas { get; set; }
    //public MenuBar Recientes { get; set; }

    protected OpenControlExten Ext = new OpenControlExten();
}