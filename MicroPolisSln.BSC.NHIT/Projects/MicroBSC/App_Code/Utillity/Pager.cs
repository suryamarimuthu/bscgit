using System;
using System.Text;

namespace MicroBSC.Common
{
	/// <summary>
	/// Pager�� ���� �����Դϴ�.
	/// </summary>
	public class Pager
	{
		private string			_pagePath;
		private StringBuilder	sb;

		/// <summary>
		/// Pager Ŭ������ �������Դϴ�.
		/// </summary>
		/// <param name="pagePath"></param>
		public Pager( string pagePath )
		{
			_pagePath = pagePath;
		}
		
		/// <summary>
		/// ����¡ html �±׸� ��ȯ�ϴ� �޼ҵ�
		/// </summary>
		/// <param name="RequestPage">��û������</param>
		/// <param name="PageCount">��������</param>
		/// <param name="IsPathExtended">������Ʈ�� Ȯ�� ����</param>
		/// <param name="BeginStr">10�� �� ������</param>
		/// <param name="BackStr">�� ������</param>
		/// <param name="NextStr">���� ������</param>
		/// <param name="EndStr">10�� ���� ������</param>
		/// <returns>html �±� ��ȯ</returns>
		public string GetExtendedPager(int RequestPage,int PageCount,bool IsPathExtended,string BeginStr,string BackStr,string NextStr,string EndStr)
		{
			sb = new StringBuilder();
			string Path = _pagePath;
			int MinValue = 1;
			int MaxValue = PageCount +1;								//������ ��ȣ
			
			int StartValue = RequestPage - ((RequestPage-1) % 10);		// ���� ��ȣ
			int EndValue = StartValue + 10;								// �� ��ȣ

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
