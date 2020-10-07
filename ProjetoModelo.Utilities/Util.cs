using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjetoModelo.Utilities
{
	public static class Util
	{
		public static string GetDescription(this Enum pEnumerador)
		{
			try
			{
				if (pEnumerador == null)
					return null;
				var field = pEnumerador.GetType().GetField(pEnumerador.ToString());

				if (field == null)
					return null;

				var descricaoValue = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

				if (descricaoValue == null)
					return pEnumerador.ToString();

				return descricaoValue.Description;

			}
			catch (Exception ex)
			{

				throw new Exception("Erro ao recuperar a descrição do enumerador");
			}
		}
	}
}
