using System.Collections.Generic;

public static class ComparerLib
{
	[System.Serializable]
	public class StringComparer : IEqualityComparer<string>
	{
		public bool Equals(string s1, string s2)
		{
			return s1.Equals(s2);
		}

		public int GetHashCode(string s)
		{
			return s.GetHashCode();
		}
	}

	public static readonly StringComparer stringComparer = new StringComparer();
}
