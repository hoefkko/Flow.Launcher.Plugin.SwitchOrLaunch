using System.Collections.Generic;

namespace SuperSwaunch.Core.Matchers
{
    public class MatchResult
    {
        public bool Matched { get; set; }
        public int Score { get; set; }
        public IList<StringPart> StringParts { get; set; }

        public MatchResult()
        {
            StringParts = new List<StringPart>();
        }
    }
}