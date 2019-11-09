namespace Animals
{
    using System;
    using System.Text;

    public class Animal
    {
        private const string ErrorMessage = "Invalid input!";

        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public virtual string Name
        {
            get => this.name;
            protected set
            {
                if (IsNotValid(value))
                {
                    throw new ArgumentException(ErrorMessage);
                }

                this.name = value;
            }
        }

        public virtual int Age
        {
            get => this.age;
            protected set
            {
                if (IsNotValid(value.ToString()) || value < 0)
                {
                    throw new ArgumentException(ErrorMessage);
                }

                this.age = value;
            }
        }

        public virtual string Gender
        {
            get => this.gender;
            protected set
            {
                if (IsNotValid(value))
                {
                    throw new ArgumentException(ErrorMessage);
                }

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "";
        }

        private bool IsNotValid(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(this.ProduceSound());

            return sb.ToString().Trim();
        }
    }
}