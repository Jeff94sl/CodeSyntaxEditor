//
//  OpenControlFunc.cs
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using Gtk;
using System.Linq;

public class OpenControlFunc : OpenControlEvent
{
    OpenControlDialog Dialg = new OpenControlDialog();
    OpenControlMessage Ms = new OpenControlMessage();
    OpenControlIO IO = new OpenControlIO();
    OpenControlTheme Th = new OpenControlTheme();

    public OpenControlFunc()
    {
    }

    public void Init()
    {
        Pagina.SwitchPage += OnPaginaSwitchPage;
    }

    public void NuevaPagina()
    {
        Scroll[index] = new ScrolledWindow();
        Texto[index] = new TextView();

        Texto[index].Name = index.ToString();
        Texto[index].Buffer.InsertText += Buffer_InsertText;
        Texto[index].Editable = true;

        Texto[index].ModifyFont(Pango.FontDescription.FromString("Monospace 12"));
        Texto[index].ShowAll();
        Scroll[index].Add(Texto[index]);
        Scroll[index].ShowAll();

        Etiqueta[index] = new Label();
        Etiqueta[index].LabelProp = "Pagina " + index;
        Etiqueta[index].ShowAll();

        Pagina.Add(Scroll[index]);
        Pagina.SetTabLabel(Scroll[index], Etiqueta[index]);
        Pagina.Page = index;
        index++;
        Nuevo[index] = true;
        Guardado[index] = false;
        Modificado[index] = false;
    }

    public void Titulo()
    {
        Etiqueta[Pagina.Page].LabelProp = Ext.SafeFileName(Dialg.Fc);
        Etiqueta[Pagina.Page].ShowAll();
        Pagina.SetTabLabel(Scroll[Pagina.Page], Etiqueta[Pagina.Page]);
    }

    public void Abrir()
    {
        try
        {
            Dialg.Fc = new FileChooserDialog("Abrir", win, FileChooserAction.Open,
                                                         "Abrir", ResponseType.Accept,
                                                         "Cancelar", ResponseType.Close);
            Ext.ObtExtencionAbrir(Dialg.Fc);
            if (Dialg.Fc.Run() == (int)ResponseType.Accept)
            {
                NuevaPagina();
                Dialg.Paths.Add(Dialg.Fc.Filename);

                IO.Leer = File.OpenText(Dialg.Fc.Filename);
                Titulo();
                Texto[count].Buffer.Text = IO.Leer.ReadToEnd();
                IO.Leer.Close();
                //Guardado = true;
                Dialg.Fc.Destroy();
                Nuevo[count] = false;
                Modificado[count] = false;
                Guardado[count] = true;
            }
            else
            {
                Dialg.Fc.Destroy();
            }
        }
        catch (Exception Ex)
        {
            Ms.MsgBoxWarning(Ex.Message);
        }
    }

    public void Guardar()
    {
        try
        {
            if (Guardado[count] == false)
            {
                GuardarComo();
            }
            else if(Guardado[count] == true)
            {
                IO.Escribir = File.CreateText(Dialg.Paths[Pagina.Page]);
                IO.Escribir.WriteLine(Texto[count].Buffer.Text);
                IO.Escribir.Close();
                Ms.MsgBoxInfo("Guardado!!");
            }
        }
        catch (Exception Ex)
        {
            Ms.MsgBoxWarning(Ex.Message);
        }
    }

    public void GuardarComo()
    {
        try
        {
            Dialg.Fc = new FileChooserDialog("Guardar", win, FileChooserAction.Save,
                                                         "Guardar", ResponseType.Accept,
                                                         "Cancelar", ResponseType.Close);
            Ext.ObtExtencion(Dialg.Fc);
            if (Dialg.Fc.Run() == (int)ResponseType.Accept)
            {
                Dialg.Paths.Add(Dialg.Fc.Filename);
                IO.Escribir = File.CreateText(Dialg.Paths[Pagina.Page]);
                IO.Escribir.WriteLine(Texto[count].Buffer.Text);
                IO.Escribir.Close();
                Titulo();
                Dialg.Fc.Destroy();
                Ms.MsgBoxInfo("Guardado!!");
                Nuevo[count] = false;
                Modificado[count] = false;
                Guardado[count] = true;
            }
            else
            {
                Dialg.Fc.Destroy();
                Guardado[count] = false;
            }
        }
        catch (Exception Ex)
        {
            Ms.MsgBoxWarning(Ex.Message);
        }
    }

    public void Copiar()
    {
        Texto[count].Buffer.CopyClipboard(Clip);
    }

    public void Cortar()
    {
        Texto[count].Buffer.CutClipboard(Clip, true);
    }

    public void Pagar()
    {
        Texto[count].Buffer.PasteClipboard(Clip);
    }

    public void SeleccionarTodo()
    {
        TextIter Iter;
        Iter = Texto[count].Buffer.StartIter;
        Texto[count].Buffer.SelectRange(Iter.Buffer.StartIter, Iter.Buffer.EndIter);
    }

    public void Buscar(string palabra)
    {
        //int Inicio = 0;
        //int Final = 0;
        //TextIter Iter_Ini, Iter_Fin, Iter;
        //Final = Texto[count].Buffer.Text.LastIndexOf(palabra);
        MatchCollection Mc = Regex.Matches(Texto[count].Buffer.Text, palabra,RegexOptions.Multiline);
        /*while (Inicio < Final)
        {
            /*Iter = Texto[Pagina.Page].Buffer.StartIter;
            Iter.ForwardSearch(palabra, TextSearchFlags.TextOnly, out Iter_Ini, out Iter_Fin, Texto[Pagina.Page].Buffer.EndIter);
            Texto[count].IsFocus = true;
            Texto[count].Buffer.PlaceCursor(Iter_Fin);
            Texto[count].Buffer.SelectRange(Iter_Ini, Iter_Fin);
            Texto[count].ScrollToIter(Iter_Fin, 0, false, 0, 0);
            Inicio = Texto[count].Buffer.Text.IndexOf(palabra, Inicio) + 1;
        }*/
        foreach(Match m in  Mc){
            
        }
    }

    public void EliminarPestaña()
    {
        if (Pagina.Page >= 0)
        {
            Menu PoupMenu = new Menu();
            ImageMenuItem Item = new ImageMenuItem("Cerrar");
            Gtk.Image Img = new Gtk.Image(Stock.Quit, IconSize.Menu);

            Item.Image = Img;
            Item.Activated += delegate {
                if(Modificado[count]== true){
                    MessageDialog messageDialog = new MessageDialog(win, DialogFlags.Modal, 
                                                                    MessageType.Question, 
                                                                    ButtonsType.YesNo, 
                                                                    "Archivo Modificado Desae Guardar?");
                    if(messageDialog.Run()== (int)ResponseType.Yes){
                        Guardar();
                        messageDialog.Destroy();
                        Pagina.RemovePage(Pagina.Page);
                        if (index > -1){
                            index--;
                        }
                    }else{
                        messageDialog.Destroy();
                        Pagina.RemovePage(Pagina.Page);
                        if(index > -1){
                            index--;
                        }
                    }
                }else{
                    Pagina.RemovePage(Pagina.Page);
                    index--;
                }
            };
            PoupMenu.Add(Item);
            PoupMenu.ShowAll();
            PoupMenu.Popup();
        }
    }

    public void Ejecutar(TextView Cons)
    {
        SwitcherBuild Sb = new SwitcherBuild();
        string error = "";
        Sb.Building(Ext.getExten(Etiqueta[count]), Dialg.Paths[count],null,out error);
        Cons.Buffer.Text = error;
    }

    public void Formato_de_Texto(string Fuente){
        Texto[count].ModifyFont(Pango.FontDescription.FromString(Fuente));
    }
    public void Exportar()
    {
        try
        {
            Dialg.Fc = new FileChooserDialog("Exportar PDF", win,
                                                         FileChooserAction.Save,
                                                         "Exportar", ResponseType.Accept,
                                                         "Cancelar", ResponseType.Close);
            if (Dialg.Fc.Run() == (int)ResponseType.Accept)
            {
                Document Document = new Document(PageSize.LETTER);
                PdfWriter Escr = PdfWriter.GetInstance(Document, new FileStream(Dialg.Fc.Filename, FileMode.Create));

                Document.AddTitle(Etiqueta[count].Text);
                Document.AddCreator(System.Environment.UserName);
                Document.Open();
                Font Fuente = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL, BaseColor.BLACK);

                Document.Add(new Paragraph(Texto[count].Buffer.Text));

                Document.Close();
                Escr.Close();
                Dialg.Fc.Destroy();
                Ms.MsgBoxInfo("Completado");
            }
            else
            {
                Dialg.Fc.Destroy();
            }
        }
        catch (Exception Ex)
        {
            Ms.MsgBoxWarning(Ex.Message);
        }
    }
}