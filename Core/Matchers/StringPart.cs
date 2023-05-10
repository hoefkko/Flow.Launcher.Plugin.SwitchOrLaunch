namespace SuperSwaunch.Core.Matchers
{
    public class StringPart
    {
        public string Value { get; set; }
        public string QuickFilter { get; set; }
        public bool IsMatch { get; set; }

        public StringPart()
        {
        }

        public StringPart(string value, string quickFiler = "", bool isMatch = false)
        {
            Value = value;
            IsMatch = isMatch;
            QuickFilter = quickFiler;
        }

        public StringPart(string value, bool isMatch = false)
        {
            Value = value;
            IsMatch = isMatch;
        }

        public StringPart(string value)
        {
            Value = value;
            IsMatch = false;
        }
    }
}