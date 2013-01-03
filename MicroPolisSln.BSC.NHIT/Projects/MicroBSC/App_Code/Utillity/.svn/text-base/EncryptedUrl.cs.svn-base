using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Web;

namespace MicroBSC.Common
{
	/// <summary>
	/// QueryString를 암호화 하는 클래스입니다.
	/// </summary>
	public class EncryptedUrl
	{
		private const string ENCRYPTED_KEY  = "Key";
		private string _pageUrl             = string.Empty;
		private Hashtable _queryStrings;
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="fullUrl"></param>
		public EncryptedUrl(string fullUrl)
		{
			if (fullUrl.IndexOf('?') > 0)
			{
				string[] urlAndQueryString = fullUrl.Split('?');
				_pageUrl = urlAndQueryString[0];

				if (urlAndQueryString.Length > 1)
				{
					Parse(urlAndQueryString[1]);
				}
			}
			else
			{
				_pageUrl = fullUrl;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="url"></param>
		/// <param name="queryString"></param>
		public EncryptedUrl(string url, string queryString)
		{
			_pageUrl = url;
			Parse(queryString);
		}

		/// <summary>
		/// 
		/// </summary>
		private Hashtable myQueryString
		{
			get
			{
				if (_queryStrings == null)
				{
					_queryStrings = new Hashtable();
				}

				return _queryStrings;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string this[string key]
		{
			get
			{
				return (string) myQueryString[key];
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="queryString"></param>
		private void Parse(string queryString)
		{
			string[] parts = queryString.Split('&');

			foreach(string part in parts)
			{
				int equalToPosition = part.IndexOf('=');

				string name = part.Substring(0, equalToPosition);
				string val = part.Substring(equalToPosition + 1);
				val = HttpUtility.UrlDecode(val);

				if (name == ENCRYPTED_KEY)
				{
					if (val.Length > 0)
					{
						string decryptedString = HttpUtility.UrlDecode(StringEncrypter.Decrypt(val));

						string[] keyValue = decryptedString.Split('&');

						for(int i=0; i < keyValue.Length; i++)
						{
							string param = keyValue[i];
							equalToPosition = param.IndexOf('=');

							if (equalToPosition > 0)
							{
								string paramName = param.Substring(0, equalToPosition);
								string paramValue = param.Substring(equalToPosition + 1);

								myQueryString.Add(paramName, paramValue);
							}
						}
					}
				}
				else
				{
					myQueryString.Add(name, val);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return ToString(false);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="unicode"></param>
		/// <returns></returns>
		public string ToString(bool unicode)
		{
			StringBuilder queryString = new StringBuilder(myQueryString.Count * 12);

			IDictionaryEnumerator e = myQueryString.GetEnumerator();

			while(e.MoveNext())
			{
				queryString.Append((string) e.Key);
				queryString.Append('=');
				queryString.Append(HttpUtility.UrlEncode((string) e.Value));
				queryString.Append('&');
			}
			queryString.Remove(queryString.Length - 1, 1);

			string encryptedQuery = StringEncrypter.Encrypt(queryString.ToString());

			string encodedQuery = HttpUtility.UrlEncode(encryptedQuery);

			if (unicode)
			{
				//Required if we are passing it to JavaScript
				encodedQuery = HttpUtility.UrlEncodeUnicode(encodedQuery);
			}

			return _pageUrl + "?" + ENCRYPTED_KEY + "=" + encodedQuery;
		}

		private class StringEncrypter
		{
			private StringEncrypter()
			{

			}
			/// <summary>
			/// 
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static string Encrypt(string value)
			{
				try
				{
					using(SymmetricAlgorithm crypto = CreateAlgorithm())
					{
						return Convert.ToBase64String(ReadCryptoData(crypto.CreateEncryptor(), Encoding.Default.GetBytes(value)));
					}
				}
				catch(Exception e)
				{
					throw e;
				}
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public static string Decrypt(string value)
			{
				try
				{
					using(SymmetricAlgorithm crypto = CreateAlgorithm())
					{
						byte[] returnData = ReadCryptoData(crypto.CreateDecryptor(), Convert.FromBase64String(value));

						return Encoding.Default.GetString(returnData);
					}
				}
				catch(Exception e)
				{
					throw e;
				}
			}


			private static byte[] _iv;
			private static byte[] _key;

			private static SymmetricAlgorithm CreateAlgorithm()
			{
				//Modify it if we need any different Algorithm;
				//Probbale options are:
				// 1. RijndaelManaged
				// 2. DESCryptoServiceProvider
				// 3. RC2CryptoServiceProvider
				// 4. TripleDESCryptoServiceProvider

				SymmetricAlgorithm crypto = new TripleDESCryptoServiceProvider();

				if ((_iv == null) || (_key == null))
				{
					lock(typeof(StringEncrypter))
					{
						//By Using Generate the Same QueryString will
						//be Differentl by time to time, But we need to make sure
						//that the Key and the IV remains same between
						//the application starts and end.

						crypto.GenerateIV();
						crypto.GenerateKey();
						_iv = crypto.IV;
						_key = crypto.Key;
					}
				}

				crypto.IV = _iv;
				crypto.Key = _key;

				return crypto;
			}
			
			/// <summary>
			/// 
			/// </summary>
			/// <param name="transformer"></param>
			/// <param name="data"></param>
			/// <returns></returns>
			private static byte[] ReadCryptoData(ICryptoTransform transformer, byte[] data)
			{
				using(MemoryStream memoryStream = new MemoryStream())
				{
					using(CryptoStream cryptoStream = new CryptoStream(memoryStream, transformer, CryptoStreamMode.Write))
					{
						cryptoStream.Write(data, 0, data.Length);
						cryptoStream.FlushFinalBlock();

						byte[] returnValue = memoryStream.ToArray();
						return returnValue;
					}
				}
			}
		}
	}
}