<Script language="VBScript">
	
	Private Const CSIDL_DESKTOPDIRECTORY= &H10	
	Private Type SHITEMID
		cd As Long
		abID As Byte
	End Type
	
	Private Type ITEMIDLIST
		mkid As SHITEMID
	End Type
	
	Private Declare Function SHGetPathFromIDList Lib "shell32.dll" Alias "SHGetPathFromIDListA" (ByVal pidI As Long,ByVal pszPath As String) As Long
	Private Declare Function SHGetSpecialFolderLocation Lib "shell32.dll"(ByVal hwndOwner As Long,ByVal nFolder As Long,pidl As ITEMIDLIST) As Long	
	Private Function GetSpecialPath(CSIDL As Long) As String
		Dim r As Long
		Dim IDL As ITEMIDLIST		
		Dim NOERROR
		Dim Path As String		
		r=SHGetSpecialFolerLocation(100,CSIDL,IDL)
		If r=NOERROR Then
			Path = Space$(512)
			r=SHGetPathFromIDList(ByVal IDL.mkid.cb,Byval Path$)
			GetSpecialPath=Left$(Path,InStr(Path,Chr$(0))-1)
			Exit Function 
		End If
		GetSpecialPath =""
	End Function 
	
	Private Sub Command1_Click()
		Call CreateURL
	End Sub
	
	Private Sub CreateURL()
		Dim GetDesktopPass As String
		Dim fso As Object
		Dim a As Object
		
		GetDesktopPass = GetSpecialPath(CSIDL_DESKTOPDIRECTORY)		
		Set fso = CreteObject("Scriting.FileSystemObject")
		Set a = fso.CreateTextFile(GetDesktopPass & "\pro.url",True)		
		a.WriteLine("[InternetShortcut]")
		a.WriteLine("URL=http://pro.kdgas.co.kr")		
		a.Close
	End Sub
	
</script>
<input type=button name=Command1 value="바로가기">