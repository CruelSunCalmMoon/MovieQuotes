using System;

namespace MovieQuotes
{
    public class Quote : IdentityBase
    {
        //Atributes
        private Gender Gender { get; set; }
        private string Title {get ; set; }
        private string Description { get; set; }
        private string Author { get; set; }
        private bool Excluded { get; set; }

        //Methods
        public Quote(int id, Gender gender, string title, string description, string author)
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Author = author;
            this.Excluded = false;
        }

        public override string ToString()
        {
            // Environment.NewLine 
            string putback = "";
            putback += "Gender: " + this.Gender + Environment.NewLine;
            putback += "Title: " + this.Title + Environment.NewLine;
            putback += "Description: " + this.Description + Environment.NewLine;
            putback += "Author: " + this.Author + Environment.NewLine;
            putback += "Excluded: " + this.Excluded + Environment.NewLine;  
            return putback;
        }

        public string bringBackQuote()
        {
            return this.Description;
        }

        public int bringBackId()
        {
            return this.Id;
        }

        public bool bringBackExcluded()
        {
            return this.Excluded;
        }

        public void Exclude()
        {
            this.Excluded = true;
        }

    }
}