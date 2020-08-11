using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;

using OfficeOpenXml.DataValidation;
using OfficeOpenXml.DataValidation.Contracts;
using System.Drawing;
using OfficeOpenXml.ConditionalFormatting;
using System.Text.RegularExpressions;

namespace Resources.Util
{
    public class Excel_Epplus
    {
        public string Path { get; set; }
        public string Hoja { get; set; }

        public Excel_Epplus(string path)
        {
            Path = path;
        }

        public ExcelWorksheet getHoja()
        {
            try
            {
                ExcelPackage pck = abrirArchivo();
                ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];
                return ws;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ExcelPackage abrirArchivo()
        {
            if (Path != "")
            {
                FileInfo newFile = new FileInfo(Path);
                ExcelPackage pck = new ExcelPackage(newFile);
                return pck;
            }
            else
            {
                return null;
            }
        }

        private bool eliminarArchivo()
        {
            try
            {
                FileInfo newFile = new FileInfo(Path);
                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(Path);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool guardarArchivo(ExcelPackage pck)
        {
            try
            {
                pck.Save();
                pck.Dispose();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Por borrar
        public bool FormatoCondicional(string rango)
        {
            ExcelPackage pck = abrirArchivo();
            ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];
            ExcelAddress cfAddress1 = new ExcelAddress(rango);

            var cfRule1 = ws.ConditionalFormatting.AddTwoColorScale(cfAddress1);

            // Now, lets change some properties:
            cfRule1.LowValue.Type = eExcelConditionalFormattingValueObjectType.Num;
            cfRule1.LowValue.Value = 4;
            cfRule1.LowValue.Color = Color.FromArgb(0xFF, 0xFF, 0xEB, 0x84);
            cfRule1.HighValue.Type = eExcelConditionalFormattingValueObjectType.Formula;
            cfRule1.HighValue.Formula = "IF($G$1=\"A</x:&'cfRule>\",1,5)";
            cfRule1.StopIfTrue = true;
            cfRule1.Style.Font.Bold = true;
            if (guardarArchivo(pck))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool AgregarValidacionReplicar(List<string> valores, int Columna, string range, int alternado, string hoja, int filaInicio)
        {
            try
            {
                string formula = AgregarValidacion(valores, Columna, range, hoja);
                if (formula != "")
                {
                    return ReplicarFormula(range, alternado, hoja, filaInicio, formula);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ReplicarFormula(string rango, int alternado, string hoja, int filaInicio, string formula)
        {
            string strColumna = Regex.Match(rango, @"[A-Z]+").Value;
            try
            {
                ExcelPackage pck = abrirArchivo();
                ExcelWorksheet ws = pck.Workbook.Worksheets[hoja];
                if (ws == null)
                {
                    crearHoja();
                    pck = abrirArchivo();
                    ws = pck.Workbook.Worksheets[hoja];
                }
                int cantidadFilas = ws.Dimension.End.Row;
                for (int i = filaInicio + alternado; i <= cantidadFilas; i = i + alternado)
                {
                    string rangoDestino = strColumna + i;
                    var validacion = ws.DataValidations.AddListValidation(rangoDestino);
                    validacion.ShowErrorMessage = true;
                    validacion.Formula.ExcelFormula = formula;
                }
                if (guardarArchivo(pck))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string AgregarValidacion(List<string> valores, int Columna, string range, string hoja)
        {
            string rangoFormula = agregarListados(valores, Columna);
            try
            {
                if (valores.Count() > 0)
                {
                    ExcelPackage pck = abrirArchivo();
                    ExcelWorksheet ws = pck.Workbook.Worksheets[hoja];
                    if (ws == null)
                    {
                        crearHoja();
                        pck = abrirArchivo();
                        ws = pck.Workbook.Worksheets[hoja];
                    }

                    //var range = ExcelRange.GetAddress(2, Columna, ExcelPackage.MaxRows, Columna);
                    var validacion = ws.DataValidations.AddListValidation(range);
                    validacion.ShowErrorMessage = true;
                    var formula = rangoFormula; //  "=Listados!B1:B43";
                    validacion.Formula.ExcelFormula = formula;
                    if (guardarArchivo(pck))
                    {
                        return formula;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AgregarValidacion(List<string> valores, int Columna)
        {
            string rangoFormula = agregarListados(valores, Columna);
            try
            {
                if (valores.Count() > 0)
                {
                    ExcelPackage pck = abrirArchivo();
                    ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];
                    if (ws == null)
                    {
                        crearHoja();
                        pck = abrirArchivo();
                        ws = pck.Workbook.Worksheets[Hoja];
                    }

                    var range = ExcelRange.GetAddress(2, Columna, ExcelPackage.MaxRows, Columna);
                    var validacion = ws.DataValidations.AddListValidation(range);
                    validacion.ShowErrorMessage = true;
                    var formula = rangoFormula; //  "=Listados!B1:B43";
                    validacion.Formula.ExcelFormula = formula;
                    if (guardarArchivo(pck))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Agrega un listado de validaciones en una hoja especifica 
        /// </summary>
        /// <param name="valores">Lista con valores </param>
        /// <param name="Columna">Columna a validar</param>
        /// <param name="hoja">hoja donde se agregan las validaciones</param>
        /// <param name="filaInicio">Fila de inicio de inserción</param>
        /// <param name="alternado">Cuantas filas dejar de espacio entre nombres</param>
        /// <returns></returns>       
        public bool AgregarValidacion(List<string> valores, int Columna, string hoja, int filaInicio, int alternado)
        {
            int pareja = 1, sw = 1;
            string rangoFormula = agregarListados(valores, Columna, hoja);
            try
            {
                if (valores.Count() > 0)
                {
                    ExcelPackage pck = abrirArchivo();
                    ExcelWorksheet ws = pck.Workbook.Worksheets[hoja];
                    if (ws == null)
                    {
                        crearHoja();
                        pck = abrirArchivo();
                        ws = pck.Workbook.Worksheets[hoja];
                    }

                    int fila = filaInicio;
                    string range = "";
                    foreach (var item in valores)
                    {
                        if (item != "")
                        {
                            range = GetExcelColumnName(Columna) + fila;
                            ws.Cells[range].Value = item.ToUpper();
                            //ws.Cells[fila,Columna].Value = item.ToUpper();
                            if (sw == 1) { ws.Cells[fila, Columna - 1].Value = pareja; } //Indicar numero de pareja 
                            var validacion = ws.DataValidations.AddListValidation(range);
                            validacion.ShowErrorMessage = true;
                            var formula = rangoFormula; //  "=Listados!B1:B43";
                            validacion.Formula.ExcelFormula = formula;

                            fila = fila + alternado;
                            if (sw == 1) { sw = 0; } else { sw = 1; pareja++; }
                        }
                    }

                    if (guardarArchivo(pck))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Crea una hoja indicada en la propiedad Hoja de Epplus 
        /// </summary>
        /// <returns>true o false</returns>
        public bool crearHoja()
        {
            try
            {
                // ExcelWorksheet ws = pck.Workbook.Worksheets.Add(etapas.NombreEtapa.Trim());
                ExcelPackage pck = abrirArchivo();
                pck.Workbook.Worksheets.Add(Hoja);
                guardarArchivo(pck);
                return true;
            }
            catch (InvalidOperationException)
            {
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Crea varias hojas al abrir el libro
        /// </summary>
        /// <param name="hojas">Listado con nombre para las hojas</param>
        /// <returns>true o false </returns>
        public bool CrearHojas(List<string> hojas)
        {
            try
            {
                ExcelPackage pck = abrirArchivo();
                foreach (var hoja in hojas.Distinct())
                {
                    pck.Workbook.Worksheets.Add(hoja);
                }
                guardarArchivo(pck);
                return true;
            }
            catch (InvalidOperationException)
            {
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string getNombreHoja(string NombreHoja)
        {
            if (NombreHoja.Length > 15)
            {
                NombreHoja = NombreHoja.Substring(0, 15);
            }
            return NombreHoja;
        }

        public void agregarValidacionLargoTexto(int Columna, int minLength, int maxLength)
        {
            ExcelPackage pck = abrirArchivo();
            ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];

            //var minLength = 1;
            //var maxLength = 4;
            var rangeLargo = ExcelRange.GetAddress(2, Columna, ExcelPackage.MaxRows, Columna);
            var textValidation = ws
                .DataValidations.AddTextLengthValidation(rangeLargo);
            textValidation.ShowErrorMessage = true;
            textValidation.ErrorStyle = ExcelDataValidationWarningStyle.stop;
            textValidation.ErrorTitle = "The value you entered is not valid";
            textValidation.Error = string.Format(
                "This cell must be between {0} and {1} characters in length.",
                minLength, maxLength
            );
            textValidation.Formula.Value = minLength;
            textValidation.Formula2.Value = maxLength;

            guardarArchivo(pck);
        }

        public bool agregarTitulos(List<string> titulos)
        {
            try
            {
                if (titulos.Count() > 0)
                {
                    ExcelPackage pck = abrirArchivo();
                    ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];

                    if (ws == null)
                    {
                        crearHoja();
                        pck = abrirArchivo();
                        ws = pck.Workbook.Worksheets[Hoja];
                    }
                    int columna = 1;
                    foreach (var item in titulos)
                    {
                        if (item != null)
                        {
                            ws.Cells[1, columna].Value = item.ToString();
                            ws.Cells[1, columna].Style.Font.Bold = true;
                            ws.Cells[1, columna].AutoFitColumns();

                        }

                        columna++;
                    }
                    if (guardarArchivo(pck))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Agrega lineas en el excel
        /// </summary>
        /// <param name="Linea">Texto a ingresar</param>
        /// <param name="fila">Fila donde inicia</param>
        /// <param name="columnaInicio">columna donde parte escribiendo</param>
        /// <param name="columnaLimite">Reinicia el contador de columna</param>
        /// <returns></returns>
        public bool AgregarLinea(List<string> Linea, int fila, int columnaInicio, int columnaLimite)
        {
            try
            {
                if (Linea.Count() > 0)
                {
                    ExcelPackage pck = abrirArchivo();
                    ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];
                    if (ws == null)
                    {
                        crearHoja();
                        pck = abrirArchivo();
                        ws = pck.Workbook.Worksheets[Hoja];
                    }
                    int columna = columnaInicio;
                    foreach (var item in Linea)
                    {
                        if (item != null)
                        {
                            ws.Cells[fila, columna].Value = item.ToString();
                            if (item.Length < 50) { ws.Cells[fila, columna].AutoFitColumns(); }
                        }
                        if (columna == columnaLimite) { columna = columnaInicio; } else { columna++; }

                    }
                    if (guardarArchivo(pck)) { return true; } else { return false; }

                }
                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool agregarLinea(List<string> Linea, int fila)
        {
            try
            {
                if (Linea.Count() > 0)
                {
                    ExcelPackage pck = abrirArchivo();
                    ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];
                    if (ws == null)
                    {
                        crearHoja();
                        pck = abrirArchivo();
                        ws = pck.Workbook.Worksheets[Hoja];
                    }
                    int columna = 1;
                    foreach (var item in Linea)
                    {
                        if (item != null)
                        {
                            ws.Cells[fila, columna].Value = item.ToString();
                            if (item.Length < 50) { ws.Cells[fila, columna].AutoFitColumns(); }
                        }
                        columna++;
                    }
                    if (guardarArchivo(pck)) { return true; } else { return false; }

                }
                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool AgregarLineaColumna(List<string> Linea, int fila, int columna)
        {
            try
            {
                if (Linea.Count() > 0)
                {
                    ExcelPackage pck = abrirArchivo();
                    ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];
                    if (ws == null)
                    {
                        crearHoja();
                        pck = abrirArchivo();
                        ws = pck.Workbook.Worksheets[Hoja];
                    }
                    foreach (var item in Linea)
                    {
                        if (item != null)
                        {

                            ws.Cells[fila, columna].Value = item.ToString();
                            if (item.Length < 50)
                            {
                                ws.Cells[fila, columna].AutoFitColumns();
                            }
                        }
                    }
                    if (guardarArchivo(pck))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Agrega lineas de texto a una columna y fila indicada
        /// </summary>
        /// <param name="Linea">Lista de textos a ingresar</param>
        /// <param name="fila">Fila donde se ingresara el primer texto</param>
        /// <param name="columna">Columna donde se ingresara el texto</param>
        /// <param name="hoja">Hoja donde se ingresaran los textos</param>
        /// <param name="salto">Cantidad de filas que se saltara una vez completado un loop</param>
        /// <param name="repeticion">Si se repite una vez terminado el primer loop</param>
        /// <returns></returns>
        public bool AgregarLineaColumna(List<string> Linea, int fila, int columna, string hoja, int salto)
        {
            try
            {
                if (Linea.Count() > 0)
                {
                    ExcelPackage pck = abrirArchivo();
                    ExcelWorksheet ws = pck.Workbook.Worksheets[hoja];
                    if (ws == null)
                    {
                        crearHoja();
                        pck = abrirArchivo();
                        ws = pck.Workbook.Worksheets[hoja];
                    }
                    int cantidadFilas = ws.Dimension.End.Row;
                    //int contador = 1;
                    int cantidadFilasLinea = cantidadFilas + Linea.Count();
                    for (int i = 0; i < Linea.Count(); i++)
                    {
                        ws.Cells[fila, columna].Value = Linea[i].ToString();
                        //if (Linea[i].Length < 50)
                        //{
                        //    ws.Cells[fila,columna].AutoFitColumns();
                        //}
                        if (i == Linea.Count() - 1) { i = -1; fila = fila + salto; }
                        if (fila > cantidadFilasLinea)
                        {
                            break;
                        }
                        else { fila++; }
                        //contador++;
                    }

                    if (guardarArchivo(pck))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void removerValidaciones()
        {

            ExcelPackage pck = abrirArchivo();
            ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];

            var validations = ws.DataValidations;
            validations.Clear();
            guardarArchivo(pck);

        }

        private bool tieneValidaciones()
        {
            ExcelPackage pck = abrirArchivo();
            ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];

            int validations = ws.DataValidations.Count();
            if (validations > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ocultarHojas()
        {
            ExcelPackage pck = abrirArchivo();
            ExcelWorksheet ws = pck.Workbook.Worksheets["Listados"];
            ws.Hidden = OfficeOpenXml.eWorkSheetHidden.Hidden;
            guardarArchivo(pck);
        }

        private string agregarListados(List<string> valores, int Columna, string hoja)
        {
            string hojaCustom = hoja.Replace(" ", "") + "cm";
            var listaDistinct = valores.Distinct();
            string columnaLetra = GetExcelColumnName(Columna);
            string resultado = "";
            ExcelPackage pck = abrirArchivo();
            ExcelWorksheet ws = pck.Workbook.Worksheets[hojaCustom];
            if (ws == null)
            {
                pck.Workbook.Worksheets.Add(hojaCustom);
                ws = pck.Workbook.Worksheets[hojaCustom];
            }

            if (listaDistinct.Count() > 0)
            {
                int fila = 1;
                foreach (var item in listaDistinct)
                {
                    ws.Cells[fila, Columna].Value = item.ToUpper().ToString();
                    fila++;
                }
                ws.Hidden = OfficeOpenXml.eWorkSheetHidden.Hidden;
                guardarArchivo(pck);
                resultado = "=" + hojaCustom + "!" + columnaLetra + "1:" + columnaLetra + fila;
            }
            return resultado;
        }


        private string agregarListados(List<string> valores, int Columna)
        {
            var listaDistinct = valores.Distinct();
            string columnaLetra = GetExcelColumnName(Columna);
            string resultado = "";
            ExcelPackage pck = abrirArchivo();
            ExcelWorksheet ws = pck.Workbook.Worksheets["Listados"];
            if (ws == null)
            {
                pck.Workbook.Worksheets.Add("Listados");
                ws = pck.Workbook.Worksheets["Listados"];
                ws.Hidden = OfficeOpenXml.eWorkSheetHidden.Hidden;
            }

            if (listaDistinct.Count() > 0)
            {
                int fila = 1;
                foreach (var item in listaDistinct)
                {
                    ws.Cells[fila, Columna].Value = item.ToString();
                    fila++;
                }
                guardarArchivo(pck);
                resultado = "=Listados!" + columnaLetra + "1:" + columnaLetra + fila;
            }
            return resultado;
        }

        public string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        public void formatoMoneda(int Columna)
        {
            string strColumna = GetExcelColumnName(Columna);
            string rango = strColumna + "2:" + strColumna;
            try
            {
                ExcelPackage pck = abrirArchivo();
                ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];
                foreach (var cell in ws.Cells[rango])
                {
                    cell.Value = Convert.ToDecimal(cell.Value);
                }
                //ws.Cells[1, Columna, ExcelPackage.MaxRows, Columna].Style.Numberformat.Format = "$#,##0";
                ws.Cells[rango].Style.Numberformat.Format = "$#,##0";
                guardarArchivo(pck);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Repite un comentario en una fila hasta el maximo de columnas de la hoja 
        /// </summary>
        /// <param name="comentario">Texto a ingresar en el comentario</param>
        /// <param name="fila">Fila donde se repetira el comentario</param>
        /// <returns></returns>
        public bool agregarComentarios(string comentario, int columnaInicio, int fila)
        {
            try
            {
                if (comentario != "")
                {
                    ExcelPackage pck = abrirArchivo();
                    ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];
                    int cantidadColumnas = ws.Dimension.End.Column;
                    if (ws == null)
                    {
                        crearHoja();
                        pck = abrirArchivo();
                        ws = pck.Workbook.Worksheets[Hoja];
                    }
                    for (int columna = columnaInicio; columna <= cantidadColumnas; columna++)
                    {
                        var comTipo = ws.Cells[fila, columna].AddComment(comentario, "FEPASA");
                        comTipo.Font.Bold = true;
                        comTipo.AutoFit = true;
                    }
                    if (guardarArchivo(pck))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool agregarComentarios(List<string> lista)
        {
            try
            {
                if (lista.Count() > 0)
                {
                    ExcelPackage pck = abrirArchivo();
                    ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];

                    if (ws == null)
                    {
                        crearHoja();
                        pck = abrirArchivo();
                        ws = pck.Workbook.Worksheets[Hoja];
                    }
                    int columna = 1;
                    foreach (var item in lista)
                    {
                        if (item != null)
                        {
                            var comTipo = ws.Cells[1, columna].AddComment(item.ToString(), "Extranet");
                            comTipo.Font.Bold = true;
                            comTipo.AutoFit = true;
                        }

                        columna++;
                    }
                    if (guardarArchivo(pck))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool agregarPar(List<KeyValuePair<string, string>> par)
        {
            int contadorPar = par.Count();
            if (contadorPar > 0)
            {
                ExcelPackage pck = abrirArchivo();
                ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];
                if (ws == null)
                {
                    crearHoja();
                    pck = abrirArchivo();
                    ws = pck.Workbook.Worksheets[Hoja];
                    ws.Hidden = OfficeOpenXml.eWorkSheetHidden.Hidden;
                }
                // int fila = ws.Dimension.End.Row;
                int fila = 1;
                foreach (var item in par)
                {
                    if (item.Key != null && item.Value != null)
                    {
                        ws.Cells[fila, 1].Value = item.Key.ToString();
                        ws.Cells[fila, 2].Value = getNombreHoja(item.Value.ToString());
                    }
                    fila++;
                }
                if (guardarArchivo(pck))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public void ocultarColumna(int Columna)
        {
            ExcelPackage pck = abrirArchivo();
            ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];
            ws.Column(Columna).Hidden = true;
            pck.Save();
        }

        public void columnaFormatoNumero(int columna)
        {
            ExcelPackage pck = abrirArchivo();
            ExcelWorksheet ws = pck.Workbook.Worksheets[Hoja];
            ws.Column(columna).Style.Numberformat.Format = "0";
            pck.Save();
        }

    }


}
