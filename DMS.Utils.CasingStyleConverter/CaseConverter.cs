namespace DMS.Utils.CasingStyleConverter
{
	public static class CaseConverter
	{
		public static CaseAnalysis? AnalyseCasing(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}

			return new CaseAnalysis(text);
		}


		public static string? Convert(string text, Casing toCase)
		{
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}

			var analysis = AnalyseCasing(text);
			if (analysis != null)
			{
				return Convert(analysis, toCase);
			}
			return null;
		}

		public static string Convert(CaseAnalysis analysis, Casing toCase)
		{
			switch (toCase)
			{
				case Casing.CamelCase:
					if (analysis.Words.Count <= 1)
					{
						return analysis.Words.FirstOrDefault();
					}
					return $"{analysis.Words.First()}{string.Join("", analysis.Words.Skip(1).Select(w => Captialize(w)))}";

				case Casing.SnakeCase:
					return string.Join('_', analysis.Words);
				case Casing.KebabCase:
					return string.Join('-', analysis.Words);
				case Casing.PascalCase:
					return string.Join("", analysis.Words.Select(w => Captialize(w)));
			}

			throw new ArgumentException($"Unhandled target case: {toCase}");
		}

		private static string Captialize(string w)
		{
			return $"{char.ToUpper(w[0])}{w.Substring(1)}";
		}
	}
}