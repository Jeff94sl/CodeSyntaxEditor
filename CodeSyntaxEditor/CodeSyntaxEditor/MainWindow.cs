//
//  MainWindow.cs
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
using System.Diagnostics;
using System.Threading;

public partial class MainWindow : Gtk.Window
{
    OpenControlFunc Editor = new OpenControlFunc();
    Raiz Ra = new Raiz();
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        Editor.win = this;
        Editor.Pagina = Pagina;
        Editor.Caracteres = Caracteres;
        Editor.Lineas = Lineas;
        Ra.Tree = Archivos;
        Ra.Cargar_Directorio(Directorios);
        Editor.Init();
        ScrollPagina.ButtonPressEvent += ScrollPagina_ButtonPressEvent;
    }

    void ScrollPagina_ButtonPressEvent(object o, ButtonPressEventArgs args)
    {
        Editor.EliminarPestaña();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        MessageDialog Msg = new MessageDialog(this, DialogFlags.Modal,
                                              MessageType.Question,
                                              ButtonsType.OkCancel, "Salir?");
        if (Msg.Run() == (int)ResponseType.Ok)
        {
            Application.Quit();
            a.RetVal = false;
            Msg.Destroy();
        }
        else
        {
            a.RetVal = true;
            Msg.Destroy();
        }
    }
    protected void OnAbrirActivated(object sender, EventArgs e)
    {
        Editor.Abrir();
    }

    protected void OnNuevoDocumentoActivated(object sender, EventArgs e)
    {
        Editor.NuevaPagina();
    }

    protected void OnGuardarActivated(object sender, EventArgs e)
    {
        Editor.Guardar();
    }

    protected void OnHCopiarActivated(object sender, EventArgs e)
    {
        Editor.Copiar();
    }

    protected void OnHCortarActivated(object sender, EventArgs e)
    {
        Editor.Cortar();
    }

    protected void OnHPegarActivated(object sender, EventArgs e)
    {
        Editor.Pagar();
    }
    protected void OnOcultarHerramientasToggled(object sender, EventArgs e)
    {
        if (OcultarHerramientas.Label == "Ocultar Herramientas")
        {
            Herramientas.Visible = false;
            OcultarHerramientas.Label = "Mostrar Herramientas";
        }
        else
        {
            Herramientas.Visible = true;
            OcultarHerramientas.Label = "Ocultar Herramientas";
        }
    }

    protected void OnOcultarExploradorToggled(object sender, EventArgs e)
    {
        if (OcultarExplorador.Label == "Ocultar Explorador")
        {
            ScrollExplorador.Visible = false;
            OcultarExplorador.Label = "Mostrar Explorador";
        }
        else
        {
            ScrollExplorador.Visible = true;
            OcultarExplorador.Label = "Ocultar Explorador";
        }
    }

    protected void OnHGuardarComoActivated(object sender, EventArgs e)
    {
        //Editor.Guardar();
        Editor.GuardarComo();
    }

    protected void OnSalirActivated(object sender, EventArgs e)
    {
        MessageDialog Msg = new MessageDialog(this, DialogFlags.Modal,
                                              MessageType.Question,
                                              ButtonsType.OkCancel, "Salir?");
        if (Msg.Run() == (int)ResponseType.Ok)
        {
            Application.Quit();
            Msg.Destroy();
        }
        else
        {
            Msg.Destroy();
        }
    }

    protected void OnFindActionActivated(object sender, EventArgs e)
    {
        if (Pagina.Page >= 0)
        {
            if (Barra_de_Busqueda.Visible)
            {
                Barra_de_Busqueda.Visible = false;
            }
            else
            {
                Barra_de_Busqueda.Visible = true;
            }
        }
    }

    protected void OnBtnBusActivated(object sender, EventArgs e)
    {
        Editor.Buscar(Entrada.Text);
    }

    protected void OnExportarPDFActivated(object sender, EventArgs e)
    {
        if (Pagina.Page >= 0)
        {
            Editor.Exportar();
        }
    }

    protected void OnSeleccionarTodoActionActivated(object sender, EventArgs e)
    {
        Editor.SeleccionarTodo();
    }

    protected void OnDirectoriosChanged(object sender, EventArgs e)
    {
        Ra.Cargar_Archivos(Directorios.ActiveText);
    }

    protected void OnAcercaDeCodeSEActionActivated(object sender, EventArgs e)
    {
        ProcessStartInfo Start = new ProcessStartInfo();
        Start.FileName = "firefox";
        Start.Arguments = "https://github.com/Jeff94sl/CodeSyntaxEditor";
        Process Pro = new Process();
        Pro.StartInfo = Start;
        Pro.Start();
    }

    protected void OnCompilarActivated(object sender, EventArgs e)
    {
        Editor.Ejecutar(Consola);
    }

    protected void OnOcultarConsolaToggled(object sender, EventArgs e)
    {
        if (OcultarConsola.Label == "Ocultar Consola")
        {
            ScrollConsola.Visible = false;
            OcultarConsola.Label = "Mostrar Consola";
        }
        else
        {
            ScrollConsola.Visible = true;
            OcultarConsola.Label = "Ocultar Consola";
        }
    }

    protected void OnFuenteActionActivated(object sender, EventArgs e)
    {
        FontSelectionDialog Fuente = new FontSelectionDialog("Fuente");
        if (Fuente.Run() == (int)ResponseType.Ok)
        {
            Editor.Formato_de_Texto(Fuente.FontName);
            Fuente.Destroy();
        }
        Fuente.Destroy();
    }

    protected void OnGuardarComoActivated(object sender, EventArgs e)
    {
        Editor.GuardarComo();
    }
}