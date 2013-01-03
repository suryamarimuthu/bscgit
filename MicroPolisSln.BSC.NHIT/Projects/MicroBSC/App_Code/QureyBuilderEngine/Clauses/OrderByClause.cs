using System;
using System.Collections.Generic;
using System.Text;
using MicroBSC.QueryEngine.QueryBuilder.Enums;

//
// Class: OrderByClause
// Copyright 2006 by Ewout Stortenbeker
// Email: 4ewout@gmail.com
//
// This class is part of the CodeEngine Framework.
// You can download the framework DLL at http://www.code-engine.com/
//
namespace MicroBSC.QueryEngine.QueryBuilder
{
    /// <summary>
    /// Represents a ORDER BY clause to be used with SELECT statements
    /// </summary>
    public struct OrderByClause
    {
        public string FieldName;
        public Sorting SortOrder;
        public OrderByClause(string field)
        {
            FieldName = field;
            SortOrder = Sorting.Ascending;
        }
        public OrderByClause(string field, Sorting order)
        {
            FieldName = field;
            SortOrder = order;
        }
    }

    public struct QueryOperator
    {
        public const string Digit1 = "1";
        public const string Digit2 = "2";
        public const string Digit3 = "3";
        public const string Digit4 = "4";
        public const string Digit5 = "5";
        public const string Digit6 = "6";
        public const string Digit7 = "7";
        public const string Digit8 = "8";
        public const string Digit9 = "9";
        public const string Digit0 = "0";
        public const string DigitPoint = ".";
        public const string DigitComma = ",";

        public const string ArithOperPlus     = " + ";
        public const string ArithOperMinus    = " - ";
        public const string ArithOperDivide   = " / ";
        public const string ArithOperMultiply = " * ";

        public const string CompOperEqual    = " = ";
        public const string CompOperNotEqual = " != ";
        public const string CompOperGrater   = " > ";
        public const string CompOperLower    = " < ";
        public const string CompOperMoreThen = " >= ";
        public const string CompOperLessThen = " <= ";
        public const string CompOperPercent  = " % ";

        public const string LogicOperAnd      = " AND ";
        public const string LogicOperOr       = " OR ";
        public const string LogicOperLike     = " LIKE ";
        public const string LogicOperBetween  = " BETWEEN ";
        
        public const string RParenthesis = ")";
        public const string LParenthesis = "(";
        public const string RBracket = "}";
        public const string LBracket = "{";
        public const string QuotationMark = "'";
        public const string Concatenation = "||";

        public const string AggFuncSum   = "SUM";
        public const string AggFuncABS   = "ABS";
        public const string AggFuncAVG   = "AVG";
        public const string AggFuncMAX   = "MAX";
        public const string AggFuncMIN   = "MIN";
        public const string AggFuncCOUNT = "COUNT";
        public const string AggFuncROUND = "ROUND";
        public const string AggFuncTRUNC = "TRUNC";

        public const string QryCluseSelect  = " SELECT ";
        public const string QryCluseFrom    = " FROM ";
        public const string QryCluseWhere   = " WHERE ";
        public const string QryCluseGroupBy = " GROUP BY ";
        public const string QryCluseHaving  = " HAVING ";

        public const string QryCluseTable   = " BSC_INTERFACE_DATA ";

        public const string ParamFirstYmd      = "@F_YMD";
        public const string ParamCurrYmd       = "@C_YMD";
        public const string ParamPrevYmd       = "@P_YMD";
        public const string ParamNextYmd       = "@N_YMD";
        public const string ParamLastYmd       = "@L_YMD";
    }
}
