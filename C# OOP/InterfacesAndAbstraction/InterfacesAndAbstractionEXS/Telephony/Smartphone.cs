namespace Telephony
{
    public class Smartphone : IPhoneBrowseable, IPhoneCallable
    {
        public string Browse(string site)
        {
            if (IsSiteValid(site))
            {
                return $"Browsing: {site}!";
            }
            return "Invalid URL!";
        }

        public string Call(string number)
        {
            if (IsNumberValid(number))
            {
                return $"Calling... {number}";
            }

            return "Invalid number!";
        }

        private bool IsSiteValid(string site)
        {
            foreach (var ch in site)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsNumberValid(string number)
        {
            foreach (var ch in number)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
