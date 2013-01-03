using System;
using System.Text;

namespace MicroBSC.Common
{
	/// <summary>
	/// Pager에 관한 내용입니다.
	/// </summary>
	public class Pager
	{
		private string			_pagePath;
		private StringBuilder	sb;

		/// <summary>
		/// Pager 클래스의 생성자입니다.
		/// </summary>
		/// <param name="pagePath"></param>
		public Pager( string pagePath )
		{
			_pagePath = pagePath;
		}
		
		/// <summary>
		/// 페이징 html 태그를 반환하는 메소드
		/// </summary>
		/// <param name="RequestPage">요청페이지</param>
		/// <param name="PageCount">페이지수</param>
		/// <param name="IsPathExtended">쿼리스트링 확장 여부</param>
		/// <param name="BeginStr">10개 전 페이지</param>
		/// <param name="BackStr">전 페이지</param>
		/// <param name="NextStr">다음 페이지</param>
		/// <param name="EndStr">10개 다음 페이지</param>
		/// <returns>html 태그 반환</returns>
		public string GetExtendedPager(int RequestPage,int PageCount,bool IsPathExtended,string BeginStr,string BackStr,string NextStr,string EndStr)
		{
			sb = new StringBuilder();
			string Path = _pagePath;
			int MinValue = 1;
			int MaxValue = PageCount +1;								//마지막 번호
			
			int StartValue = RequestPage - ((RequestPage-1) % 10);		// 시작 번호
			int EndValue = StartValue + 10;								// 끝 번호

			if( EndValue > MaxValue )
				EndValue = MaxValue;

			if( StartValue - 10 >= MinValue )
				sb.Append( GetExtendLinkStyle(Path,StartValue - 10,BeginStr,IsPathExtended) );

			if( RequestPage - 1 >= MinValue )
				sb.Append( GetExtendLinkStyle(Path,RequestPage - 1,BackStr,IsPathExtended) );

			for (int i = StartValue;i < EndValue;i++) 
			{
				if( i == RequestPage ) 
					sb.Append( GetFontStyle( "#525252", i.ToString() , true ) );
				else 
					sb.Append( GetLinkStyle( Path , i.ToString() , IsPathExtended ) );
			}

			if( RequestPage + 1 < MaxValue )
				sb.Append( GetExtendLinkStyle(Path,RequestPage + 1,NextStr,IsPathExtended) );

			if( StartValue + 10 < MaxValue )
				sb.Append( GetExtendLinkStyle(Path,StartValue + 10,EndStr,IsPathExtended) );

			return sb.ToString();
		}

		private string GetFontStyle( string Color, string TextValue, bool IsBolt ) 
		{
			if( IsBolt )
				return "[<font color='" + Color + "'><b>" + TextValue + "</b></font>]";

			return "[<font color='" + Color + "'>" + TextValue + "</font>]";
		}

		private string GetLinkStyle( string Src, string TextValue, bool IsPathExtended ) 
		{
			if( IsPathExtended )
				return "<a href='" + Src + "&PAGE=" + TextValue + "'>" + GetFontStyle( "#666699", TextValue, false) + "</a>";

			return "<a href='" + Src + "?PAGE=" + TextValue + "'>" + GetFontStyle( "#666699", TextValue, false) + "</a>";
		}

		private string GetExtendLinkStyle( string Src, int MovePage, string TextValue, bool IsPathExtended ) 
		{
			if( IsPathExtended )
				return "<a href='" + Src + "&PAGE=" + MovePage.ToString() + "' onfocus='this.blur();'> " + TextValue + " </a>";

			return "<a href='" + Src + "?PAGE=" + MovePage.ToString() + "' onfocus='this.blur();'> " + TextValue + " </a>";
		}
	}
}
