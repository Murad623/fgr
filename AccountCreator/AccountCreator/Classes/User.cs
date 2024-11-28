using AccountCreator.Interfaces;
namespace AccountCreator.Classes
{
    internal class User : IAccount
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(string cFullname, string cEmail, string cPassword)
        {
            Fullname = cFullname;
            Email = cEmail;
            while (!PasswordChecker(cPassword))
            {
                Thread.Sleep(3000);
                Console.Clear();
                Console.Write("Password : ");
                cPassword = Console.ReadLine();
            }
            Password = cPassword;

        }
        public bool PasswordChecker(string password)
        {
            //throw new NotImplementedException();
            bool[] passchecks = { false, false, false, false };
            if (password.Length >= 8) passchecks[3] = true;
            for (int i = 0; i < password.Length; i++)
            {
                if (int.TryParse(password[i].ToString(), out int x))
                {
                    passchecks[0] = true;
                    continue;
                }
                if (password[i].ToString() == password[i].ToString().ToUpper())
                {
                    passchecks[1] = true;
                    continue;
                }
                if (password[i].ToString() == password[i].ToString().ToLower())
                {
                    passchecks[2] = true;
                }
            }
            Console.Write((passchecks[0] ? "" : "En az 1 reqem olmalıdı\n") + (passchecks[1] ? "" : "En az 1 böyük herf olmalıdı\n") + (passchecks[2] ? "" : "En az 1 kiçik herf olmalıdı\n") + (passchecks[3] ? "" : "Minimum 8 karakter olmalıdı"));
            for (int i = 0; i < passchecks.Length; i++) if (!passchecks[i]) return false;
            return true;
        }

        public void ShowInfo()
        {
            //throw new NotImplementedException();
            Console.Write("Full name : " + Fullname + "\nEmail : " + Email);
        }
    }
}
