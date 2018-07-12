//
//  OpenControlExten.cs
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

public class OpenControlExten
{
    public OpenControlExten()
    {

    }

    readonly string[] Ext = { "*.as", "*.applescript", "*.asa", "*.asp",
        "*.c", "*.bat", "*.cs", "*.build", "*.cpp", "*.clj", "*.css",
        "*.d", "*.diff", "*.erl", "*.yaws", "*.go", "*.dot",
        "*.groovy", "*.hs", "*.lhs", "*.html", "*.java",
        "*.properties", "*.jsp", "*.js", "*.json", "*.bib", "*.tex",
        "*.sty", "*.lisp", "*.lua", "*.make", "*.mdown",
        "*.matlab", "*.m", "*.mm", "*.ml", "*.mll", "*.mly",
        "*.pas", "*.pl", "*.php", "*.py", "*.r", "*.rd", "*.rails",
        "*.erb", "*.haml", "*.rxml", "*.erbsql", "*.re", "*.rst",
        "*.rb", "*.rs", "*.scala", "*.sh", "*.sql", "*.txt", "*.adp",
        "*.tcl", "*.textile", "*.xml", "*.yaml", "*.qml" };
    readonly string[] N_Exten = { "ActionScript", "AppleScript", "ASP",
        "ASP(HTML)", "C", "Batch", "C#", "C# NAnt Build File",
        "C++", "Clojure", "CSS", "D", "Diff", "Erlang", "Erlang(HTML)",
        "Go", "Graphviz", "Groovy", "Haskell", "Literate Haskell", "HTML",
        "Java", "Java Properties", "Java Server Page", "JavaScript", "JSON",
        "LaTeX(BibTeX)", "LaTeX", "TeX", "Lisp", "Lua", "Makefile", "Markdown",
        "MATLAB", "Objective-C", "Objective-C++", "OCaml", "OCamllex",
        "OCamlyacc", "Pascal", "Perl", "PHP", "Python", "R", "R Documentation",
        "HTML(Rails)", "Javascript(Rails)", "Ruby Haml", "Ruby On Rails",
        "SQL(Rails)", "Regular Expression", "reStructuredText", "Ruby",
        "Rust", "Scala", "Shell Script (Bash)", "SQL", "Texto Plano",
        "HTML(Tcl)", "TCL", "Textile", "XML", "Yaml", "QML" };

    public void ObtExtencion(FileChooser Fc)
    {
        FileFilter[] Fill = new FileFilter[1000];
        int I = 0;
        foreach (string e in Ext)
        {
            Fill[I] = new FileFilter();
            Fill[I].Name = Mono.Unix.Catalog.GetString(N_Exten[I]);
            Fill[I].AddPattern(e);
            Fc.AddFilter(Fill[I]);
            I++;
        }
    }

    public void ObtExtencionAbrir(FileChooser Fc)
    {
        FileFilter Fill = new FileFilter();
        Fill.Name = Mono.Unix.Catalog.GetString("Todo");
        foreach (string e in Ext)
        {
            Fill.AddPattern(e);
        }
        Fc.AddFilter(Fill);
    }

    public string SafeFileName(FileChooser File)
    {
        foreach (string s in File.Filename.Split('/'))
        {
            foreach (string item in Ext)
            {
                if (Regex.IsMatch(s, @"\A[A-z|a-z|A-Z|0-9]+(\.)+[a-z]{" + item.Remove(0, 2).Length + "}\\Z"))
                {
                    return s;
                }
            }
        }
        return null;
    }

    public string getExten(Label File)
    {
        foreach(string it in File.Text.Split('.')){
            foreach(string itm in Ext){
                if(it == itm.Remove(0,2)){
                    return it;
                }
            }
        }
        return null;
    }
}