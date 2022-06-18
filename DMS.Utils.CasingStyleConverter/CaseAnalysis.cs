using System.Text;

namespace DMS.Utils.CasingStyleConverter
{
	public class CaseAnalysis
	{
		private enum WordSeperator
		{
			Unknown,
			UpperCaseLetter,
			Underscore,
			Dash
		}

		internal CaseAnalysis(string text)
		{
			RawText = text;
			AnalyzeText(text);
		}

		private void AnalyzeText(string text)
		{
			Words = new List<string>();
			StringBuilder currentWord = new StringBuilder();
			Seperator = WordSeperator.Unknown;

			for (int i = 0; i < text.Length; i++)
			{
				char ch = text[i];
				if (i > 0 && char.IsUpper(ch))
				{
					RegisterSeperator(WordSeperator.UpperCaseLetter);
					RegisterWord(currentWord);
					currentWord.Clear();
					currentWord.Append(text[i]);
				}
				else if (ch == '_')
				{
					RegisterSeperator(WordSeperator.Underscore);
					RegisterWord(currentWord);
					currentWord.Clear();
				}
				else if (ch == '-')
				{
					RegisterSeperator(WordSeperator.Dash);
					RegisterWord(currentWord);
					currentWord.Clear();
				}
				else if (ch == ' ')
				{
					RegisterWord(currentWord);
					currentWord.Clear();
				}
				else
				{
					currentWord.Append(text[i]);
				}
			}
			RegisterWord(currentWord);
			DetermineCasing();
		}

		private void RegisterWord(StringBuilder word)
		{
			Words.Add(word.ToString().ToLower());
		}

		private void RegisterSeperator(WordSeperator seperator)
		{
			if (Seperator == WordSeperator.Unknown)
			{
				Seperator = seperator;
			}
		}

		private void DetermineCasing()
		{
			var casing = Casing.Unknown;
			switch (Seperator)
			{
				case WordSeperator.UpperCaseLetter:
					casing = char.IsLower(RawText[0]) ? Casing.CamelCase : Casing.PascalCase;
					break;
				case WordSeperator.Underscore:
					casing = Casing.SnakeCase;
					break;
				case WordSeperator.Dash:
					casing = Casing.KebabCase;
					break;
			}
			Casing = casing;
		}

		public string RawText { get; }
		internal List<string> Words { get; private set; }
		public Casing Casing { get; private set; }
		private WordSeperator Seperator { get; set; }
	}
}
