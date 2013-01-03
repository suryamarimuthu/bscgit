using System;

using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Data;

public enum DataFileFormat
{
    Excel2000,
}

/// <summary>
/// ExcelHandler의 요약 설명입니다.
/// </summary>
public class ExcelHandler
{
    public ExcelHandler()
    {
    }

    //public static void ConvertToExcelFile(System.Data.DataTable source, string excelFilePath)
    //{
    //    ADODB.Recordset rs = ConvertToRecordSet(source);
    //    ExportRecordsetToFile(rs, excelFilePath, DataFileFormat.Excel2000, source.TableName);
    //}

    //// Recordset --> Excel2000, Text, CSV
    //public static void ExportRecordsetToFile(Recordset rs, string targetFilePath,
    //    DataFileFormat targetFileFormat, string srcTableName)
    //{
    //    switch (targetFileFormat)
    //    {
    //        case DataFileFormat.Excel2000:
    //            ExportRecordsetToExcel2000(rs, targetFilePath, srcTableName);
    //            break;
    //    }
    //}

    //// Recordset --> Excel2000
    //private static void ExportRecordsetToExcel2000(Recordset rs, string filePath,
    //    string srcTableName)
    //{
    //    Excel._Application excel = new Excel.ApplicationClass();

    //    Excel.Workbooks workBooks = excel.Workbooks;
    //    Workbook book = workBooks.Add(Missing.Value);
    //    Marshal.ReleaseComObject(workBooks);

    //    Excel.Sheets workSheets = book.Worksheets;

    //    Worksheet sheet = (Worksheet)workSheets.get_Item(1);
    //    Marshal.ReleaseComObject(workSheets);

    //    if (srcTableName != null && srcTableName.Length > 0)
    //    {
    //        sheet.Name = srcTableName;
    //    }

    //    // 마지막 컬럼 이름 설정
    //    string lastColumnName = System.Convert.ToChar('A' + rs.Fields.Count - 1) + "1";

    //    // 각 컬럼이름의 배열 설정
    //    string[] fieldNames = new String[rs.Fields.Count];

    //    for (int index = 0; index < rs.Fields.Count; index++)
    //    {
    //        fieldNames[index] = rs.Fields[index].Name;
    //    }

    //    Excel.Range rangeField = sheet.get_Range("A1", lastColumnName);
    //    rangeField.Value2 = fieldNames;
    //    // sheet.get_Range( "A1", lastColumnName ).Value2 	= fieldNames;
    //    Marshal.ReleaseComObject(rangeField);


    //    /*
    //     * 
    //     *         // Add some styles to the Workbook
    //    m_style = m_objBook.Styles.Add("HeaderStyle", false);
    //    m_style.Font.Name = "Tahoma";
    //    m_style.Font.Size = 10;
    //    m_style.Font.Bold = true;
    //    m_style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
    //    m_style.Font.Color = "White";
    //    m_style.Interior.Color = "Gray";
    //    m_style.Interior.Pattern = StyleInteriorPattern.Solid;

    //    // Create the Default Style to use for everyone
    //    m_style = m_objBook.Styles.Add("Default", false);
    //    m_style.Font.Name = "Tahoma";
    //    m_style.Font.Size = 10;
    //     * 
    //    // 컬럼 이름의 폰트를 굵게 설정
    //    Excel.Range rangeFont = sheet.get_Range( "A1", lastColumnName );
    //    Excel.Font columnFont = rangeFont.Font;
    //    columnFont.Bold = true; // sheet.get_Range( "A1",lastColumnName ).Font.Bold = true;
    //    Marshal.ReleaseComObject( columnFont );
    //    Marshal.ReleaseComObject( rangeFont );
    //    */

    //    //Transfer the data to Excel
    //    Excel.Range rangeRecord = sheet.get_Range("A2", Missing.Value);
    //    rangeRecord.CopyFromRecordset(rs, Missing.Value, Missing.Value);
    //    // sheet.get_Range( "A2",Missing.Value ).CopyFromRecordset(	rs, Missing.Value, Missing.Value );
    //    Marshal.ReleaseComObject(rangeRecord);

    //    book.SaveCopyAs(filePath);
    //    book.Saved = true;

    //    excel.Quit();

    //    Marshal.ReleaseComObject(sheet);
    //    Marshal.ReleaseComObject(book);
    //    Marshal.ReleaseComObject(excel);
    //}

    //// DataTable --> Recordset
    //public static Recordset ConvertToRecordSet(System.Data.DataTable source)
    //{
    //    Recordset rs = new RecordsetClass() as Recordset;
    //    rs.CursorLocation = CursorLocationEnum.adUseClient;
    //    rs.CursorType = CursorTypeEnum.adOpenStatic;
    //    string[] fieldNames = new string[source.Columns.Count];
    //    int index = 0;

    //    foreach (DataColumn col in source.Columns)
    //    {
    //        fieldNames[index++] = col.ColumnName;
    //        rs.Fields.Append(col.ColumnName,
    //            GetFieldType(col.DataType),
    //            -1,
    //            FieldAttributeEnum.adFldUnspecified,
    //            null);
    //    }

    //    rs.Open(Missing.Value,
    //        Missing.Value,
    //        CursorTypeEnum.adOpenStatic,
    //        LockTypeEnum.adLockBatchOptimistic,
    //        -1);

    //    int length = source.Columns.Count;

    //    foreach (DataRow row in source.Rows)
    //    {
    //        rs.AddNew(Missing.Value, Missing.Value);
    //        for (index = 0; index < length; index++)
    //        {
    //            if (row[index] == null)
    //            {
    //                row[index] = " ";// string.Empty;
    //            }

    //            //rs.Fields[index].Value = row[index];
    //        }
    //    }

    //    return rs;
    //}

    //// Used by ( DataTable --> Recordset )
    //protected static DataTypeEnum GetFieldType(Type type)
    //{
    //    DataTypeEnum returnValue = DataTypeEnum.adVariant;

    //    switch (Type.GetTypeCode(type))
    //    {
    //        case TypeCode.Boolean:
    //            returnValue = DataTypeEnum.adBoolean;
    //            break;

    //        case TypeCode.Byte:
    //            returnValue = DataTypeEnum.adChar;
    //            break;

    //        case TypeCode.Char:
    //            returnValue = DataTypeEnum.adWChar;
    //            break;

    //        case TypeCode.DateTime:
    //            returnValue = DataTypeEnum.adDate;
    //            break;

    //        case TypeCode.Decimal:
    //            returnValue = DataTypeEnum.adDecimal;
    //            break;

    //        case TypeCode.Double:
    //            returnValue = DataTypeEnum.adDouble;
    //            break;

    //        case TypeCode.Int16:
    //            returnValue = DataTypeEnum.adSmallInt;
    //            break;

    //        case TypeCode.Int32:
    //            returnValue = DataTypeEnum.adInteger;
    //            break;

    //        case TypeCode.Int64:
    //            returnValue = DataTypeEnum.adBigInt;
    //            break;

    //        case TypeCode.Single:
    //            returnValue = DataTypeEnum.adSingle;
    //            break;

    //        case TypeCode.String:
    //            returnValue = DataTypeEnum.adVarChar;
    //            break;

    //        case TypeCode.UInt16:
    //            returnValue = DataTypeEnum.adUnsignedSmallInt;
    //            break;

    //        case TypeCode.UInt32:
    //            returnValue = DataTypeEnum.adUnsignedInt;
    //            break;

    //        case TypeCode.UInt64:
    //            returnValue = DataTypeEnum.adUnsignedBigInt;
    //            break;
    //    }

    //    return returnValue;
    //}
}
